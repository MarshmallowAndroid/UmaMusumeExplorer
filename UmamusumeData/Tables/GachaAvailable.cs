using SQLite;

namespace UmamsumeData.Tables
{
    [Table("gacha_available")]
    public class GachaAvailable
    {
        [Column("gacha_id"), NotNull, PrimaryKey]
        public int GachaId { get; set; }

        [Column("card_id"), NotNull, PrimaryKey]
        public int CardId { get; set; }

        [Column("card_type"), NotNull]
        public int CardType { get; set; }

        [Column("rarity"), NotNull]
        public int Rarity { get; set; }

        [Column("odds"), NotNull]
        public int Odds { get; set; }

        [Column("is_pickup"), NotNull]
        public int IsPickup { get; set; }

        [Column("recommend_order"), NotNull]
        public int RecommendOrder { get; set; }

        [Column("is_prize_selectable"), NotNull]
        public int IsPrizeSelectable { get; set; }
    }
}