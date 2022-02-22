using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Extractor
{
    [Table("a")]
    public class GameFile
    {
        [PrimaryKey]
        [Column("i")]
        public int Id { get; set; }

        [Column("n"), NotNull]
        public string Name { get; set; }

        [Column("l"), NotNull]
        public string Length { get; set; }

        [Column("h"), NotNull]
        public string Hash { get; set; }

        [Column("m")]
        public string Category { get; set; }
    }
}
