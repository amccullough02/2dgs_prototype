using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2dgs_prototype;

public class Game : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;

    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.SynchronizeWithVerticalRetrace = true;
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Window.Title = "2DGS";
        base.Initialize();
    }

    protected override void LoadContent() {}

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
        base.Draw(gameTime);
    }
}