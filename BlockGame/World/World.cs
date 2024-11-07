using System.Collections.Generic;
using System.Linq;
using BlockGame.Render;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame.World;

public class World
{
    public ChunkList ChunkList = new();
    VertexBuffer vertexBuffer;
    public Camera cam;

    public World(GraphicsDevice device)
    {
        cam = new Camera(device);
    }
    
    public void Update()
    {
        cam.Update();
    }

    public void Draw(GraphicsDevice device, SpriteBatch spriteBatch)
    {
        List<VertexPositionTexture> triangleVertices = new();
        foreach (var block in ChunkList[0, 0, 0].Blocks)
        {
            if (block == null)
                continue;
            foreach (var triangle in block.Texture.Faces)
            {
                triangleVertices.AddRange(triangle.triangle1.Verticies);
                triangleVertices.AddRange(triangle.triangle2.Verticies);
            }
        }

        vertexBuffer = new VertexBuffer(device, typeof(VertexPositionTexture), triangleVertices.Count, BufferUsage.WriteOnly);
        vertexBuffer.SetData(triangleVertices.ToArray());
        device.SetVertexBuffer(vertexBuffer);
        cam.Draw(device, vertexBuffer);
    }
}