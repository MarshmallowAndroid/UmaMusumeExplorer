using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UmaMusumeFiles.Tables
{
    [Table("chara_data")]
    public class CharaData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("birth_year")]
        public int BirthYear { get; set; }
        [Column("birth_month")]
        public int BirthMonth { get; set; }
        [Column("birth_day")]
        public int BirthDay { get; set; }

        [Column("sex")]
        public int Sex { get; set; }

        [Column("image_color_main")]
        public string ImageColorMain { get; set; } = "";
        [Column("image_color_sub")]
        public string ImageColorSub { get; set; } = "";

        [Column("ui_color_main")]
        public string UIColorMain { get; set; } = "";
        [Column("ui_color_sub")]
        public string UIColorSub { get; set; } = "";

        [Column("ui_training_color_1")]
        public string UITrainingColor1 { get; set; } = "";
        [Column("ui_training_color_2")]
        public string UITrainingColor2 { get; set; } = "";

        [Column("ui_border_color")]
        public string UIBorderColor { get; set; } = "";

        [Column("ui_num_color_1")]
        public string UINumColor1 { get; set; } = "";
        [Column("ui_num_color_2")]
        public string UINumColor2 { get; set; } = "";

        [Column("ui_turn_color")]
        public string UITurnColor { get; set; } = "";

        [Column("ui_wipe_color_1")]
        public string UIWipeColor1 { get; set; } = "";
        [Column("ui_wipe_color_2")]
        public string UIWipeColor2 { get; set; } = "";
        [Column("ui_wipe_color_3")]
        public string UIWipeColor3 { get; set; } = "";

        [Column("ui_speech_color_1")]
        public string UISpeechColor1 { get; set; } = "";
        [Column("ui_speech_color_2")]
        public string UISpeechColor2 { get; set; } = "";

        [Column("ui_nameplate_color_1")]
        public string UINameplateColor1 { get; set; } = "";
        [Column("ui_nameplate_color_2")]
        public string UINameplateColor2 { get; set; } = "";

        [Column("height")]
        public int Height { get; set; }

        [Column("bust")]
        public int Bust { get; set; }

        [Column("scale")]
        public int Scale { get; set; }

        [Column("skin")]
        public int Skin { get; set; }

        [Column("shape")]
        public int Shape { get; set; }

        [Column("socks")]
        public int Socks { get; set; }

        [Column("personal_dress")]
        public int PersonalDress { get; set; }

        [Column("tail_model_id")]
        public int TailModelId { get; set; }

        [Column("race_running_type")]
        public int RaceRunningType { get; set; }

        [Column("ear_random_time_min")]
        public int EarRandomTimeMin { get; set; }
        [Column("ear_random_time_max")]
        public int EarRandomTimeMax { get; set; }

        [Column("tail_random_time_min")]
        public int TailRandomTimeMin { get; set; }
        [Column("tail_random_time_max")]
        public int TailRandomTimeMax { get; set; }

        [Column("story_ear_random_time_min")]
        public int StoryEarRandomTimeMin { get; set; }
        [Column("story_ear_random_time_max")]
        public int StoryEarRandomTimeMax { get; set; }

        [Column("story_tail_random_time_min")]
        public int StoryTailRandomTimeMin { get; set; }
        [Column("story_tail_random_time_max")]
        public int StoryTailRandomTimeMax { get; set; }

        [Column("attachment_model_id")]
        public int AttachmentModelId { get; set; }

        [Column("mini_mayu_shader_type")]
        public int MiniMayuShaderType { get; set; }

        [Column("start_date")]
        public int StartDate { get; set; }

        [Column("chara_category")]
        public int CharaCategory { get; set; }
    }
}
