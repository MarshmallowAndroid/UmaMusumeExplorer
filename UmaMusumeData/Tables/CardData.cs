using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("card_data")]
    public class CardData
    {
        [Column("id"), NotNull, PrimaryKey]
        public int ID { get; set; }

        [Column("chara_id"), NotNull]
        public int CharaID { get; set; }

        [Column("default_rarity"), NotNull]
        public int DefaultRarity { get; set; }

        [Column("limited_chara"), NotNull]
        public int LimitedChara { get; set; }

        [Column("available_skill_set_id"), NotNull]
        public int AvailableSkillSetID { get; set; }

        [Column("talent_speed"), NotNull]
        public int TalentSpeed { get; set; }
        [Column("talent_stamina"), NotNull]
        public int TalentStamina { get; set; }
        [Column("talent_pow"), NotNull]
        public int TalentPow { get; set; }
        [Column("talent_guts"), NotNull]
        public int TalentGuts { get; set; }
        [Column("talent_wiz"), NotNull]
        public int TalentWiz { get; set; }

        [Column("talent_group_id"), NotNull]
        public int TalentGroupID { get; set; }

        [Column("bg_id"), NotNull]
        public int BgID { get; set; }

        [Column("get_piece_id"), NotNull]
        public int GetPieceID { get; set; }

        [Column("running_style"), NotNull]
        public int RunningStyle { get; set; }
    }
}
