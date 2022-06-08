using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UmaMusumeData.Tables
{
    [Table("text_data")]
    public class TextData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("category")]
        public int Category { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("text")]
        public string Text { get; set; } = "";
    }
}
