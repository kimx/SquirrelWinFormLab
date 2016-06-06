using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squirrel;

namespace SquirrelWinFormLab
{
    /// <summary>
    /// Package File in Package Console:
    /// Squirrel --releasify SourcePackages\SquirrelWinFormLab.1.0.0.nupkg
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var mgr = new UpdateManager("C:\\Projects\\MyApp\\Releases"))
            //{
            //    await mgr.UpdateApp();
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    
    }
}
