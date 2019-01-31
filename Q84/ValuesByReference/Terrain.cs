namespace ValuesByReference
{
    public class Terrain
    {
        public static Terrain Get()
        {
            return new Terrain();
        }

        private TerrainType[,] terrain = new TerrainType[8, 8];

        public ref TerrainType GetAt(int x, int y) => ref terrain[x, y];

        public void BurnAt(int x, int y)
        {
            terrain[x, y] = TerrainType.Dirt;
        }
    }
}
