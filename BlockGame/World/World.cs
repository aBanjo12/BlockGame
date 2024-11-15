using System.Collections.Generic;
using System.Linq;
using BlockGame.Event;
using BlockGame.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlockGame.World;

public class World
{
    public ChunkList ChunkList = new();
    VertexBuffer vertexBuffer;
    public Camera cam;
    public SpriteFont font;
    
    Vector2 xRenderDistance = new(-3, 3);
    Vector2 zRenderDistance = new(-3, 3);

    public World(GraphicsDevice device)
    {
        cam = new Camera(new Vector3(0, 0, -100), new Vector3(0, 0, 0), Vector3.Up, device);
    }
    
    public void Update()
    {
        cam.Update();
    }

    public void Draw(ref GraphicsDevice device, SpriteBatch spriteBatch)
    {
        device.Clear(Color.CornflowerBlue);

        List<VertexPositionTexture> triangleVertices = new();
        


        for (var x = xRenderDistance.X; x < xRenderDistance.Y; x++)
        {
            for (var z = zRenderDistance.X; z < zRenderDistance.Y; z++)
            {
                foreach (var block in ChunkList[(int)x, 0, (int)z].Blocks)
                {
                    if (block == null)
                        continue;
                    foreach (var triangle in block.Texture.Faces.Where(x => x.render))
                    {
                        triangleVertices.AddRange(triangle.triangle1.Verticies);
                        triangleVertices.AddRange(triangle.triangle2.Verticies);
                    }
                }
            }
        }

        vertexBuffer = new VertexBuffer(device, typeof(VertexPositionTexture), triangleVertices.Count, BufferUsage.WriteOnly);
        vertexBuffer.SetData(triangleVertices.ToArray());
        device.SetVertexBuffer(vertexBuffer);
        cam.Draw(device, vertexBuffer);
        
        GraphicsDevice d = device;
        
        spriteBatch.Begin();
        spriteBatch.DrawString(font, "test", new Vector2(10, 10), Color.White);
        spriteBatch.End();
        
        device = d;
    }
}