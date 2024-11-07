using Microsoft.Xna.Framework;

namespace BlockGame.Render;

public class BlockTexture
{
    public BlockFace[] Faces;
    public BlockTexture(ref Vector3[] verticies, int textureSize)
    {
        Faces = [
            new BlockFace(ref verticies, Render.Faces.TOP, textureSize),
            new BlockFace(ref verticies, Render.Faces.FRONT, textureSize),
            new BlockFace(ref verticies, Render.Faces.LEFT, textureSize),
            new BlockFace(ref verticies, Render.Faces.BACK, textureSize),
            new BlockFace(ref verticies, Render.Faces.RIGHT, textureSize),
            new BlockFace(ref verticies, Render.Faces.BOTTOM, textureSize),
        ];
    }
}