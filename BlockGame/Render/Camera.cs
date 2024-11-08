using System;
using BlockGame.Registry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlockGame.Render;

public class Camera
{
    public Vector3 camTarget;
    public Vector3 camPosition;
    public Vector3 lookVector = Vector3.Forward;
    public Matrix projectionMatrix;
    public Matrix viewMatrix;
    public Matrix worldMatrix;

    public float Sensitivity = .001f;
    
    public BasicEffect basicEffect;

    public Camera(GraphicsDevice device)
    {
        camTarget = new Vector3(0f, 0f, 0f);
        camPosition = new Vector3(0f, 0f, 100f);
        projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(90f), 
            device.DisplayMode.AspectRatio, 1f, 1000f);
        viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, new Vector3(0f, 1f, 0f));// Y up
        worldMatrix = Matrix.CreateWorld(camTarget, Vector3.Forward, Vector3.Up);
        
        //BasicEffect
        basicEffect = new BasicEffect(device);
        basicEffect.Alpha = 1f;
        basicEffect.Texture = TextureRegistry.block;
        basicEffect.TextureEnabled = true;

        // Want to see the colors of the vertices, this needs to be on
        //basicEffect.VertexColorEnabled = true;

        //Lighting requires normal information which VertexPositionColor does not have
        //If you want to use lighting and VPC you need to create a custom def
        basicEffect.LightingEnabled = false;
    }
    
    double xTransform = 0;
    double yTransform = 0;

    private MouseState prevState = Mouse.GetState();

    public void Update()
    {
        MouseState state = Mouse.GetState();

        xTransform += prevState.X - state.X;
        yTransform += prevState.Y - state.Y;
        Console.WriteLine($"X: {xTransform}, Y: {yTransform}");

        double xangle = (xTransform * Sensitivity);
        double yangle = (yTransform * Sensitivity);

        xangle %= Math.Tau;
        Math.Clamp(yangle, 0f, Math.PI);

        double x = Math.Cos(xangle) * Math.Sin(yangle);
        double y = Math.Sin(xangle) * Math.Sin(yangle);
        double z = Math.Cos(yangle);

        lookVector = new Vector3((float)x, (float)y, (float)z);
        //Console.WriteLine(lookVector);
        
        if (Keyboard.GetState().IsKeyDown(Keys.P))
            lookVector = Vector3.Forward;
        
        prevState = state;
        
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            camPosition.X += 1f;
            camTarget.X += 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            camPosition.X -= 1f;
            camTarget.X -= 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            camPosition.Y += 1f;
            camTarget.Y += 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            camPosition.Y -= 1f;
            camTarget.Y -= 1f;
        }
        if(Keyboard.GetState().IsKeyDown(Keys.W))
        {
            camPosition.Z += 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            camPosition.Z -= 1f;
        }

        camTarget = camPosition - lookVector;
        
        viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up);
    }
    
    public void Draw(GraphicsDevice device, VertexBuffer vertexBuffer)
    {
        device.Clear(Color.CornflowerBlue);

        basicEffect.Projection = projectionMatrix;
        basicEffect.View = viewMatrix;
        basicEffect.World = worldMatrix;
        foreach(EffectPass pass in basicEffect.CurrentTechnique.Passes)
        {
            pass.Apply();
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount);
        }
    }
}