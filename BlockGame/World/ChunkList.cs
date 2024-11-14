using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace BlockGame.World;

public class ChunkList
{
    public ChunkList()
    {
    }
    
    private Dictionary<(int, int, int), Chunk> chunks = new();
    public Chunk this[int x, int y, int z]
    {
        get
        {
            if (chunks.ContainsKey((x, y, z))) return chunks[(x, y, z)];
            chunks.Add((x, y, z), new Chunk(new Vector3(x, y, z)));
            chunks[(x, y, z)].Generate();
            return chunks[(x, y, z)];
        }
        private init => chunks[(x, y, z)] = value;
    }
}