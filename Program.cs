using System;
using SharkEzz.Perlin.PerlinNoise;

namespace SharkEzz.Perlin
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint width = 300, height = 300;

            Noise noise = new Noise();
            
            for(int y = 0; y < (height); y++)
            {
                for(int x = 0; x < width; x++)
                {
                    float res = noise.ComputePerlin(x, y);
                    Console.WriteLine("res : " + res);
                }                
            }
        }
    }
}
