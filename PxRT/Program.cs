using System;
using System.Windows.Forms;

namespace PxRT
{
    public class Program
    {
        [STAThreadAttribute]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PreviewWindow());
        }
    }
}
