using System;
using SharkEzz.Perlin.PerlinNoise;
using SFML.Graphics;

namespace SharkEzz.Perlin
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint width = 300, height = 300;

            Noise noise = new Noise();

            Color[,] colors = new Color[height,width];
            
            for(float y = 0f; y < height / 10; y = (float)Math.Round(y + 0.1f, 1))
            {
                for(float x = 0f; x < width / 10; x = (float)Math.Round(x + 0.1f, 1))
                {
                    float perlin = noise.ComputePerlin((float)Math.Round(x, 1), (float)Math.Round(y, 1));
                    byte res = (byte)Program.map(perlin, -1, 1, 0, 255);
                    colors[(int)(y * 10), (int)(x * 10)] = new Color(res, res, res);
                }
            }

            new Image(colors).SaveToFile("perlin.png");
        }

        static uint map(float x, int in_min, int in_max, uint out_min, uint out_max)
        {
            return (uint)((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
        }
    }
}
