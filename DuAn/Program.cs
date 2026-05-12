using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn.GUI.frmnhanvien;
using DuAn.GUI.frmfornhvhc;
using DuAn.GUI.frmquannhan;
using DuAn.GUI.frmlogin;
using DuAn.GUI.frmfornhvhc;
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
            //Application.Run(new frmmhlogin());
            // Application.Run(new frmlapthucdon());
            // Application.Run(new frmbqs());
            //  Application.Run(new frmlichsucatcom());
            //Application.Run(new frmLSQS());
            //Application.Run(new frm_manhinh_canbodonvi());
            //Application.Run(new frmfornhvhc());
            //Application.Run(new frmquannhan());
            //Application.Run(new frmnhanvien());

            //  Application.Run(new frmdsthucpham());

            //Application.Run(new frmdsthucpham());
            Application.Run(new frmbaocaoquanso());

        }
    }
}
