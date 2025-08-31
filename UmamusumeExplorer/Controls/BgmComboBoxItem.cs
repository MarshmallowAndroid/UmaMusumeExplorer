using UmamsumeData.Tables;

namespace UmamusumeExplorer.Controls
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
