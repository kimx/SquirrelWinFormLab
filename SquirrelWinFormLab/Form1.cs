using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquirrelWinFormLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            locationTextBox.Text = assembly.Location;
            versionTextBox.Text = assembly.GetName().Version.ToString(3);
            using (var mgr = new UpdateManager(@"D:\GitHub\SquirrelWinFormLab\Releases"))
            {
                var update = await mgr.CheckForUpdate();
                if (update.ReleasesToApply.Count > 0)
                {
                    MessageBox.Show($"{update.ReleasesToApply.Count},{update.ReleasesToApply[0].PackageName}");
                    await mgr.DownloadReleases(update.ReleasesToApply);
                    var dirPath = await mgr.ApplyReleases(update);
                    MessageBox.Show("New Version has installed.Application need to restart now!");
                    Process.Start($"{dirPath}\\SquirrelWinFormLab.exe");
                    Application.Exit();
                }

                //var result = await mgr.UpdateApp();
                //if (result != null)
                //{
                //    MessageBox.Show("UpdateApp:New Version has installed.Application need to restart now!");
                //    Application.Restart();//fail:會取到舊版路徑
                //}

            }
        }


    }
}
