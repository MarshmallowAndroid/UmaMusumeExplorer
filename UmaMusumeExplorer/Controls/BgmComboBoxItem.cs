using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Controls
{
    public class BgmComboBoxItem
    {
        public RaceBgm? RaceBgm { get; set; }

        public override string ToString()
        {
            return RaceBgm?.Id.ToString() ?? "";
        }
    }
}
