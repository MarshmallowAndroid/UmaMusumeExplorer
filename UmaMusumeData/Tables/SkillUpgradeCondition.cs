using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("skill_upgrade_condition")]
    public class SkillUpgradeCondition
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("upgrade_type"), NotNull]
        public int UpgradeType { get; set; }

        [Column("description_id"), NotNull, Unique]
        public int DescriptionId { get; set; }

        [Column("num"), NotNull, Unique]
        public int Num { get; set; }

        [Column("sub_num"), NotNull, Unique]
        public int SubNum { get; set; }

        [Column("timing_type"), NotNull]
        public int TimingType { get; set; }

        [Column("count_type"), NotNull]
        public int CountType { get; set; }
    }

}