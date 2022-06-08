using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class StatusDisplayLabel : UserControl
    {
        private int statusValue = 50;
        private int statusMaxValue = 1200;

        public StatusDisplayLabel()
        {
            InitializeComponent();
        }

        public int Value
        {
            get { return statusValue; }
            set
            {
                statusValue = value;
                statusValueLabel.Text = statusValue.ToString();

                Font currentFont = statusValueLabel.Font;

                if (statusValue >= 1000)
                    statusValueLabel.Font = new Font(currentFont.FontFamily, 12.0f);
                else
                    statusValueLabel.Font = new Font(currentFont.FontFamily, 16.0f);

                if (InRange(statusValue, 0, 49))
                    statusRankLabel.Text = "G";
                else if (InRange(statusValue, 50, 99))
                    statusRankLabel.Text = "G+";
                else if (InRange(statusValue, 100, 149))
                    statusRankLabel.Text = "F";
                else if (InRange(statusValue, 150, 199))
                    statusRankLabel.Text = "F+";
                else if (InRange(statusValue, 200, 249))
                    statusRankLabel.Text = "E";
                else if (InRange(statusValue, 250, 299))
                    statusRankLabel.Text = "E+";
                else if (InRange(statusValue, 300, 349))
                    statusRankLabel.Text = "D";
                else if (InRange(statusValue, 350, 399))
                    statusRankLabel.Text = "D+";
                else if (InRange(statusValue, 400, 499))
                    statusRankLabel.Text = "C";
                else if (InRange(statusValue, 500, 599))
                    statusRankLabel.Text = "C+";
                else if (InRange(statusValue, 600, 699))
                    statusRankLabel.Text = "B";
                else if (InRange(statusValue, 700, 799))
                    statusRankLabel.Text = "B+";
                else if (InRange(statusValue, 800, 899))
                    statusRankLabel.Text = "A";
                else if (InRange(statusValue, 900, 999))
                    statusRankLabel.Text = "A+";
                else if (InRange(statusValue, 1000, 1049))
                    statusRankLabel.Text = "S";
                else if (InRange(statusValue, 1050, 1099))
                    statusRankLabel.Text = "S+";
                else if (InRange(statusValue, 1100, 1199))
                    statusRankLabel.Text = "SS";
                else if (InRange(statusValue, 1200, 1200))
                    statusRankLabel.Text = "SS+";

                switch (statusRankLabel.Text[0])
                {
                    case 'G':
                        statusRankLabel.ForeColor = Color.DarkGray;
                        break;
                    case 'F':
                        statusRankLabel.ForeColor = Color.SlateBlue;
                        break;
                    case 'E':
                        statusRankLabel.ForeColor = Color.DarkViolet;
                        break;
                    case 'D':
                        statusRankLabel.ForeColor = Color.DeepSkyBlue;
                        break;
                    case 'C':
                        statusRankLabel.ForeColor = Color.LimeGreen;
                        break;
                    case 'B':
                        statusRankLabel.ForeColor = Color.HotPink;
                        break;
                    case 'A':
                        statusRankLabel.ForeColor = Color.OrangeRed;
                        break;
                    case 'S':
                        statusRankLabel.ForeColor = Color.Goldenrod;
                        break;
                    default:
                        break;
                }

                Update();
            }
        }

        public int MaxValue
        {
            get { return statusMaxValue; }
            set
            {
                statusMaxValue = value;
                statusMaxValueLabel.Text = "/" + statusMaxValue.ToString();
                Update();
            }
        }

        private static bool InRange(int value, int min, int max)
        {
            return (value >= min) && (value <= max);
        }
    }
}
