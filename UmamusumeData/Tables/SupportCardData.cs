using SQLite;

namespace UmamsumeData.Tables
{
    [Table("support_card_data")]
    public class SupportCardData
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("chara_id"), NotNull]
        public int CharaId { get; set; }

        [Column("rarity"), NotNull]
        public int Rarity { get; set; }

        [Column("exchange_item_id"), NotNull]
        public int ExchangeItemId { get; set; }

        [Column("effect_table_id"), NotNull]
        public int EffectTableId { get; set; }

        [Column("unique_effect_id"), NotNull]
        public int UniqueEffectId { get; set; }

        [Column("command_type"), NotNull]
        public int CommandType { get; set; }

        [Column("command_id"), NotNull]
        public int CommandId { get; set; }

        [Column("support_card_type"), NotNull]
        public int SupportCardType { get; set; }

        [Column("skill_set_id"), NotNull]
        public int SkillSetId { get; set; }

        [Column("detail_pos_x"), NotNull]
        public int DetailPosX { get; set; }

        [Column("detail_pos_y"), NotNull]
        public int DetailPosY { get; set; }

        [Column("detail_scale"), NotNull]
        public int DetailScale { get; set; }

        [Column("detail_rot_z"), NotNull]
        public int DetailRotZ { get; set; }

        [Column("start_date"), NotNull]
        public int StartDate { get; set; }

        [Column("outing_max"), NotNull]
        public int OutingMax { get; set; }

        [Column("effect_id"), NotNull]
        public int EffectId { get; set; }
    }
}