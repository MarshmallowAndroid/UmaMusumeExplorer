using System.ComponentModel;
using System.Drawing;
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

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
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

                Invalidate();
            }
        }

        //public override string Text { get => base.Text; set => base.Text = value; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        public override string Text
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

        public enum RankedLabelRank
        {
            Unknown,
            G,
            F,
            E,
            D,
            C,
            B,
            A,
            S
        }
    }
}
