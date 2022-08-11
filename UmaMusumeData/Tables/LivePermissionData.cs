using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("live_permission_data")]
    public class LivePermissionData
    {
        [Column("music_id"), NotNull, PrimaryKey]
        public int MusicId { get; set; }

        [Column("chara_id"), NotNull, PrimaryKey]
        public int CharaId { get; set; }
    }
}
