﻿using SQLite;

namespace UmaMusumeFiles
{
    [Table("a")]
    public class GameAsset
    {
        [PrimaryKey]
        [Column("i")]
        public int Id { get; set; }

        [Column("n"), NotNull]
        public string Name { get; set; } = "";

        [Column("l"), NotNull]
        public string Length { get; set; } = "";

        [Column("h"), NotNull]
        public string Hash { get; set; } = "";

        public string BaseName
        {
            get
            {
                int lastSlash = Name.LastIndexOf('/');
                return Name[(lastSlash + 1)..];
            }
        }
    }
}