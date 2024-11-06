using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame;

public class Block
{
    public Block(byte x, byte y, byte z)
    {
        int blocksize = 256;
        vertices =
        [
            new VertexPositionTexture(new Vector3(x, y, z) * blocksize, V), //front top left
            new VertexPositionTexture(new Vector3(x + 1, y, z) * blocksize), //front top right
            new VertexPositionTexture(new Vector3(x + 1, y + 1, z) * blocksize), //front bottom right
            new VertexPositionTexture(new Vector3(x, y + 1, z) * blocksize), //front bottom left
            new VertexPositionTexture(new Vector3(x, y, z + 1) * blocksize), //back top left
            new VertexPositionTexture(new Vector3(x + 1, y, z + 1) * blocksize), //back top right
            new VertexPositionTexture(new Vector3(x + 1, y + 1, z + 1) * blocksize), //back bottom right
            new VertexPositionTexture(new Vector3(x, y + 1, z + 1) * blocksize) //back bottom left
        ];

        triangles = new VertexPosition[][]
        {
            [vertices[0], vertices[1], vertices[2]],
            [vertices[0], vertices[2], vertices[3]],
            [vertices[1], vertices[5], vertices[6]],
            [vertices[1], vertices[6], vertices[2]],
            [vertices[5], vertices[4], vertices[7]],
            [vertices[5], vertices[7], vertices[6]],
            [vertices[4], vertices[0], vertices[3]],
            [vertices[4], vertices[3], vertices[7]],
            [vertices[3], vertices[2], vertices[6]],
            [vertices[3], vertices[6], vertices[7]],
            [vertices[4], vertices[5], vertices[1]],
            [vertices[4], vertices[1], vertices[0]]
        };
    }
    
    public VertexPositionTexture[] vertices;
    public VertexPositionTexture[][] triangles;
}