using System;

namespace SharkEzz.Perlin.PerlinNoise
{
    public class Noise
    {
        private float rand1 = new Random().Next(0, 200000),
                      rand2 = new Random().Next(0, 200000),
                      rand3 = new Random().Next(0, 200000),
                      rand4 = new Random().Next(0, 200000),
                      rand5 = new Random().Next(0, 200000),
                      rand6 = new Random().Next(0, 200000),
                      rand0 = new Random().Next(0, 200000);

        public float ComputePerlin(float x, float y)
        {
            int x0 = (int)x;
            int x1 = x0 + 1;
            int y0 = (int)y;
            int y1 = y0 + 1;

            float sx = x - (float)x0;
            float sy = y - (float)y0;

            float n0, n1, ix0, ix1;

            n0 = this.dotGridGradient(x0, y0, x, y);
            n1 = this.dotGridGradient(x1, y0, x, y);
            ix0 = this.interpolate(n0, n1, sx);

            n0 = this.dotGridGradient(x0, y1, x, y);
            n1 = this.dotGridGradient(x1, y1, x, y);
            ix1 = this.interpolate(n0, n1, sx);

            return this.interpolate(ix0, ix1, sy);
        }

        private Vector2f randomGradient(int ix, int iy)
        {
            float random = rand0 * (float)(Math.Sin(ix * rand1 + iy * rand2 + rand3) * Math.Cos(ix * rand4 * iy * rand5 + rand6));
            return new Vector2f((float)Math.Cos((float)random), (float)Math.Sin((float)random));
        }

        private float dotGridGradient(int ix, int iy, float x, float y)
        {
            Vector2f gradient = this.randomGradient(ix, iy);

            float dx = x - (float)ix;
            float dy = y - (float)iy;

            return dx*gradient.X + dy*gradient.Y;
        }

        private float interpolate(float a0, float a1, float w)
        {
            return (float)((a1 - a0) * ((w * (w * 6.0 - 15.0) + 10.0) * w * w * w) + a0);
        }
    }
}