using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("live_data")]
    public class LiveData
    {
        [Column("music_id"), NotNull, PrimaryKey]
        public int MusicId { get; set; }

        [Column("sort"), NotNull]
        public int Sort { get; set; }

        [Column("music_type"), NotNull]
        public int MusicType { get; set; }

        [Column("title_color_top"), NotNull]
        public string TitleColorTop { get; set; } = "";

        [Column("title_color_bottom"), NotNull]
        public string TitleColorBottom { get; set; } = "";

        [Column("condition_type"), NotNull]
        public int ConditionType { get; set; }

        [Column("song_chara_type"), NotNull]
        public int SongCharaType { get; set; }

        [Column("live_member_number"), NotNull]
        public int LiveMemberNumber { get; set; }

        [Column("default_main_dress"), NotNull]
        public int DefaultMainDress { get; set; }

        [Column("default_main_dress_color"), NotNull]
        public int DefaultMainDressColor { get; set; }

        [Column("default_mob_dress"), NotNull]
        public int DefaultMobDress { get; set; }

        [Column("default_mob_dress_color"), NotNull]
        public int DefaultMobDressColor { get; set; }

        [Column("backdancer_order"), NotNull]
        public int BackdancerOrder { get; set; }

        [Column("backdancer_dress"), NotNull]
        public int BackdancerDress { get; set; }

        [Column("backdancer_dress_color"), NotNull]
        public int BackdancerDressColor { get; set; }

        [Column("has_live"), NotNull]
        public int HasLive { get; set; }

        [Column("start_date"), NotNull]
        public int StartDate { get; set; }

        [Column("end_date"), NotNull]
        public int EndDate { get; set; }
    }
}
