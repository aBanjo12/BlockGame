using System;
using BlockGame.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame.World;

public class Block
{
    public Block(byte x, byte y, byte z, Vector3 ChunkPos)
    {
        Vector3 ch = Chunk.ChunkChordsToPosition(ChunkPos);
        //float x = 0, y = 0, z = 0;
        int blocksize = 20;
        Vertices =
        [
            new Vector3(x, y, z) * blocksize, //front top left
            new Vector3(x + 1, y, z) * blocksize, //front top right
            new Vector3(x + 1, y + 1, z) * blocksize, //front bottom right
            new Vector3(x, y + 1, z) * blocksize, //front bottom left
            new Vector3(x, y, z + 1) * blocksize, //back top left
            new Vector3(x + 1, y, z + 1) * blocksize, //back top right
            new Vector3(x + 1, y + 1, z + 1) * blocksize, //back bottom right
            new Vector3(x, y + 1, z + 1) * blocksize //back bottom left
        ];

        for (int i = 0; i < Vertices.Length; i++)
        {
            Vertices[i] += ch;
        }

        Texture = new BlockTexture(ref Vertices, 256);
    }
    
    public Vector3[] Vertices;
    public BlockTexture Texture;
}