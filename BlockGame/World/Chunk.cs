 using Microsoft.Xna.Framework;

using static BlockGame.Constants;

namespace BlockGame.World;

public class Chunk
{
    private Vector3 ChunkChords;
    public Chunk(Vector3 ChunkChords)
    {
        this.ChunkChords = ChunkChords;
        Generate();
    }
    public static Vector3 PositionToChunkChords(Vector3 worldPos)
    {
        float x, y, z;
        worldPos.Deconstruct(out x,  out y, out z);
        return new Vector3(x + 16 * 8, y + 16 * 8, z + 16 * 8) / BlockSize * 16;
    }
    
    public static Vector3 ChunkChordsToPosition(Vector3 worldPos)
    {
        return worldPos * BlockSize * 16 - new Vector3(16 * 8);
    }

    public void Generate()
    {
        for (byte x = 0; x < 16; x++)
        {
            for (byte z = 0; z < 16; z++)
            {
                Blocks[x, 0, z] = new Block(x, 0, z, ChunkChords);
            }
        }
    }

    public void BlockChanged(byte x, byte y, byte z)
    {
        
    }
    
    public Block[,,] Blocks = new Block[16, 16, 16];
}