using SpacetimeDB;
public static partial class Module
{
    // 玩家账户表
    [Table(Name = "player", Public = true)]
    public partial struct Player
    {
        [SpacetimeDB.AutoInc]
        [SpacetimeDB.PrimaryKey]
        public int Id;
        public string Username;
        public string DisplayName;
        public long CreatedAtUnix;
        public long LastLoginUnix;
        public bool IsBanned;
    }
}