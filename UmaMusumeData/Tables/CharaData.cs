using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("chara_data")]
    public class CharaData
    {
        [Column("id"), NotNull, PrimaryKey]
        public int Id { get; set; }

        [Column("birth_year"), NotNull]
        public int BirthYear { get; set; }
        [Column("birth_month"), NotNull]
        public int BirthMonth { get; set; }
        [Column("birth_day"), NotNull]
        public int BirthDay { get; set; }

        [Column("sex"), NotNull]
        public int Sex { get; set; }

        [Column("image_color_main"), NotNull]
        public string ImageColorMain { get; set; } = "";
        [Column("image_color_sub"), NotNull]
        public string ImageColorSub { get; set; } = "";

        [Column("ui_color_main"), NotNull]
        public string UIColorMain { get; set; } = "";
        [Column("ui_color_sub"), NotNull]
        public string UIColorSub { get; set; } = "";

        [Column("ui_training_color_1"), NotNull]
        public string UITrainingColor1 { get; set; } = "";
        [Column("ui_training_color_2"), NotNull]
        public string UITrainingColor2 { get; set; } = "";

        [Column("ui_border_color"), NotNull]
        public string UIBorderColor { get; set; } = "";

        [Column("ui_num_color_1"), NotNull]
        public string UINumColor1 { get; set; } = "";
        [Column("ui_num_color_2"), NotNull]
        public string UINumColor2 { get; set; } = "";

        [Column("ui_turn_color"), NotNull]
        public string UITurnColor { get; set; } = "";

        [Column("ui_wipe_color_1"), NotNull]
        public string UIWipeColor1 { get; set; } = "";
        [Column("ui_wipe_color_2"), NotNull]
        public string UIWipeColor2 { get; set; } = "";
        [Column("ui_wipe_color_3"), NotNull]
        public string UIWipeColor3 { get; set; } = "";

        [Column("ui_speech_color_1"), NotNull]
        public string UISpeechColor1 { get; set; } = "";
        [Column("ui_speech_color_2"), NotNull]
        public string UISpeechColor2 { get; set; } = "";

        [Column("ui_nameplate_color_1"), NotNull]
        public string UINameplateColor1 { get; set; } = "";
        [Column("ui_nameplate_color_2"), NotNull]
        public string UINameplateColor2 { get; set; } = "";

        [Column("height"), NotNull]
        public int Height { get; set; }

        [Column("bust"), NotNull]
        public int Bust { get; set; }

        [Column("scale"), NotNull]
        public int Scale { get; set; }

        [Column("skin"), NotNull]
        public int Skin { get; set; }

        [Column("shape"), NotNull]
        public int Shape { get; set; }

        [Column("socks"), NotNull]
        public int Socks { get; set; }

        [Column("personal_dress"), NotNull]
        public int PersonalDress { get; set; }

        [Column("tail_model_id"), NotNull]
        public int TailModelId { get; set; }

        [Column("race_running_type"), NotNull]
        public int RaceRunningType { get; set; }

        [Column("ear_random_time_min"), NotNull]
        public int EarRandomTimeMin { get; set; }
        [Column("ear_random_time_max"), NotNull]
        public int EarRandomTimeMax { get; set; }

        [Column("tail_random_time_min"), NotNull]
        public int TailRandomTimeMin { get; set; }
        [Column("tail_random_time_max"), NotNull]
        public int TailRandomTimeMax { get; set; }

        [Column("story_ear_random_time_min"), NotNull]
        public int StoryEarRandomTimeMin { get; set; }
        [Column("story_ear_random_time_max"), NotNull]
        public int StoryEarRandomTimeMax { get; set; }

        [Column("story_tail_random_time_min"), NotNull]
        public int StoryTailRandomTimeMin { get; set; }
        [Column("story_tail_random_time_max"), NotNull]
        public int StoryTailRandomTimeMax { get; set; }

        [Column("attachment_model_id"), NotNull]
        public int AttachmentModelId { get; set; }

        [Column("mini_mayu_shader_type"), NotNull]
        public int MiniMayuShaderType { get; set; }

        [Column("start_date"), NotNull]
        public int StartDate { get; set; }

        [Column("chara_category"), NotNull]
        public int CharaCategory { get; set; }
    }
}
