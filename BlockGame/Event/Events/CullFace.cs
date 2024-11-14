using System.Runtime.CompilerServices;
using BlockGame.World;

namespace BlockGame.Event.Events;

public class CullFace : Event
{
    public CullFace(ref Block[,,] blocks, ref ChunkList chunkList)
    {
        Execute = () =>
        {
            
        };
    }
    
    public void CullFaces(ref Block[,,] blocks, ref ChunkList chunkList)
    {
        for (int x = 0; x < blocks.GetLength(0); x++)
        {
            for (int y = 0; x < blocks.GetLength(1); y++)
            {
                for (int z = 0; x < blocks.GetLength(2); z++)
                {
                    
                }
            }
        }
    }
}