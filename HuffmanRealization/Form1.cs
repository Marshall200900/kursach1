using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string encodedStr = "";
            //Активирование кнопки декодировки
            button2.Enabled = true;

            try
            {
                encodedStr = Encoding.Encode(textBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите текст");
                return;
            }

            bool saved = true;
            //Сохранение результатов в файл
            if (checkBox2.Checked)
            {
                saved = DialogSaving.Save(encodedStr);
            }
            if (saved)
            {
                int textBoxLen = textBox.Text.Length;
                textBox.Text = "";
                compressedTextBox.Text = encodedStr;
                double coefficient = textBoxLen * 8 / encodedStr.Length;
                if (coefficient > 1)
                {
                    MessageBox.Show("Успешное сжатие данных\n" +
                    "Коэффициент сжатия в кодировке ASCII - " + string.Format("{0:N2}", coefficient));
                }
                else
                {
                    MessageBox.Show("Получен двоичный код, но коэффициент сжатия в кодировке ASCII равен 1");
                }
                
            }
            


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string back = compressedTextBox.Text; //Строка с кодом
            string decompressedText = Decoding.Decode(Encoding.Root, back);

            //Сохранение результатов в файл
            if (checkBox1.Checked)
            {
                DialogSaving.Save(decompressedText);
            }

            textBox.Text = decompressedText;
            compressedTextBox.Text = "";
        }

        //Если исходный текст изменился, то заблокировать кнопку получения исходных данных из кода
        private void text_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            textBox.Text = File.ReadAllText(dialog.FileName);
        }
    }
}
