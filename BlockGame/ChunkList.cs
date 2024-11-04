using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BlockGame;

public class ChunkList
{
    public ChunkList()
    {
        this[0, 0, 0] = new Chunk();
        this[0, 0, 0].Blocks[0, 0, 0] = new Block(0,0,0);
    }
    
    private List<List<List<Chunk>>> chunks = new();
    public Chunk this[int x, int y, int z]
    {
        get
        {
            if (chunks[x][y][y] != null)
            {
                return chunks[x][y][z];
            }
            else
            {
                return null;
            }
        }
        set => chunks[x][y][z] = value;
    }
}