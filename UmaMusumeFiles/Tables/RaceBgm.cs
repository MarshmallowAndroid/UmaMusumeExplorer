using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UmaMusumeFiles.Tables
{
    [Table("race_bgm")]
    public class RaceBgm
    {
        [Column("id"), PrimaryKey]
        public int Id { get; set; }

        [Column("paddock_bgm_cue_name")]
        public string PaddockBgmCueName { get; set; } = "";
        [Column("paddock_bgm_cuesheet_name")]
        public string PaddockBgmCuesheetName { get; set; } = "";

        [Column("entrytable_bgm_cue_name")]
        public string EntryTableBgmCueName { get; set; } = "";
        [Column("entrytable_bgm_cuesheet_name")]
        public string EntryTableBgmCuesheetName { get; set; } = "";

        [Column("first_bgm_pattern")]
        public int FirstBgmPattern { get; set; }
        [Column("second_bgm_pattern")]
        public int SecondBgmPattern { get; set; }

        [Column("result_cutin_bgm_cue_name_1")]
        public string ResultCutInBgmCueName1 { get; set; } = "";
        [Column("result_cutin_bgm_cue_name_2")]
        public string ResultCutInBgmCueName2 { get; set; } = "";
        [Column("result_cutin_bgm_cue_name_3")]
        public string ResultCutInBgmCueName3 { get; set; } = "";
        [Column("result_cutin_bgm_cuesheet_name_1")]
        public string ResultCutInBgmCuesheetName1 { get; set; } = "";
        [Column("result_cutin_bgm_cuesheet_name_2")]
        public string ResultCutInBgmCuesheetName2 { get; set; } = "";
        [Column("result_cutin_bgm_cuesheet_name_3")]
        public string ResultCutInBgmCuesheetName3 { get; set; } = "";
        [Column("result_list_bgm_cue_name_1")]
        public string ResultListBgmCueName1 { get; set; } = "";
        [Column("result_list_bgm_cue_name_2")]
        public string ResultListBgmCueName2 { get; set; } = "";
        [Column("result_list_bgm_cue_name_3")]
        public string ResultListBgmCueName3 { get; set; } = "";
        [Column("result_list_bgm_cuesheet_name_1")]
        public string ResultListBgmCuesheetName1 { get; set; } = "";
        [Column("result_list_bgm_cuesheet_name_2")]
        public string ResultListBgmCuesheetName2 { get; set; } = "";
        [Column("result_list_bgm_cuesheet_name_3")]
        public string ResultListBgmCuesheetName3 { get; set; } = "";
    }
}
