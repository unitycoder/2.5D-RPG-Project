﻿using UnityEngine;

public class PerlinGen : MonoBehaviour
{
    /*
     * this class generates perlin maps. It returns a 2d array full of floats valued between 0-1.
     * the following parameters:
     * width and height are mainly the determiners for the size of the array it returns. you should usually just derive this value from the size of
     * whatever you intend to use the perlin map for. EX, if youre using it to determine certain elements in a whole biome, set them equal to 64 and 64, the size, 
     * in tiles, of a biome.
     * scale controls how far out youre zoomed out of the perlin map. smaller numbers will result in more unity and less diversity, whilst larger numbers while
     * seem almost like static. looking at x and looking at y represent basically where the "camera" is looking at within the perlin map. 
     * frequency is like scale however it changes between each layer. Layers are called octaves.
     * The change in frequency between layers is called lacunarity.
     * The persistence value determines how quickly the amplitudes diminish for successive octaves. The amplitude of the first octave is 1.0.
     * The amplitude of each subsequent octave is equal to the product of the previous octave's amplitude and the persistence value. 
     * So a persistence value of 0.5 sets the amplitude of the first octave to 1.0; the second, 0.5; the third, 0.25; etc.
     * The persistence value controls the roughness of the Perlin noise. Larger values produce rougher noise.
     * The persistence value determines how quickly the amplitudes diminish for successive octaves. The amplitude of the first octave is 1.0. 
     * The amplitude of each subsequent octave is equal to the product of the previous octave's amplitude and the persistence value. 
     * So a persistence value of 0.5 sets the amplitude of the first octave to 1.0; the second, 0.5; the third, 0.25; etc. 
     * 
     * takes a float array with the values [width,height,scale,xcoord,ycoord,frequency,lacunarity,persistance,octaves]
     * */


    public static float [,] Generate(float[] perlindata)
    {
        float width =perlindata[0];
        float height = perlindata[1];
        float scale = perlindata[2];
        float lookingatx = perlindata[3];
        float lookingaty = perlindata[4];
        float frequency = perlindata[5];
        float lacunarity = perlindata[6];
        float persistence = perlindata[7];
        float octaves = perlindata[8];
        float amplitude = 1;
       octaves = Mathf.RoundToInt(octaves);
       float[,] map = new float[(int)height, (int)width];
        for (int octloop = 1; octloop < octaves + 1; octloop++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float xCoord = ((lookingatx + x * (scale/10)) * frequency);
                    float yCoord = ((lookingaty + y * (scale/10)) * frequency);
                    map[y, x] += (Mathf.PerlinNoise(xCoord, yCoord)*amplitude)/octaves;
                }
            }
            frequency *= lacunarity;
            amplitude *= persistence;
        }


        return map;
    }

}