using SpacetimeDB;
public static partial class Module
{
    [Type]
    public partial struct DbVector3
    {
        public float x;
        public float y;
        public float z;

        public DbVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}