using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockGame;

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
        List<VertexPosition> triangleVertices = new();
        foreach (var block in ChunkList[0, 0, 0].Blocks)
        {
            if (block == null)
                continue;
            foreach (var triangle in block.Faces)
            {
                triangleVertices.AddRange(triangle);
            }
        }

        vertexBuffer = new VertexBuffer(device, typeof(VertexPosition), triangleVertices.Count, BufferUsage.WriteOnly);
        vertexBuffer.SetData(triangleVertices.ToArray());
        device.SetVertexBuffer(vertexBuffer);
        cam.Draw(device, vertexBuffer);
    }
}