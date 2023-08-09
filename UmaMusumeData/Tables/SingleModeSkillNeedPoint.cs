using SQLite;

[Table("single_mode_skill_need_point")]
public class SingleModeSkillNeedPoint
{
    [Column("id"), NotNull, PrimaryKey]
    public int Id { get; set; }

    [Column("need_skill_point"), NotNull]
    public int NeedSkillPoint { get; set; }

    [Column("status_type"), NotNull]
    public int StatusType { get; set; }

    [Column("status_value"), NotNull]
    public int StatusValue { get; set; }

    [Column("solvable_type"), NotNull]
    public int SolvableType { get; set; }
}
