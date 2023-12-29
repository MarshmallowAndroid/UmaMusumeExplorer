using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer
{
    class UmaApplicationContext : ApplicationContext
    {
        public UmaApplicationContext()
        {

            SplashForm splashForm = new();
            splashForm.ShowLoadAndClose();

            splashForm.OnLoadSuccess += (s, e) =>
            {
                MainForm mainForm = new();
                mainForm.Show();
                mainForm.FormClosed += (s, e) => ExitThread();

                UnityAssets.MainForm = mainForm;
            };
        }
    }
}
