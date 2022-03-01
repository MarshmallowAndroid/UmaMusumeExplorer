using SQLite;

namespace UmaMusumeFiles.Tables
{
    [Table("card_rarity_data")]
    public class CardRarityData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("card_id")]
        public int CardId { get; set; }

        [Column("rarity")]
        public int Rarity { get; set; }

        [Column("race_dress_id")]
        public int RaceDressId { get; set; }

        [Column("skill_set")]
        public int SkillSet { get; set; }

        [Column("speed")]
        public int Speed { get; set; }
        [Column("stamina")]
        public int Stamina { get; set; }
        [Column("pow")]
        public int Pow { get; set; }
        [Column("guts")]
        public int Guts { get; set; }
        [Column("wiz")]
        public int Wiz { get; set; }

        [Column("max_speed")]
        public int MaxSpeed { get; set; }
        [Column("max_stamina")]
        public int MaxStamina { get; set; }
        [Column("max_pow")]
        public int MaxPow { get; set; }
        [Column("max_guts")]
        public int MaxGuts { get; set; }
        [Column("max_wiz")]
        public int MaxWiz { get; set; }

        [Column("proper_distance_short")]
        public int ProperDistanceShort { get; set; }
        [Column("proper_distance_mile")]
        public int ProperDistanceMile { get; set; }
        [Column("proper_distance_middle")]
        public int ProperDistanceMiddle { get; set; }
        [Column("proper_distance_long")]
        public int ProperDistanceLong { get; set; }

        [Column("proper_running_style_nige")]
        public int ProperRunningStyleNige { get; set; }
        [Column("proper_running_style_senko")]
        public int ProperRunningStyleSenko { get; set; }
        [Column("proper_running_style_sashi")]
        public int ProperRunningStyleSashi { get; set; }
        [Column("proper_running_style_oikomi")]
        public int ProperRunningStyleOikomi { get; set; }

        [Column("proper_ground_turf")]
        public int ProperGroundTurf { get; set; }
        [Column("proper_ground_dirt")]
        public int ProperGroundDirt { get; set; }

        [Column("get_dress_id_1")]
        public int GetDressId1 { get; set; }
        [Column("get_dress_id_2")]
        public int GetDressId2 { get; set; }
    }
}
