using SQLite;

namespace UmamsumeData.Tables
{
    [Table("skill_upgrade_description")]
    public class SkillUpgradeDescription
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("card_id"), NotNull, Unique]
        public int CardId { get; set; }

        [Column("rank"), NotNull]
        public int Rank { get; set; }

        [Column("skill_id"), NotNull, Unique]
        public int SkillId { get; set; }

        [Column("start_date"), NotNull]
        public int StartDate { get; set; }
    }
}