using SQLite;

namespace UmamsumeData.Tables
{
    [Table("text_data")]
    public class TextData
    {
        [Column("id"), NotNull]
        public int Id { get; set; }

        [Column("category"), NotNull, PrimaryKey]
        public int Category { get; set; }

        [Column("index"), NotNull, PrimaryKey]
        public int Index { get; set; }

        [Column("text"), NotNull]
        public string Text { get; set; } = "";
    }
}
