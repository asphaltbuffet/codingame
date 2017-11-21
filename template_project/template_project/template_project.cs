using System;
using System.Linq;
using System.Collections.Generic;

class Player
{
    private static Game game = new Game();

    static void Main(string[] args)
    {
        game.Initialize();

        // game loop
        for (;;)
        {
            game.Update();


            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(game.Command());
        }
    }
}


public class Game
{
    private const int PlayerCount = 2;

    private Entity[] _players;

    public int ProjectCount { get; private set; }
    public Entity Me => _players[0];

    public Game()
    {
        _players = new Entity[PlayerCount];

        for (var i = 0; i < PlayerCount; i++)
        {
            _players[i] = new Entity();
        }
    }

    public void Initialize()
    {
        var tmp = Console.ReadLine();
        Console.Error.WriteLine(tmp);

        // Put in parsing for game initial state.
    }

    public void Update()
    {
        UpdatePlayers();
        
        // Put in update functions for aspects of game/environment
    }
    
    private void UpdatePlayers()
    {
        for (var i = 0; i < PlayerCount; i++)
        {
            var tmp = Console.ReadLine();
            Console.Error.WriteLine((string)tmp);

            // Parse current status from console input.
        }
    }

    public string Command()
    {
        // Take current game environment and determine command to submit.
        return string.Empty;
    }
}

public class Entity
{
    public Vector Position { get; set; }

    public float X => Position.X;
    public float Y => Position.Y;

    public int Id { get; set; }
    public int Team { get; set; }
    public int Value { get; set; }
}

public class Vector
{
    public Vector(float x, float y)
    {
        X = x;
        Y = y;
    }

    public float X { get; set; }
    public float Y { get; set; }

    public static Vector operator -(Vector v1, Vector v2)
    {
        return new Vector(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        return ((int)v1.X == (int)v2.X) && ((int)v1.Y == (int)v2.Y);
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    public float Magnitude => (float)Math.Sqrt(X * X + Y * Y);

    public override bool Equals(object obj)
    {
        var vector = obj as Vector;
        return vector != null &&
               X == vector.X &&
               Y == vector.Y &&
               Magnitude == vector.Magnitude;
    }

    public override int GetHashCode()
    {
        var hashCode = -1077792288;
        hashCode = hashCode * -1521134295 + X.GetHashCode();
        hashCode = hashCode * -1521134295 + Y.GetHashCode();
        hashCode = hashCode * -1521134295 + Magnitude.GetHashCode();
        return hashCode;
    }
}