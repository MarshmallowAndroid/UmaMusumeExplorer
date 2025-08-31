using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Color = System.Drawing.Color;

namespace UmamusumeExplorer.Controls
{
    partial class RankedLabel : UserControl
    {
        private AptitudeRank rank;

        public RankedLabel()
        {
            InitializeComponent();

            Rank = AptitudeRank.Unknown;
        }

        public AptitudeRank Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;

                switch (rank)
                {
                    case AptitudeRank.G:
                        rankLabel.Text = "G";
                        rankLabel.ForeColor = Color.DarkGray;
                        break;
                    case AptitudeRank.F:
                        rankLabel.Text = "F";
                        rankLabel.ForeColor = Color.SlateBlue;
                        break;
                    case AptitudeRank.E:
                        rankLabel.Text = "E";
                        rankLabel.ForeColor = Color.DarkViolet;
                        break;
                    case AptitudeRank.D:
                        rankLabel.Text = "D";
                        rankLabel.ForeColor = Color.DeepSkyBlue;
                        break;
                    case AptitudeRank.C:
                        rankLabel.Text = "C";
                        rankLabel.ForeColor = Color.LimeGreen;
                        break;
                    case AptitudeRank.B:
                        rankLabel.Text = "B";
                        rankLabel.ForeColor = Color.HotPink;
                        break;
                    case AptitudeRank.A:
                        rankLabel.Text = "A";
                        rankLabel.ForeColor = Color.OrangeRed;
                        break;
                    case AptitudeRank.S:
                        rankLabel.Text = "S";
                        rankLabel.ForeColor = Color.Goldenrod;
                        break;
                    default:
                        rankLabel.Text = "?";
                        rankLabel.ForeColor = Color.Black;
                        break;
                }

                Invalidate();
            }
        }

        //public override string Text { get => base.Text; set => base.Text = value; }

        public string LabelText
        {
            get
            {
                return textLabel.Text;
            }
            set
            {
                textLabel.Text = value;
                Invalidate();
            }
        }
    }
}
