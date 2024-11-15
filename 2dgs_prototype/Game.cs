using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2dgs_prototype;

public class Game : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private List<Body> _bodies;
    private Body body_one;
    private Body body_two;

    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.SynchronizeWithVerticalRetrace = true;
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        _bodies = new List<Body>();

        body_one = new Body(new Vector2(300.0f, 300.0f),1, 1);
        _bodies.Add(body_one);
        
        body_two = new Body(new Vector2(1300.0f, 900.0f), 1, 1);
        _bodies.Add(body_two);
    }

    protected override void Initialize()
    {
        Window.Title = "2DGS";
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        foreach (Body body in _bodies)
        {
            body.LoadContent(Content);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        
        _spriteBatch.Begin();
        foreach (Body body in _bodies)
        {
            body.Draw(_spriteBatch);
        }
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}