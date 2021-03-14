using System;

namespace SharkEzz.Perlin.PerlinNoise
{
    public class Noise
    {
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
            float random = 2920f * (float)Math.Sin(ix * 21942f + iy * 171324f + 8912f) * (float)Math.Cos(ix * 23157f * iy * 217832f + 9758f);
            return new Vector2f((float)Math.Cos(random), (float)Math.Sin(random));
        }

        private float dotGridGradient(int ix, int iy, float x, float y)
        {
            Vector2f gradient = this.randomGradient(ix, iy);

            Console.WriteLine("dx : {0}, dy : {1}", x - ((float)ix), y - ((float)iy));

            float dx = x - (float)ix;
            float dy = y - (float)iy;

            return dx*gradient.X + dy*gradient.Y;
        }

        private float interpolate(float a0, float a1, float w)
        {
            return (a1 - a0) * w + a0;
        }
    }
}