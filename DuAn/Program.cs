using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmnhanvien;
using frmfornhvhc;
using frmquannhan;
using frmlogin;
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
           Application.Run(new frmmhlogin());
            // Application.Run(new frmlapthucdon());
            // Application.Run(new frmbqs());
            //  Application.Run(new frmlichsucatcom());
            //Application.Run(new frmLSQS());
           Application.Run(new frm_manhinh_quannhan());
            //Application.Run(new frmfornhvhc());
            //Application.Run(new frmquannhan());
            //Application.Run(new frmnhanvien());
<<<<<<< HEAD
              //  Application.Run(new frmdsthucpham());
              
=======
              //Application.Run(new frmdsthucpham());
>>>>>>> 72650025ec5c75e68fed3025a109b6737db21ddf
        }
    }
}
