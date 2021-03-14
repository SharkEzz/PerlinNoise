namespace SharkEzz.Perlin.PerlinNoise
{
    public class Vector2f
    {
        private float x, y;

        public float X
        {
            get => this.x;
            set => this.x = value;
        }

        public float Y
        {
            get => this.y;
            set => this.y = value;
        }

        public Vector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}