using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    public class DialogWindows
    {
        public static void Save(string s, bool binary = false)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if(binary)
                dialog.Filter = "bin files (*.bin)|*.bin";
            else
                dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            var f = File.CreateText(dialog.FileName);
            f.WriteLine(s);
            f.Close();
        }


        public static string Load(bool binary = false)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (binary)
                dialog.Filter = "bin files (*.bin)|*.bin";
            else
                dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                throw new Exception();
            }
            return File.ReadAllText(dialog.FileName, Encoding.GetEncoding(1251));
        }
    }
}
