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
            foreach (var triangle in block.triangles)
            {
                triangleVertices.AddRange(triangle);
            }
        }
        /*VertexPosition[] debug_verts = new VertexPosition[6];
        debug_verts[0] = new VertexPosition(new Vector3(
            0, 20, 0));
        debug_verts[1] = new VertexPosition(new Vector3(
            -20, -20, 0));
        debug_verts[2] = new VertexPosition(new Vector3(
            20, -20, 0));
        debug_verts[3] = new VertexPosition(new Vector3(
            20, 40, 0));
        debug_verts[4] = new VertexPosition(new Vector3(
            0, 0, 0));
        debug_verts[5] = new VertexPosition(new Vector3(
            40, 0, 0));*/
        
        //triangleVertices.AddRange(debug_verts);

        vertexBuffer = new VertexBuffer(device, typeof(VertexPosition), triangleVertices.Count, BufferUsage.WriteOnly);
        vertexBuffer.SetData(triangleVertices.ToArray());
        device.SetVertexBuffer(vertexBuffer);
        cam.Draw(device, vertexBuffer);
    }
}