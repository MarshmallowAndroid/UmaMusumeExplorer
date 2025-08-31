using SQLite;

namespace UmamsumeData.Tables
{
    [Table("available_skill_set")]
    public class AvailableSkillSet
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("available_skill_set_id"), NotNull]
        public int AvailableSkillSetId { get; set; }

        [Column("skill_id"), NotNull]
        public int SkillId { get; set; }

        [Column("need_rank"), NotNull]
        public int NeedRank { get; set; }
    }
}