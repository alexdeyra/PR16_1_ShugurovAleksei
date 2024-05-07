using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z1pr16SH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileText = File.ReadAllText(textBox1.Text);
            listBox1.Items.Add(fileText);
            try
            {

                int count = Regex.Matches(fileText.ToLower(), @"\b" + textBox2.Text + @"\b").Count;
                MessageBox.Show($"Были найдены {count} вхождения(ий) поискового запроса \"{textBox2.Text}\"");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Файл по пути '{textBox1.Text}' не найден.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
