using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmnhanvien;
using frmfornhvhc;
using frmquannhan;
using frmlogin;
using DuAn.GUI.frmquannhan;
namespace DuAn
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmlapthucdon());
            //Application.Run(new frmfornhvhc());
            //Application.Run(new frmquannhan());
            //Application.Run(new frmnhanvien());
        }
    }
}
