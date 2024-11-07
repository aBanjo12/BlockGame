using BlockGame.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame.World;

public class Block
{
    public Block(byte x, byte y, byte z)
    {
        int blocksize = 256;
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

        Texture = new BlockTexture();
    }
    
    public Vector3[] Vertices;
    public BlockTexture Texture;
}