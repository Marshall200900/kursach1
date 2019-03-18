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
                encodedStr = EncodingHuffman.EncodeHuffman(textBox.Text);
                compressedTextBox.Text += EncodingHuffman.EncodeTree(EncodingHuffman.Root);
                foreach (char c in EncodingHuffman.BytesStr.Keys)
                {
                    var bytes = Encoding.GetEncoding(1251).GetBytes(c.ToString());
                    var binstr = string.Join("", bytes.Select(b => Convert.ToString(b, 2)));
                    //MessageBox.Show(binstr);
                    compressedTextBox.Text += string.Format("{0:d8}", int.Parse(binstr));

                }

                compressedTextBox.Text += encodedStr;
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
                saved = DialogSaving.Save(compressedTextBox.Text);
            }
            if (saved)
            {
                int textBoxLen = textBox.Text.Length;
                textBox.Text = "";
                

                //double coefficient = textBoxLen * 8 / encodedStr.Length;
                //if (coefficient > 1)
                //{
                //    MessageBox.Show("Успешное сжатие данных\n" +
                //    "Коэффициент сжатия в кодировке ASCII - " + string.Format("{0:N2}", coefficient));
                //}
                //else
                //{
                //    MessageBox.Show("Получен двоичный код, но коэффициент сжатия в кодировке ASCII равен 1");
                //}

            }
            button2.Enabled = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string back = compressedTextBox.Text; //Строка с кодом
            Node root = DecodingHuffman.DecodeTree(ref back);
           
            int number = root.FindNumberOfEnds();

            //MessageBox.Show(back);
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < number; i++)
            {
               // MessageBox.Show(back.Substring(0, 8));
                byteList.Add(Convert.ToByte(back.Substring(0, 8), 2));
                back = back.Substring(8);
                

            }
            string symbols = Encoding.GetEncoding(1251).GetString(byteList.ToArray());
           // MessageBox.Show(symbols);
            Node.AttachSymbols(root, ref symbols);

            string decompressedText = DecodingHuffman.DecodeHuffman(root, back);
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
            textBox.Text = File.ReadAllText(dialog.FileName, Encoding.GetEncoding(1251));
        }

        private void открытьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                button2.Enabled = false;
                return;
            }

            compressedTextBox.Text = File.ReadAllText(dialog.FileName, Encoding.GetEncoding(1251));
        }
    }
}
