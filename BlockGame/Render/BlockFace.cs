using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame.Render;

public class BlockFace
{
    public static int[][] VertIndexes =
    [
        [4, 0, 1], //top
        [4, 5, 1],

        [0, 1, 2], //front
        [0, 3, 2],

        [4, 0, 3], //left
        [4, 7, 3],

        [5, 4, 7], //back
        [5, 6, 7],

        [1, 5, 6], //right
        [1, 2, 6],

        [3, 2, 6], //bottom
        [3, 7, 6]
    ];

    public Vector2[] TextureChords;
    public RenderTriangle triangle1;
    public RenderTriangle triangle2;
    public bool render = true;

    public BlockFace(ref Vector3[] verticies, Faces face, int textureSize)
    {
        TextureChords =
        [
            new(0, 0),
            new(1, 0),
            new(1, 1),
            new(0, 1)
        ];

        triangle1 = new RenderTriangle([
            new VertexPositionTexture(verticies[VertIndexes[(int)face * 2][0]],
                TextureChords[(int)TexturePosition.TOP_LEFT]),
            new VertexPositionTexture(verticies[VertIndexes[(int)face * 2][1]],
                TextureChords[(int)TexturePosition.TOP_RIGHT]),
            new VertexPositionTexture(verticies[VertIndexes[(int)face * 2][2]],
                TextureChords[(int)TexturePosition.BOTTOM_RIGHT]),
        ]);

        triangle2 = new RenderTriangle([
            new VertexPositionTexture(verticies[VertIndexes[(int)face * 2 + 1][0]],
                TextureChords[(int)TexturePosition.TOP_LEFT]),
            new VertexPositionTexture(verticies[VertIndexes[(int)face * 2 + 1][1]],
                TextureChords[(int)TexturePosition.BOTTOM_LEFT]),
            new VertexPositionTexture(verticies[VertIndexes[(int)face * 2 + 1][2]],
                TextureChords[(int)TexturePosition.BOTTOM_RIGHT]),
        ]);
    }
}

public enum TexturePosition : int
{
    TOP_LEFT = 0,
    TOP_RIGHT = 1,
    BOTTOM_RIGHT = 2,
    BOTTOM_LEFT = 3
}