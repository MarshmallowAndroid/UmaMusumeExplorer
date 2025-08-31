using SQLite;

namespace UmamsumeData.Tables
{
    [Table("character_system_text")]
    public class CharacterSystemText
    {
        [Column("character_id"), NotNull, PrimaryKey]
        public int CharacterId { get; set; }

        [Column("voice_id"), NotNull, PrimaryKey]
        public int VoiceId { get; set; }

        [Column("text"), NotNull]
        public string Text { get; set; } = "";

        [Column("cue_sheet"), NotNull]
        public string CueSheet { get; set; } = "";

        [Column("cue_id"), NotNull]
        public int CueId { get; set; }

        [Column("motion_set"), NotNull]
        public int MotionSet { get; set; }

        [Column("scene"), NotNull]
        public int Scene { get; set; }

        [Column("use_gallery"), NotNull]
        public int UseGallery { get; set; }

        [Column("card_id"), NotNull]
        public int CardId { get; set; }

        [Column("lip_sync_data"), NotNull]
        public string LipSyncData { get; set; } = "";

        [Column("gender"), NotNull]
        public int Gender { get; set; }

        [Column("motion_second_set"), NotNull]
        public int MotionSecondSet { get; set; }

        [Column("motion_second_start"), NotNull]
        public int MotionSecondStart { get; set; }

        [Column("start_date"), NotNull]
        public int StartDate { get; set; }
    }
}