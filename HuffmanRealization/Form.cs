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
    public partial class Form : System.Windows.Forms.Form
    {
        public static bool encodedStrWithTree;// Булево поле, отвечающее за споссоб кодировки текста (с деревом или без него)
        public static bool encoded; // Закодирован ли текст в данный момент
        public Form()
        {
            InitializeComponent();
            DecodedButtons();
        }

        //Функция, устанавливающая активность кнопок на форме, если текст закодирован
        private void EncodedButtons()
        {
            encodeTreeBtn.Enabled = false;
            encodeBtn.Enabled = false;
            decodeBtn.Enabled = true;
            SaveCodeBtn.Enabled = true;
            SaveTextBtn.Enabled = false;
            encoded = true;
        }
        // Функция, устанавливающая активность кнопок на форме, если текст не закодирован
        private void DecodedButtons()
        {
            decodeBtn.Enabled = false;
            encodeBtn.Enabled = true;
            encodeTreeBtn.Enabled = true;
            SaveTextBtn.Enabled = true;
            SaveCodeBtn.Enabled = false;
            encoded = false;
        }

        // Код функции нажатия кнопки кодировки без дерева
        private void encodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                compressedTextBox.Text = EncodingText.EncodeHuffman(textBox.Text); // Получение сжатого кода
                EncodingText.RootCode = EncodingText.EncodeTree(EncodingText.Root); // Получение дерева
            }
            catch (Exception) // Если поймано исключение, выйти из функции
            {
                MessageBox.Show("Введите текст");
                return;
            }
            double cooficient = textBox.Text.Length * 8 / (double)compressedTextBox.Text.Length; // Подсчет коэффициента
            
            textBox.Text = "";
            encodedStrWithTree = false; 
            EncodedButtons();

            label2.Text = "Коэффициент сжатия - " + string.Format("{0:N2}", cooficient); // Отображение коэффициента сжатия на label

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string back = compressedTextBox.Text;
            Node root = new Node();
            string decompressedText = "";

            try
            {
                // Если строка была закодирована вместе с деревом, то сначала надо декодировать дерево
                if (encodedStrWithTree)
                {
                    root = DecodingText.DecodeTree(ref back);
                }
                //Иначе оно хранится в классе EncodingText в поле Root
                else
                {
                    root = EncodingText.Root;
                }
                decompressedText = DecodingText.DecodeHuffman(root, back); // Декодирование двоичного кода
                textBox.Text = decompressedText;
            }
            catch (Exception) // Если не удается корректно преобразовать данные, выдать исключение
            {
                MessageBox.Show("Невозможно прочитать код. Откройте корректный файл");
            }
            compressedTextBox.Text = "";
            label2.Text = "";
            DecodedButtons();
        }


        // Очистить поля и привести все кнопки в положение "не закодировано"
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compressedTextBox.Text = "";
            textBox.Text = "";
            encodeBtn.Enabled = true;
            encodeTreeBtn.Enabled = true;
            decodeBtn.Enabled = false;
        }

        // Кодирование текста с деревом
        private void encodeWithTreeBtn_Click(object sender, EventArgs e)
        {
            string encodedStr = ""; // Заготовка для закодированной строки
            try
            {
                encodedStr = EncodingText.EncodeHuffman(textBox.Text); // Кодирование текста
                EncodingText.RootCode = EncodingText.EncodeTree(EncodingText.Root); // Кодирование дерева
                compressedTextBox.Text = EncodingText.RootCode + encodedStr; // Складываение строк и вывод в форму
            }
            catch (Exception) // Если поймано исключение, выйти из функции
            {
                MessageBox.Show("Введите текст");
                return;
            }
            double cooficient = textBox.Text.Length * 8 / (double)encodedStr.Length; // Подсчет коэффициента
            label2.Text = "Коэффициент сжатия - " + string.Format("{0:N2}", cooficient); // Вывод коэффициента

            encodedStrWithTree = true;
            textBox.Text = "";
            EncodedButtons();
        }

        // Сохранение
        private void SaveTextBtn_Click(object sender, EventArgs e)
        {
            if(textBox.Text == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }
            DialogWindows.Save(textBox.Text);
        }

        // Открытие
        private void SaveCodeBtn_Click(object sender, EventArgs e)
        {
            if (compressedTextBox.Text == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }
            DialogWindows.Save(encodedStrWithTree?compressedTextBox.Text: EncodingText.RootCode + compressedTextBox.Text, true);

        }

        private void OpenText_Click(object sender, EventArgs e)
        {
            try
            {
                textBox.Text = DialogWindows.Load(); // Загрузка текста из файла
            }
            catch (Exception)
            {
                return;
            }

            // Проверка на корректность кодировки
            if (!(Encoding.GetEncoding(1251).GetByteCount(textBox.Text) == textBox.Text.Length))
            {
                MessageBox.Show("Неверная кодировка. Откройте другой файл.");
                textBox.Text = "";
                return;
            }
            DecodedButtons();
            compressedTextBox.Text = "";
        }

        private void OpenCode_Click(object sender, EventArgs e)
        {
            try
            {
                compressedTextBox.Text = DialogWindows.Load(true); // Загрузка кода из файла
            }
            catch (Exception)
            {
                return;
            }

            // Проверка на наличие символов, помимо 1, 0 и перевода строки
            foreach (char c in compressedTextBox.Text)
            {
                if (!(c == '1' || c == '0' || c == Environment.NewLine[0] || c == Environment.NewLine[1]))
                {
                    MessageBox.Show("Строка содержит символы, помимо 1 или 0");
                    ClearToolStripMenuItem_Click(sender, e);
                    return;
                }
            }

            compressedTextBox.Text = compressedTextBox.Text.Replace("\n", string.Empty); // Удаление символов перевода строки
            EncodedButtons();
            encodedStrWithTree = true;
            textBox.Text = "";
        }
    }
}
