using SQLite;

namespace UmamsumeData
{
    [Table("a")]
    public class ManifestEntry
    {
        [Column("i"), PrimaryKey]
        public int Id { get; set; }

        [Column("n"), NotNull]
        public string Name { get; set; } = "";

        [Column("d")]
        public string Dependencies { get; set; } = "";

        [Column("g"), NotNull]
        public AssetBundleGroup Group { get; set; }

        [Column("l"), NotNull]
        public long Length { get; set; }

        [Column("c"), NotNull]
        public long Checksum { get; set; }

        [Column("h"), NotNull]
        public string HashName { get; set; } = "";

        [Column("m"), NotNull]
        public string Manifest { get; set; } = "";

        [Column("k"), NotNull]
        public ManifestEntryKind Kind { get; set; }

        [Column("s"), NotNull]
        public byte State { get; set; }

        [Column("p"), NotNull]
        public int Priority { get; set; }

        public string BaseName
        {
            get
            {
                int lastSlash = Name.LastIndexOf('/');
                return Name[(lastSlash + 1)..];
            }
        }

        public override bool Equals(object? obj)
        {
            return (obj as ManifestEntry)?.HashName == HashName;
        }

        public override int GetHashCode()
        {
            return HashName.GetHashCode();
        }
    }
}
