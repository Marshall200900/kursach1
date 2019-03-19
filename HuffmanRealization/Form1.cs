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
        public static bool encodedStrWithTree;
        public static bool encoded;
        public Form1()
        {
            InitializeComponent();
            DecodedButtons();
        }

        private void EncodedButtons()
        {
            encodeTreeBtn.Enabled = false;
            encodeBtn.Enabled = false;
            decodeBtn.Enabled = true;
            SaveCodeBtn.Enabled = true;
            SaveTextBtn.Enabled = false;
            encoded = true;
        }

        private void DecodedButtons()
        {
            decodeBtn.Enabled = false;
            encodeBtn.Enabled = true;
            encodeTreeBtn.Enabled = true;
            SaveTextBtn.Enabled = true;
            SaveCodeBtn.Enabled = false;
            encoded = false;
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                compressedTextBox.Text = EncodingHuffman.EncodeHuffman(textBox.Text);
                EncodingHuffman.RootCode = EncodingHuffman.EncodeTree(EncodingHuffman.Root);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите текст");
                return;
            }
            double cooficient = textBox.Text.Length * 8 / (double)compressedTextBox.Text.Length;
            
            textBox.Text = "";
            encodedStrWithTree = false;
            EncodedButtons();

            MessageBox.Show("Коэффициент сжатия - "+string.Format("{0:N2}", cooficient));
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string back = compressedTextBox.Text;
            Node root = new Node();
            string decompressedText = "";

            try
            {
                if (encodedStrWithTree)
                {
                    root = DecodingHuffman.DecodeTree(ref back);
                }
                else
                {
                    root = EncodingHuffman.Root;
                }
                decompressedText = DecodingHuffman.DecodeHuffman(root, back);
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно прочитать код. Откройте корректный файл");
            }
            textBox.Text = decompressedText;
            compressedTextBox.Text = "";
            DecodedButtons();
        }

        //Если исходный текст изменился, то заблокировать кнопку получения исходных данных из кода
        private void text_TextChanged(object sender, EventArgs e)
        {
            decodeBtn.Enabled = false;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                textBox.Text = DialogWindows.Load();
            }
            catch (Exception)
            {
                return;
            }
            DecodedButtons();
        }

        private void открытьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                compressedTextBox.Text = DialogWindows.Load(true);
            }
            catch (Exception)
            {
                return;
            }

            foreach (char c in compressedTextBox.Text)
            {
                if (!(c == '1' || c == '0'||c==Environment.NewLine[0] || c == Environment.NewLine[1]))
                {
                    MessageBox.Show("Строка содержит символы, помимо 1 или 0");
                    ClearToolStripMenuItem_Click(sender, e);
                    return;
                }
            }
            EncodedButtons();
            encodedStrWithTree = true;
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compressedTextBox.Text = "";
            textBox.Text = "";
            encodeBtn.Enabled = true;
            encodeTreeBtn.Enabled = true;
            decodeBtn.Enabled = false;
        }

        private void encodeWithTreeBtn_Click(object sender, EventArgs e)
        {
            string encodedStr = "";
            try
            {
                encodedStr = EncodingHuffman.EncodeHuffman(textBox.Text);
                EncodingHuffman.RootCode = EncodingHuffman.EncodeTree(EncodingHuffman.Root);
                compressedTextBox.Text = EncodingHuffman.RootCode + encodedStr;
            }
            catch (Exception)
            {
                MessageBox.Show("Введите текст");
                return;
            }
            double cooficient = textBox.Text.Length * 8 / (double)encodedStr.Length;
            MessageBox.Show("Коэффициент сжатия - " + string.Format("{0:N2}", cooficient));

            encodedStrWithTree = true;
            textBox.Text = "";
            EncodedButtons();
        }

        private void SaveTextBtn_Click(object sender, EventArgs e)
        {
            if(textBox.Text == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }
            DialogWindows.Save(textBox.Text);
        }

        private void SaveCodeBtn_Click(object sender, EventArgs e)
        {
            if (compressedTextBox.Text == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }
            DialogWindows.Save(EncodingHuffman.RootCode+compressedTextBox.Text, true);

        }
    }
}
