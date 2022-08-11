using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("card_rarity_data")]
    public class CardRarityData
    {
        [Column("id"), NotNull, PrimaryKey]
        public int ID { get; set; }

        [Column("card_id"), NotNull]
        public int CardID { get; set; }

        [Column("rarity"), NotNull]
        public int Rarity { get; set; }

        [Column("race_dress_id"), NotNull]
        public int RaceDressID { get; set; }

        [Column("skill_set"), NotNull]
        public int SkillSet { get; set; }

        [Column("speed"), NotNull]
        public int Speed { get; set; }
        [Column("stamina"), NotNull]
        public int Stamina { get; set; }
        [Column("pow"), NotNull]
        public int Pow { get; set; }
        [Column("guts"), NotNull]
        public int Guts { get; set; }
        [Column("wiz"), NotNull]
        public int Wiz { get; set; }

        [Column("max_speed"), NotNull]
        public int MaxSpeed { get; set; }
        [Column("max_stamina"), NotNull]
        public int MaxStamina { get; set; }
        [Column("max_pow"), NotNull]
        public int MaxPow { get; set; }
        [Column("max_guts"), NotNull]
        public int MaxGuts { get; set; }
        [Column("max_wiz"), NotNull]
        public int MaxWiz { get; set; }

        [Column("proper_distance_short"), NotNull]
        public int ProperDistanceShort { get; set; }
        [Column("proper_distance_mile"), NotNull]
        public int ProperDistanceMile { get; set; }
        [Column("proper_distance_middle"), NotNull]
        public int ProperDistanceMiddle { get; set; }
        [Column("proper_distance_long"), NotNull]
        public int ProperDistanceLong { get; set; }

        [Column("proper_running_style_nige"), NotNull]
        public int ProperRunningStyleNige { get; set; }
        [Column("proper_running_style_senko"), NotNull]
        public int ProperRunningStyleSenko { get; set; }
        [Column("proper_running_style_sashi"), NotNull]
        public int ProperRunningStyleSashi { get; set; }
        [Column("proper_running_style_oikomi"), NotNull]
        public int ProperRunningStyleOikomi { get; set; }

        [Column("proper_ground_turf"), NotNull]
        public int ProperGroundTurf { get; set; }
        [Column("proper_ground_dirt"), NotNull]
        public int ProperGroundDirt { get; set; }

        [Column("get_dress_id_1"), NotNull]
        public int GetDressID1 { get; set; }
        [Column("get_dress_id_2"), NotNull]
        public int GetDressID2 { get; set; }
    }
}
