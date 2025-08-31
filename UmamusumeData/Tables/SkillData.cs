using SQLite;

namespace UmamsumeData.Tables
{
    [Table("skill_data")]
    public class SkillData
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("rarity"), NotNull]
        public int Rarity { get; set; }

        [Column("group_id"), NotNull]
        public int GroupId { get; set; }

        [Column("group_rate"), NotNull]
        public int GroupRate { get; set; }

        [Column("filter_switch"), NotNull]
        public int FilterSwitch { get; set; }

        [Column("grade_value"), NotNull]
        public int GradeValue { get; set; }

        [Column("skill_category"), NotNull]
        public int SkillCategory { get; set; }

        [Column("tag_id"), NotNull]
        public string TagId { get; set; } = "";

        [Column("unique_skill_id_1"), NotNull]
        public int UniqueSkillId1 { get; set; }

        [Column("unique_skill_id_2"), NotNull]
        public int UniqueSkillId2 { get; set; }

        [Column("exp_type"), NotNull]
        public int ExpType { get; set; }

        [Column("potential_per_default"), NotNull]
        public int PotentialPerDefault { get; set; }

        [Column("activate_lot"), NotNull]
        public int ActivateLot { get; set; }

        [Column("precondition_1"), NotNull]
        public string Precondition1 { get; set; } = "";

        [Column("condition_1"), NotNull]
        public string Condition1 { get; set; } = "";

        [Column("float_ability_time_1"), NotNull]
        public int FloatAbilityTime1 { get; set; }

        [Column("ability_time_usage_1"), NotNull]
        public int AbilityTimeUsage1 { get; set; }

        [Column("float_cooldown_time_1"), NotNull]
        public int FloatCooldownTime1 { get; set; }

        [Column("ability_type_1_1"), NotNull]
        public int AbilityType11 { get; set; }

        [Column("ability_value_usage_1_1"), NotNull]
        public int AbilityValueUsage11 { get; set; }

        [Column("additional_activate_type_1_1"), NotNull]
        public int AdditionalActivateType11 { get; set; }

        [Column("ability_value_level_usage_1_1"), NotNull]
        public int AbilityValueLevelUsage11 { get; set; }

        [Column("float_ability_value_1_1"), NotNull]
        public int FloatAbilityValue11 { get; set; }

        [Column("target_type_1_1"), NotNull]
        public int TargetType11 { get; set; }

        [Column("target_value_1_1"), NotNull]
        public int TargetValue11 { get; set; }

        [Column("ability_type_1_2"), NotNull]
        public int AbilityType12 { get; set; }

        [Column("ability_value_usage_1_2"), NotNull]
        public int AbilityValueUsage12 { get; set; }

        [Column("additional_activate_type_1_2"), NotNull]
        public int AdditionalActivateType12 { get; set; }

        [Column("ability_value_level_usage_1_2"), NotNull]
        public int AbilityValueLevelUsage12 { get; set; }

        [Column("float_ability_value_1_2"), NotNull]
        public int FloatAbilityValue12 { get; set; }

        [Column("target_type_1_2"), NotNull]
        public int TargetType12 { get; set; }

        [Column("target_value_1_2"), NotNull]
        public int TargetValue12 { get; set; }

        [Column("ability_type_1_3"), NotNull]
        public int AbilityType13 { get; set; }

        [Column("ability_value_usage_1_3"), NotNull]
        public int AbilityValueUsage13 { get; set; }

        [Column("additional_activate_type_1_3"), NotNull]
        public int AdditionalActivateType13 { get; set; }

        [Column("ability_value_level_usage_1_3"), NotNull]
        public int AbilityValueLevelUsage13 { get; set; }

        [Column("float_ability_value_1_3"), NotNull]
        public int FloatAbilityValue13 { get; set; }

        [Column("target_type_1_3"), NotNull]
        public int TargetType13 { get; set; }

        [Column("target_value_1_3"), NotNull]
        public int TargetValue13 { get; set; }

        [Column("precondition_2"), NotNull]
        public string Precondition2 { get; set; } = "";

        [Column("condition_2"), NotNull]
        public string Condition2 { get; set; } = "";

        [Column("float_ability_time_2"), NotNull]
        public int FloatAbilityTime2 { get; set; }

        [Column("ability_time_usage_2"), NotNull]
        public int AbilityTimeUsage2 { get; set; }

        [Column("float_cooldown_time_2"), NotNull]
        public int FloatCooldownTime2 { get; set; }

        [Column("ability_type_2_1"), NotNull]
        public int AbilityType21 { get; set; }

        [Column("ability_value_usage_2_1"), NotNull]
        public int AbilityValueUsage21 { get; set; }

        [Column("additional_activate_type_2_1"), NotNull]
        public int AdditionalActivateType21 { get; set; }

        [Column("ability_value_level_usage_2_1"), NotNull]
        public int AbilityValueLevelUsage21 { get; set; }

        [Column("float_ability_value_2_1"), NotNull]
        public int FloatAbilityValue21 { get; set; }

        [Column("target_type_2_1"), NotNull]
        public int TargetType21 { get; set; }

        [Column("target_value_2_1"), NotNull]
        public int TargetValue21 { get; set; }

        [Column("ability_type_2_2"), NotNull]
        public int AbilityType22 { get; set; }

        [Column("ability_value_usage_2_2"), NotNull]
        public int AbilityValueUsage22 { get; set; }

        [Column("additional_activate_type_2_2"), NotNull]
        public int AdditionalActivateType22 { get; set; }

        [Column("ability_value_level_usage_2_2"), NotNull]
        public int AbilityValueLevelUsage22 { get; set; }

        [Column("float_ability_value_2_2"), NotNull]
        public int FloatAbilityValue22 { get; set; }

        [Column("target_type_2_2"), NotNull]
        public int TargetType22 { get; set; }

        [Column("target_value_2_2"), NotNull]
        public int TargetValue22 { get; set; }

        [Column("ability_type_2_3"), NotNull]
        public int AbilityType23 { get; set; }

        [Column("ability_value_usage_2_3"), NotNull]
        public int AbilityValueUsage23 { get; set; }

        [Column("additional_activate_type_2_3"), NotNull]
        public int AdditionalActivateType23 { get; set; }

        [Column("ability_value_level_usage_2_3"), NotNull]
        public int AbilityValueLevelUsage23 { get; set; }

        [Column("float_ability_value_2_3"), NotNull]
        public int FloatAbilityValue23 { get; set; }

        [Column("target_type_2_3"), NotNull]
        public int TargetType23 { get; set; }

        [Column("target_value_2_3"), NotNull]
        public int TargetValue23 { get; set; }

        [Column("popularity_add_param_1"), NotNull]
        public int PopularityAddParam1 { get; set; }

        [Column("popularity_add_value_1"), NotNull]
        public int PopularityAddValue1 { get; set; }

        [Column("popularity_add_param_2"), NotNull]
        public int PopularityAddParam2 { get; set; }

        [Column("popularity_add_value_2"), NotNull]
        public int PopularityAddValue2 { get; set; }

        [Column("disp_order"), NotNull]
        public int DispOrder { get; set; }

        [Column("icon_id"), NotNull]
        public int IconId { get; set; }

        [Column("plate_type"), NotNull]
        public int PlateType { get; set; }

        [Column("disable_singlemode"), NotNull]
        public int DisableSinglemode { get; set; }

        [Column("disable_count_condition"), NotNull]
        public int DisableCountCondition { get; set; }

        [Column("is_general_skill"), NotNull]
        public int IsGeneralSkill { get; set; }

        [Column("start_date"), NotNull]
        public int StartDate { get; set; }

        [Column("end_date"), NotNull]
        public int EndDate { get; set; }
    }
}