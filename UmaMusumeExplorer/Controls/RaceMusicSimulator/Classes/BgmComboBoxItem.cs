using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Controls.RaceMusicSimulator.Classes
{
    public class BgmComboBoxItem
    {
        public RaceBgm RaceBgm { get; set; }

        public override string ToString()
        {
            return RaceBgm.ID.ToString();
        }
    }
}
