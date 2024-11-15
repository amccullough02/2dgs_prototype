using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2dgs_prototype;

public class Body
{
    private Texture2D Texture;
    private Vector2 Position;
    private Vector2 Velocity;
    private int Mass;
    private int Radius;

    public Body(Vector2 position, int mass, int radius)
    {
        this.Position = position;
        this.Velocity = Vector2.Zero;
        this.Mass = mass;
        this.Radius = radius;
    }

    public void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("blank_circle");
    }
    
    public void Update(GameTime gameTime) {}

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, 
            Position,
            null,
            Color.White,
            0f,
            new Vector2(Texture.Width / 2, Texture.Height / 2),
            new Vector2(0.1f, 0.1f),
            SpriteEffects.None,
            0f);
    }
}