using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ssp3
{
    static class Program
    {
        static Thread t1, t2, t3, t4;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Fora f = new Fora();
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.MaximizeBox = false;

            //Form1 f = new Form1();
            t1 = new Thread(new ThreadStart(f.cycl1));
            t2 = new Thread(new ThreadStart(f.cycl2));
            t3 = new Thread(new ThreadStart(f.cycl3));
            t4 = new Thread(new ThreadStart(f.cycl4));
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            Application.ApplicationExit += new EventHandler(ApplicationExitHandler);
            Application.Run(f);

        }

        private static void ApplicationExitHandler(Object sender, EventArgs e)
        {
            t1.Abort();
            t2.Abort();
            t3.Abort();
            t4.Abort();

        }
    }
}
