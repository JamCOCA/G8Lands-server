using SpacetimeDB;
public static partial class Module
{
    [Table(Name = "character", Public = true)]
    public partial struct Character
    {
        [SpacetimeDB.AutoInc]
        [SpacetimeDB.PrimaryKey]
        public int Id;
        public int PlayerId; // 外键：Player.Id（逻辑约束）
        public string Name;
        public long Experience;
        public long Gold;
        public int MapId;
        public DbVector3 Position;
        public Hp Hp;
        public Stamina Stamina;
        public long CreatedAtUnix;
        public long UpdatedAtUnix;
    }
    
}