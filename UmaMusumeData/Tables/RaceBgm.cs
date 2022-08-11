using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("race_bgm")]
    public class RaceBgm
    {
        [Column("id"), NotNull, PrimaryKey]
        public int ID { get; set; }

        [Column("race_type"), NotNull]
        public int RaceType { get; set; }

        [Column("race_instance_id"), NotNull]
        public int RaceInstanceID { get; set; }

        [Column("grade"), NotNull]
        public int Grade { get; set; }

        [Column("single_mode_route_race_id"), NotNull]
        public int SingleModeRouteRaceID { get; set; }

        [Column("single_mode_program_id"), NotNull]
        public int SingleModeProgramID { get; set; }

        [Column("paddock_bgm_cue_name"), NotNull]
        public string PaddockBgmCueName { get; set; } = "";

        [Column("paddock_bgm_cuesheet_name"), NotNull]
        public string PaddockBgmCuesheetName { get; set; } = "";

        [Column("entrytable_bgm_cue_name"), NotNull]
        public string EntrytableBgmCueName { get; set; } = "";

        [Column("entrytable_bgm_cuesheet_name"), NotNull]
        public string EntrytableBgmCuesheetName { get; set; } = "";

        [Column("first_bgm_pattern"), NotNull]
        public int FirstBgmPattern { get; set; }

        [Column("second_bgm_pattern"), NotNull]
        public int SecondBgmPattern { get; set; }

        [Column("result_cutin_bgm_cue_name_1"), NotNull]
        public string ResultCutinBgmCueName1 { get; set; } = "";

        [Column("result_cutin_bgm_cuesheet_name_1"), NotNull]
        public string ResultCutinBgmCuesheetName1 { get; set; } = "";

        [Column("result_cutin_bgm_cue_name_2"), NotNull]
        public string ResultCutinBgmCueName2 { get; set; } = "";

        [Column("result_cutin_bgm_cuesheet_name_2"), NotNull]
        public string ResultCutinBgmCuesheetName2 { get; set; } = "";

        [Column("result_cutin_bgm_cue_name_3"), NotNull]
        public string ResultCutinBgmCueName3 { get; set; } = "";

        [Column("result_cutin_bgm_cuesheet_name_3"), NotNull]
        public string ResultCutinBgmCuesheetName3 { get; set; } = "";

        [Column("result_list_bgm_cue_name_1"), NotNull]
        public string ResultListBgmCueName1 { get; set; } = "";

        [Column("result_list_bgm_cuesheet_name_1"), NotNull]
        public string ResultListBgmCuesheetName1 { get; set; } = "";

        [Column("result_list_bgm_cue_name_2"), NotNull]
        public string ResultListBgmCueName2 { get; set; } = "";

        [Column("result_list_bgm_cuesheet_name_2"), NotNull]
        public string ResultListBgmCuesheetName2 { get; set; } = "";

        [Column("result_list_bgm_cue_name_3"), NotNull]
        public string ResultListBgmCueName3 { get; set; } = "";

        [Column("result_list_bgm_cuesheet_name_3"), NotNull]
        public string ResultListBgmCuesheetName3 { get; set; } = "";
    }
}
