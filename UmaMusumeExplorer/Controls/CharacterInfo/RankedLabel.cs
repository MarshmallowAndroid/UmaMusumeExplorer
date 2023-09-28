using System.ComponentModel;
using Color = System.Drawing.Color;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class RankedLabel : UserControl
    {
        private Rank rank;

        public RankedLabel()
        {
            InitializeComponent();

            Rank = Rank.Unknown;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.All)]
        public Rank Rank
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
                    case Rank.G:
                        rankLabel.Text = "G";
                        rankLabel.ForeColor = Color.DarkGray;
                        break;
                    case Rank.F:
                        rankLabel.Text = "F";
                        rankLabel.ForeColor = Color.SlateBlue;
                        break;
                    case Rank.E:
                        rankLabel.Text = "E";
                        rankLabel.ForeColor = Color.DarkViolet;
                        break;
                    case Rank.D:
                        rankLabel.Text = "D";
                        rankLabel.ForeColor = Color.DeepSkyBlue;
                        break;
                    case Rank.C:
                        rankLabel.Text = "C";
                        rankLabel.ForeColor = Color.LimeGreen;
                        break;
                    case Rank.B:
                        rankLabel.Text = "B";
                        rankLabel.ForeColor = Color.HotPink;
                        break;
                    case Rank.A:
                        rankLabel.Text = "A";
                        rankLabel.ForeColor = Color.OrangeRed;
                        break;
                    case Rank.S:
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
    }
}
