using Microsoft.Xna.Framework;

namespace _2dgs_prototype;

public class Body
{
    private Vector2 Position;
    private Vector2 Velocity;
    private int Mass;
    private int Radius;

    public Body(Vector2 position, Vector2 velocity, int mass, int radius)
    {
        this.Position = position;
        this.Velocity = velocity;
        this.Mass = mass;
        this.Radius = radius;
    }
    
    // Method stubs
    public void Draw() {}
    
    public void Update(float deltaTime) {}
}