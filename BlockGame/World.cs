using System.Collections.Generic;

namespace BlockGame;

public class World
{
    public ChunkList ChunkList = new();
    
    public void Update()
    {
        
    }
    
    public void Draw()
    {
        foreach (var block in ChunkList[0, 0, 0].Blocks)
        {
            foreach (var triangle in block.triangles)
            {
            }
        }
    }
}