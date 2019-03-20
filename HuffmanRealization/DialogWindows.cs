using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    //Класс, отвечающий за сохраниение и открытие файлов
    public class DialogWindows
    {
        //Сохранение файлов
        public static void Save(string s, bool binary = false)//Если binary == true, то файл сохраняется в формате .bin (по умолчанию binary = false)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if(binary)
                dialog.Filter = "bin files (*.bin)|*.bin";
            else
                dialog.Filter = "txt files (*.txt)|*.txt";
            //Если диалогове окно закрывается, функция бросает исключение
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            //Запись файла в кодировке windows-1251
            File.WriteAllText(dialog.FileName, s, Encoding.GetEncoding(1251));

        }


        public static string Load(bool binary = false)//Если binary == true, то файлы отображаются в формате .bin (по умолчанию binary = false)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (binary)
                dialog.Filter = "bin files (*.bin)|*.bin";
            else
                dialog.Filter = "txt files (*.txt)|*.txt";
            //Если диалогове окно закрывается, функция бросает исключение
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                throw new Exception();
            }
            //Считывание текста в кодировке windows-1251
            return File.ReadAllText(dialog.FileName, Encoding.GetEncoding(1251));
        }
    }
}
