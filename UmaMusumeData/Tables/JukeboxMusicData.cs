using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("jukebox_music_data")]
    public class JukeboxMusicData
    {
        [Column("music_id"), NotNull, PrimaryKey]
        public int MusicId { get; set; }

        [Column("sort"), NotNull]
        public int Sort { get; set; }

        [Column("condition_type"), NotNull]
        public int ConditionType { get; set; }

        [Column("is_hidden"), NotNull]
        public int IsHidden { get; set; }

        [Column("version_type"), NotNull]
        public int VersionType { get; set; }

        [Column("request_type"), NotNull]
        public int RequestType { get; set; }

        [Column("lamp_color"), NotNull]
        public int LampColor { get; set; }

        [Column("lamp_animation"), NotNull]
        public int LampAnimation { get; set; }

        [Column("name_texture_length"), NotNull]
        public int NameTextureLength { get; set; }

        [Column("song_type"), NotNull]
        public int SongType { get; set; }

        [Column("bgm_cue_name_short"), NotNull]
        public string BgmCueNameShort { get; set; } = "";

        [Column("bgm_cuesheet_name_short"), NotNull]
        public string BgmCuesheetNameShort { get; set; } = "";

        [Column("bgm_cue_name_gamesize"), NotNull]
        public string BgmCueNameGamesize { get; set; } = "";

        [Column("bgm_cuesheet_name_gamesize"), NotNull]
        public string BgmCuesheetNameGamesize { get; set; } = "";

        [Column("short_length"), NotNull]
        public int ShortLength { get; set; }

        [Column("alter_jacket"), NotNull]
        public int AlterJacket { get; set; }

        [Column("start_date"), NotNull]
        public int StartDate { get; set; }

        [Column("end_date"), NotNull]
        public int EndDate { get; set; }
    }
}