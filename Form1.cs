using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1._01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                // Зчитати вміст текстового поля зі списком слів для пошуку
                string[] words = textBox1.Text.Split(' ');

                // Зчитати вміст вибраного файлу, якщо це текстовий файл
                string fileExtension = Path.GetExtension(openFileDialog.FileName);
                if (fileExtension == ".txt")
                {
                    string text = File.ReadAllText(openFileDialog.FileName);

                    // Замінити всі слова зі списку на відповідні варіанти із квадратними дужками
                    foreach (string word in words)
                    {
                        string pattern = "\\b" + Regex.Escape(word) + "\\b"; // шаблон для знаходження слова
                        string replacement = $"[{word}]"; // заміна слова на його відповідний варіант із квадратними дужками
                        text = Regex.Replace(text, pattern, replacement);
                    }

                    // Запис зміненого вмісту у той же файл
                    File.WriteAllText(openFileDialog.FileName, text);
                }
            }

        }
    }
}

