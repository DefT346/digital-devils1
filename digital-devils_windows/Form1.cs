using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace digital_devils_windows
{
    public partial class Form1 : Form
    {
        private string login = "google@yandex.ru";
        private string password = "123456";

        public Form1()
        {
            InitializeComponent();
            SelectPage(authorization1);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SelectPage(Panel page)
        {
            authorization1.Visible = false;
            authorization2.Visible = false;
            registration.Visible = false;
            newappeal.Visible = false;

            page.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var log = textBox1.Text.Replace(" ", "");

            if (log == "") MessageBox.Show("Поле не может быть пустым", "Ошибка авторизации", MessageBoxButtons.OK);
            else
            if (log == login) {
                SelectPage(authorization2);
            }
            else
                SelectPage(registration);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox2.Text.Replace(" ", "") == password)
                SelectPage(newappeal);
            else 
                MessageBox.Show("Неверный пароль", "Ошибка авторизации", MessageBoxButtons.OK);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Replace(" ", "") == "" || textBox4.Text.Replace(" ", "") == "") MessageBox.Show("Заполните обязательные поля", "Ошибка регистрации", MessageBoxButtons.OK);
            else
                SelectPage(newappeal);
        }


        private Point mouseOffset;
        private bool isMouseDown = false;

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!testmode)
                Console.WriteLine("Определена категория: " + NeuraKeyword.GetOrganization(textBox10.Text + " " + textBox14.Text).organization);
            else
            {
                if (comboBox1.SelectedItem != null)
                    NeuraKeyword.Learn(textBox10.Text + " " + textBox14.Text, comboBox1.SelectedItem.ToString());
                else
                    MessageBox.Show("Выберите значение категории", "Ошибка режима тестирования", MessageBoxButtons.OK);
            }

        }

        bool testmode = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            testmode = (sender as CheckBox).Checked;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
