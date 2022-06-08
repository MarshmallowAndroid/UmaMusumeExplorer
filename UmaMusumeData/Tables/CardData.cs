using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeData.Tables
{
    [Table("card_data")]
    public class CardData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("chara_id")]
        public int CharaId { get; set; }

        [Column("default_rarity")]
        public int DefaultRarity { get; set; }

        [Column("limited_chara")]
        public int LimitedChara { get; set; }

        [Column("available_skill_set_id")]
        public int AvailableSkillSetId { get; set; }

        [Column("talent_speed")]
        public int TalentSpeed { get; set; }
        [Column("talent_stamina")]
        public int TalentStamina { get; set; }
        [Column("talent_pow")]
        public int TalentPow { get; set; }
        [Column("talent_guts")]
        public int TalentGuts { get; set; }
        [Column("talent_wiz")]
        public int TalentWiz { get; set; }

        [Column("talent_group_id")]
        public int TalentGroupId { get; set; }

        [Column("bg_id")]
        public int BgId { get; set; }

        [Column("get_piece_id")]
        public int GetPieceId { get; set; }

        [Column("running_style")]
        public int RunningStyle { get; set; }
    }
}
