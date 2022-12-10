using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("skill_set")]
    public class SkillSet
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("skill_id1"), NotNull]
        public int SkillId1 { get; set; }

        [Column("skill_level1"), NotNull]
        public int SkillLevel1 { get; set; }

        [Column("skill_id2"), NotNull]
        public int SkillId2 { get; set; }

        [Column("skill_level2"), NotNull]
        public int SkillLevel2 { get; set; }

        [Column("skill_id3"), NotNull]
        public int SkillId3 { get; set; }

        [Column("skill_level3"), NotNull]
        public int SkillLevel3 { get; set; }

        [Column("skill_id4"), NotNull]
        public int SkillId4 { get; set; }

        [Column("skill_level4"), NotNull]
        public int SkillLevel4 { get; set; }

        [Column("skill_id5"), NotNull]
        public int SkillId5 { get; set; }

        [Column("skill_level5"), NotNull]
        public int SkillLevel5 { get; set; }

        [Column("skill_id6"), NotNull]
        public int SkillId6 { get; set; }

        [Column("skill_level6"), NotNull]
        public int SkillLevel6 { get; set; }

        [Column("skill_id7"), NotNull]
        public int SkillId7 { get; set; }

        [Column("skill_level7"), NotNull]
        public int SkillLevel7 { get; set; }

        [Column("skill_id8"), NotNull]
        public int SkillId8 { get; set; }

        [Column("skill_level8"), NotNull]
        public int SkillLevel8 { get; set; }

        [Column("skill_id9"), NotNull]
        public int SkillId9 { get; set; }

        [Column("skill_level9"), NotNull]
        public int SkillLevel9 { get; set; }

        [Column("skill_id10"), NotNull]
        public int SkillId10 { get; set; }

        [Column("skill_level10"), NotNull]
        public int SkillLevel10 { get; set; }
    }
}