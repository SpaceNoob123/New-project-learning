using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        private bool isDarkTheme = false;

        public Form1()
        {
            InitializeComponent();

            InitializeThemeToggleButton();
        }
        private void InitializeThemeToggleButton()
        {
            // Создаём кнопку переключения темы
            var btnThemeToggle = new Button();
            btnThemeToggle.Size = new Size(32, 32);
            btnThemeToggle.Location = new Point(339, 264);
            btnThemeToggle.FlatStyle = FlatStyle.Flat;
            btnThemeToggle.FlatAppearance.BorderSize = 0;
            btnThemeToggle.Text = "T";


            // Устанавливаем цвет фона кнопки
            if (isDarkTheme)
            {
                btnThemeToggle.BackColor = Color.FromArgb(32, 32, 32);
            }
            else
            {
                btnThemeToggle.BackColor = Color.White;
            }

            // Подписываемся на событие нажатия кнопки
            btnThemeToggle.Click += (sender, args) =>
            {
                isDarkTheme = !isDarkTheme;
                

                // Применяем выбранную тему к всем контролам на форме
                ApplyTheme(isDarkTheme);
            };

            // Добавляем кнопку на форму
            this.Controls.Add(btnThemeToggle);
        }

        private void ApplyTheme(bool isDark)
        {
            if (isDark)
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                this.label1.BackColor = Color.White;
                this.label1.ForeColor = Color.Black;
                this.label2.BackColor = Color.White;
                this.label2.ForeColor = Color.Black;
                this.label3.BackColor = Color.White;
                this.label3.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
                this.label1.BackColor = Color.White;
                this.label1.ForeColor = Color.Black;
                this.label2.BackColor = Color.White;
                this.label2.ForeColor = Color.Black;
                this.label3.BackColor = Color.White;
                this.label3.ForeColor = Color.Black;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox.DisplayMember = "Name";
            LoadListFromFile(listBox, "list.txt");

        }
        private void SaveListToFile(ListBox listBox, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (object item in listBox.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
        private void LoadListFromFile(ListBox listBox, string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBox.Items.Add(line);
                    }
                }
            }
        }

    }
}
