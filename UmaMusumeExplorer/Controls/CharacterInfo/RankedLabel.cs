using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeExplorer.Controls.CharacterInfo.Classes;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class RankedLabel : UserControl
    {
        private RankedLabelRank rank;

        public RankedLabel()
        {
            InitializeComponent();

            Rank = RankedLabelRank.Unknown;
        }

        public RankedLabelRank Rank
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
                    case RankedLabelRank.G:
                        rankLabel.Text = "G";
                        rankLabel.ForeColor = Color.DarkGray;
                        break;
                    case RankedLabelRank.F:
                        rankLabel.Text = "F";
                        rankLabel.ForeColor = Color.SlateBlue;
                        break;
                    case RankedLabelRank.E:
                        rankLabel.Text = "E";
                        rankLabel.ForeColor = Color.DarkViolet;
                        break;
                    case RankedLabelRank.D:
                        rankLabel.Text = "D";
                        rankLabel.ForeColor = Color.DeepSkyBlue;
                        break;
                    case RankedLabelRank.C:
                        rankLabel.Text = "C";
                        rankLabel.ForeColor = Color.LimeGreen;
                        break;
                    case RankedLabelRank.B:
                        rankLabel.Text = "B";
                        rankLabel.ForeColor = Color.HotPink;
                        break;
                    case RankedLabelRank.A:
                        rankLabel.Text = "A";
                        rankLabel.ForeColor = Color.OrangeRed;
                        break;
                    case RankedLabelRank.S:
                        rankLabel.Text = "S";
                        rankLabel.ForeColor = Color.Goldenrod;
                        break;
                    default:
                        rankLabel.Text = "?";
                        rankLabel.ForeColor = Color.Black;
                        break;
                }

                Update();
            }
        }

        //public override string Text { get => base.Text; set => base.Text = value; }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return textLabel.Text;
            }
            set
            {
                textLabel.Text = value;
                Update();
            }
        }
    }
}
