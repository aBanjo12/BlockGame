using BlockGame.World;
using Microsoft.Xna.Framework;

using static BlockGame.Constants;

namespace BlockGame.World;

public class Chunk
{
    public static Vector3 PositionToChunkChords(Vector3 worldPos)
    {
        float x, y, z;
        worldPos.Deconstruct(out x,  out y, out z);
        return new Vector3(x + 16 * 8, y + 16 * 8, z + 16 * 8) / BlockSize * 16;
    }

    public void Generate()
    {
        for (byte x = 0; x < 16; x++)
        {
            for (byte y = 0; y < 16; y++)
            {
                for (byte z = 0; z < 16; z++)
                {
                    Blocks[x, y, z] = new Block(x, y, z);
                }
            }
        }
    }
    
    public Block[,,] Blocks = new Block[16, 16, 16];
}