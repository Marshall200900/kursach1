using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanRealization
{
    public class DialogSaving
    {
        public static bool Save(string s)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return false;
            var f = File.CreateText(dialog.FileName);
            f.WriteLine(s);
            f.Close();
            return true;
        }
    }
}
