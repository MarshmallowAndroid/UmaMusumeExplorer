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
        [Column("id")]
        public int Id { get; set; }

        [Column("race_type")]
        public int RaceType { get; set; }

        [Column("race_instance_id")]
        public int RaceInstanceId { get; set; }

        [Column("grade")]
        public int Grade { get; set; }

        [Column("single_mode_route_race_id")]
        public int SingleModeRouteRaceId { get; set; }

        [Column("single_mode_program_id")]
        public int SingleModeProgramId { get; set; }

        [Column("paddock_bgm_cue_name")]
        public string PaddockBgmCueName { get; set; } = "";

        [Column("paddock_bgm_cuesheet_name")]
        public string PaddockBgmCuesheetName { get; set; } = "";

        [Column("entrytable_bgm_cue_name")]
        public string EntrytableBgmCueName { get; set; } = "";

        [Column("entrytable_bgm_cuesheet_name")]
        public string EntrytableBgmCuesheetName { get; set; } = "";

        [Column("first_bgm_pattern")]
        public int FirstBgmPattern { get; set; }

        [Column("second_bgm_pattern")]
        public int SecondBgmPattern { get; set; }

        [Column("result_cutin_bgm_cue_name_1")]
        public string ResultCutinBgmCueName1 { get; set; } = "";

        [Column("result_cutin_bgm_cuesheet_name_1")]
        public string ResultCutinBgmCuesheetName1 { get; set; } = "";

        [Column("result_cutin_bgm_cue_name_2")]
        public string ResultCutinBgmCueName2 { get; set; } = "";

        [Column("result_cutin_bgm_cuesheet_name_2")]
        public string ResultCutinBgmCuesheetName2 { get; set; } = "";

        [Column("result_cutin_bgm_cue_name_3")]
        public string ResultCutinBgmCueName3 { get; set; } = "";

        [Column("result_cutin_bgm_cuesheet_name_3")]
        public string ResultCutinBgmCuesheetName3 { get; set; } = "";

        [Column("result_list_bgm_cue_name_1")]
        public string ResultListBgmCueName1 { get; set; } = "";

        [Column("result_list_bgm_cuesheet_name_1")]
        public string ResultListBgmCuesheetName1 { get; set; } = "";

        [Column("result_list_bgm_cue_name_2")]
        public string ResultListBgmCueName2 { get; set; } = "";

        [Column("result_list_bgm_cuesheet_name_2")]
        public string ResultListBgmCuesheetName2 { get; set; } = "";

        [Column("result_list_bgm_cue_name_3")]
        public string ResultListBgmCueName3 { get; set; } = "";

        [Column("result_list_bgm_cuesheet_name_3")]
        public string ResultListBgmCuesheetName3 { get; set; } = "";
    }
}
