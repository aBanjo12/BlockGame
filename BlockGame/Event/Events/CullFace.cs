using System.Runtime.CompilerServices;
using BlockGame.Render;
using BlockGame.World;

namespace BlockGame.Event.Events;

public class CullFace : Event
{
    public CullFace(Chunk chunk, ChunkList chunkList)
    {
        Execute = () =>
        {
            CullFaces(chunk, chunkList);
        };
    }
    
    public void CullFaces(Chunk chunk, ChunkList chunkList)
    {
        for (int x = 0; x < chunk.Blocks.GetLength(0); x++)
        {
            bool right = x == 15;
            bool left = x == 0;
            
            for (int y = 0; y < chunk.Blocks.GetLength(1); y++)
            {
                bool bottom = y == 0;
                bool top = y == 15;

                for (int z = 0; z < chunk.Blocks.GetLength(2); z++)
                {
                    bool back = z == 15;
                    bool front = z == 0;
                    
                    if (chunk.Blocks[x, y, z] == null)
                        continue;
                    
                    if (!right)
                        chunk.Blocks[x, y, z].Texture.Faces[(int)Faces.RIGHT].render = chunk.Blocks[x+1, y, z] == null;
                    if (!left)
                        chunk.Blocks[x, y, z].Texture.Faces[(int)Faces.LEFT].render = chunk.Blocks[x-1, y, z] == null;
                    if (!bottom)
                        chunk.Blocks[x, y, z].Texture.Faces[(int)Faces.BOTTOM].render = chunk.Blocks[x, y-1, z] == null;
                    if (!top)
                        chunk.Blocks[x, y, z].Texture.Faces[(int)Faces.TOP].render = chunk.Blocks[x, y+1, z] == null;
                    if (!front)
                        chunk.Blocks[x, y, z].Texture.Faces[(int)Faces.FRONT].render = chunk.Blocks[x, y, z-1] == null;
                    if (!back)
                        chunk.Blocks[x, y, z].Texture.Faces[(int)Faces.BACK].render = chunk.Blocks[x, y, z+1] == null;
                    
                    
                }
            }
        }
    }
}