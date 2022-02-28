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
    public partial class RankedLabel : UserControl
    {
        private RankedLabelRank rank;

        public RankedLabel()
        {
            InitializeComponent();
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
                        break;
                    case RankedLabelRank.F:
                        rankLabel.Text = "F";
                        break;
                    case RankedLabelRank.E:
                        rankLabel.Text = "E";
                        break;
                    case RankedLabelRank.D:
                        rankLabel.Text = "D";
                        break;
                    case RankedLabelRank.C:
                        rankLabel.Text = "C";
                        break;
                    case RankedLabelRank.B:
                        rankLabel.Text = "B";
                        break;
                    case RankedLabelRank.A:
                        rankLabel.Text = "A";
                        break;
                    case RankedLabelRank.S:
                        rankLabel.Text = "S";
                        break;
                    default:
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
