using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digital_devils_windows
{
    public static class NeuraKeyword
    {
        private static string[] Organization = new string[10] { "Государство, политика и общество", "Социальная сфера", "ЖКХ", "Благоустройство", "Культура", "Экономика", "Безопасность", "Транспорт и дорожное хозяйство", "Инфраструктура", "Cельское хозяйство" };
        private static List<string> Keyword = new List<string>();
        private static List<float> Weight = new List<float>();
        private static List<string> idOrg = new List<string>();

        /// <summary>
        /// Обучение системы
        /// </summary>
        /// <param name="Message">Входное сообщение</param>
        /// <param name="id">Соответсвующий id организации</param>
        /// <returns></returns>
        public static void Learn(string message, string id)
        {

            message = message.ToLower();
            String[] Words = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Процесс обучения...");
            Console.WriteLine($"id категории: {id}");
            Console.WriteLine($"Сообщение: {message}");

            foreach (string i in Words)
            {

                if (i.Trim() != "")
                {
                    int idKey = Keyword.IndexOf(i);
                    if (idKey == -1)
                    {
                        Keyword.Add(i);
                        idOrg.Add(id);
                        Weight.Add(0.9f);
                    }
                    else
                    {
                        if (idOrg[idKey].IndexOf(id) == -1)
                        {
                            idOrg[idKey] = idOrg[idKey] + id;
                            Weight[idKey] = 1.0f - 0.1f * idOrg[idKey].Length;
                        }

                    }
                }
            };

            Console.WriteLine($"Успех \n");
        }

        /// <summary>
        /// Возвращает айди организации, которой подходит данное сообщение
        /// </summary>
        /// <param name="message">Входое сообщение</param>
        /// <returns></returns>
        public static (int maxid, float max, string organization) GetOrganization(string message)
        {

            message = message.ToLower();

            string[] Words2 = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            float[] WeightFinal = new float[10] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

            int[] AmountFinal = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (string i in Words2)
            {
                int idKey2 = Keyword.IndexOf(i);
                if (idKey2 != -1)
                {
                    for (int j = 0; j < idOrg[idKey2].Length; j++)
                    {
                        switch (idOrg[idKey2][j])
                        {
                            case '0': AmountFinal[0]++; WeightFinal[0] = WeightFinal[0] + Weight[idKey2]; break;
                            case '1': AmountFinal[1]++; WeightFinal[1] = WeightFinal[1] + Weight[idKey2]; break;
                            case '2': AmountFinal[2]++; WeightFinal[2] = WeightFinal[2] + Weight[idKey2]; break;
                            case '3': AmountFinal[3]++; WeightFinal[3] = WeightFinal[3] + Weight[idKey2]; break;
                            case '4': AmountFinal[4]++; WeightFinal[4] = WeightFinal[4] + Weight[idKey2]; break;
                            case '5': AmountFinal[5]++; WeightFinal[5] = WeightFinal[5] + Weight[idKey2]; break;
                            case '6': AmountFinal[6]++; WeightFinal[6] = WeightFinal[6] + Weight[idKey2]; break;
                            case '7': AmountFinal[7]++; WeightFinal[7] = WeightFinal[7] + Weight[idKey2]; break;
                            case '8': AmountFinal[8]++; WeightFinal[8] = WeightFinal[8] + Weight[idKey2]; break;
                            case '9': AmountFinal[9]++; WeightFinal[9] = WeightFinal[9] + Weight[idKey2]; break;
                            default: Console.WriteLine("Error"); break;

                        }

                    }

                }
            }

            int maxid = -1;
            float max = -1.0f;

            for (int i = 0; i < 10; i++)
            {
                if (AmountFinal[i] != 0)
                    WeightFinal[i] = WeightFinal[i] / (float)AmountFinal[i];
                else
                    WeightFinal[i] = 0;

                if (WeightFinal[i] > max) { max = WeightFinal[i]; maxid = i; }
            }

            return (maxid, max, Organization[maxid]);
        }
    }
}

