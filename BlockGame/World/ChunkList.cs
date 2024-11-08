using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace BlockGame.World;

public class ChunkList
{
    public ChunkList()
    {
        this[0, 0, 0] = new Chunk();
        this[0, 0, 0].Blocks[0, 0, 0] = new Block(0,0,0);
        this[0, 0, 0].Blocks[1, 0, 0] = new Block(1,0,0);
    }
    
    private List<List<List<Chunk>>> chunks = [[[new Chunk()]]];
    public Chunk this[int x, int y, int z]
    {
        get
        {
            if (chunks[x][y][y] != null) return chunks[x][y][z];
            chunks[x][y][z] = new Chunk();
            chunks[x][y][z].Generate();
            return chunks[x][y][z];
        }
        private init => chunks[x][y][z] = value;
    }
}