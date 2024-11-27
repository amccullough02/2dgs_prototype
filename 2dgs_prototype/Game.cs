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
    private SaveSystem _saveSystem;

    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.SynchronizeWithVerticalRetrace = true;
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        _bodies = new List<Body>();
        
        _saveSystem = new SaveSystem();
    }

    protected override void Initialize()
    { 
        Window.Title = "2DGS";
        
        SaveData saveData = _saveSystem.Load();

        foreach (var bodyData in saveData.Bodies)
        {
            _bodies.Add(new Body(bodyData.Position, bodyData.Mass, bodyData.DisplayRadius));
        }
        
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

        foreach (Body body in _bodies)
        {
            body.Update(_bodies);
        }
        
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