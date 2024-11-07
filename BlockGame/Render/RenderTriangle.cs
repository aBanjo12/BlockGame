using Microsoft.Xna.Framework.Graphics;

namespace BlockGame.Render;

public class RenderTriangle(VertexPositionTexture[] vertices)
{
    public VertexPositionTexture v1 = vertices[0];
    public VertexPositionTexture v2 = vertices[1];
    public VertexPositionTexture v3 = vertices[2];
}