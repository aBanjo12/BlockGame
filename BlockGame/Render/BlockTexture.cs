namespace BlockGame.Render;

public class BlockTexture
{
    public BlockFace[] Faces;
    public BlockTexture()
    {
        Faces = [new BlockFace(new RenderTriangle(), new RenderTriangle())];
    }
}