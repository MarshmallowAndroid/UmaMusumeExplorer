﻿using UmaMusumeFiles.Tables;

namespace UmaMusumeExplorer.Controls.RaceMusicSimulator
{
    public class BgmComboBoxItem
    {
        public RaceBgm RaceBgm { get; set; }

        public override string ToString()
        {
            return RaceBgm.Id.ToString();
        }
    }
}
