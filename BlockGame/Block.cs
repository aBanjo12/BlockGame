using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame;

public class Block
{
    public Block(byte x, byte y, byte z)
    {
        vertices =
        [
            new VertexPosition(new Vector3(x, y, z) * 20), //front top left
            new VertexPosition(new Vector3(x + 1, y, z) * 20), //front top right
            new VertexPosition(new Vector3(x + 1, y + 1, z) * 20), //front bottom right
            new VertexPosition(new Vector3(x, y + 1, z) * 20), //front bottom left
            new VertexPosition(new Vector3(x, y, z + 1) * 20), //back top left
            new VertexPosition(new Vector3(x + 1, y, z + 1) * 20), //back top right
            new VertexPosition(new Vector3(x + 1, y + 1, z + 1) * 20), //back bottom right
            new VertexPosition(new Vector3(x, y + 1, z + 1) * 20) //back bottom left
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
    
    public VertexPosition[] vertices;
    public VertexPosition[][] triangles;
}