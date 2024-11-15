using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BlockGame.Event;
using BlockGame.Event.Events;
using Microsoft.Xna.Framework;

namespace BlockGame.World;

public class ChunkList
{
    public Vector2 XRenderDistance, YRenderDistance;
    
    public ChunkList()
    {
        XRenderDistance = new Vector2(-3, 3);
        YRenderDistance = new Vector2(-3, 3);
    }
    
    private Dictionary<(int, int, int), Chunk> chunks = new();
    public Chunk this[int x, int y, int z]
    {
        get
        {
            if (chunks.ContainsKey((x, y, z))) return chunks[(x, y, z)];
            chunks.Add((x, y, z), new Chunk(new Vector3(x, y, z)));
            EventHandler.Events.Add(new CullFace(this[x, y, z], this));
            return chunks[(x, y, z)];
        }
        private init => chunks[(x, y, z)] = value;
    }

    public bool IsChunkOutOfRender(int x, int y, int z)
    {
        return true;
    }
}