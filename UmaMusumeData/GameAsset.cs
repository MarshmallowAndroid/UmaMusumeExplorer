using SQLite;

namespace UmaMusumeData
{
    [Table("a")]
    public class GameAsset
    {
        [PrimaryKey]
        [Column("i")]
        public int Id { get; set; }

        [Column("n"), NotNull]
        public string Name { get; set; } = "";

        [Column("d")]
        public string Dependencies { get; set; } = "";

        [Column("l"), NotNull]
        public int Length { get; set; }

        [Column("h"), NotNull]
        public string Hash { get; set; } = "";

        [Column("m"), NotNull]
        public string Manifest { get; set; } = "";

        public string BaseName
        {
            get
            {
                int lastSlash = Name.LastIndexOf('/');
                return Name[(lastSlash + 1)..];
            }
        }

        public override bool Equals(object obj)
        {
            return ((GameAsset)obj).Hash == Hash;
        }

        public override int GetHashCode()
        {
            return Hash.GetHashCode();
        }
    }
}
