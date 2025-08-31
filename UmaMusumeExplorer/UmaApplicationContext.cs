using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmaMusumeData;
using UmaMusumeExplorer.Assets;

namespace UmaMusumeExplorer
{
    class UmaApplicationContext : ApplicationContext
    {
        private const string pathTextFile = "UmaMusumePath.txt";

        public UmaApplicationContext()
        {
            if (File.Exists(pathTextFile))
                UmaDataHelper.UmaMusumeDirectory = File.ReadAllText(pathTextFile).Trim();

            if (!UmaDataHelper.CheckDirectory())
            {
                DialogResult result = MessageBox.Show(
                    "Unable to find the required files in the default data directory.\n" +
                    "If you have not installed, launched, or updated the game, please do so.\n\n" +
                    "Otherwise, you must specify the directory if you have changed the installation location.\n\n" +
                    "Would you like to continue?",
                    "Missing files",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    while (true)
                    {
                        FolderBrowserDialog browserDialog = new();
                        DialogResult browseResult = browserDialog.ShowDialog();

                        if (browseResult == DialogResult.OK)
                        {
                            UmaDataHelper.UmaMusumeDirectory = browserDialog.SelectedPath;

                            if (UmaDataHelper.CheckDirectory())
                            {
                                File.WriteAllText(pathTextFile, UmaDataHelper.UmaMusumeDirectory);
                                break;
                            }

                            MessageBox.Show("Please select a valid data directory containing the \"dat\" folder, " +
                                "the \"meta\" file, and the \"master\" folder with the \"master.mdb\" file.",
                                "Missing files",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            Environment.Exit(1);
                            return;
                        }
                    }
                }
                else
                {
                    Environment.Exit(1);
                    return;
                }
            }

            SplashForm splashForm = new();
            if (splashForm.LoadAndClose())
            {
                MainForm mainForm = new();
                mainForm.Show();
                MainForm = mainForm;
                //mainForm.FormClosed += (s, e) => ExitThread();

                GameAssets.MainForm = mainForm;
            }
        }
    }
}
