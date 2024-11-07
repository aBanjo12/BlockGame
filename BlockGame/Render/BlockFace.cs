using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame.Render;

public class BlockFace
{
    public static int[][] VertIndexes =
    [
        [4, 0, 1],
        [4, 5, 1],

        [0, 1, 2],
        [0, 3, 2],

        [4, 0, 2],
        [4, 7, 2],

        [5, 4, 7],
        [5, 6, 7],

        [1, 5, 6],
        [1, 2, 6],

        [3, 2, 6],
        [3, 7, 6]
    ];
    
    public BlockFace(Vector3 position, Texture2D texture, ref Vector3[] vertices, Faces face)
    {
        triangle1 = new RenderTriangle([
            new VertexPositionTexture(
                new Vector3(vertices[VertIndexes[(int)face*2][0]].X, vertices[VertIndexes[(int)face*2][0]].Y,
                    vertices[VertIndexes[(int)face][0]].Z), new Vector2(0, 0)),
            new VertexPositionTexture(
                new Vector3(vertices[VertIndexes[(int)face*2][1]].X, vertices[VertIndexes[(int)face*2][1]].Y,
                    vertices[VertIndexes[(int)face][0]].Z), new Vector2(0, 0)),
            new VertexPositionTexture(
                new Vector3(vertices[VertIndexes[(int)face*2][0]].X, vertices[VertIndexes[(int)face*2][0]].Y,
                    vertices[VertIndexes[(int)face][0]].Z), new Vector2(0, 0))
        ]);
    }
    
    RenderTriangle triangle1;
    RenderTriangle triangle2;
}