using System;
using System.Linq;
using System.Collections.Generic;

class Player
{
    private static Game game;

    static void Main(string[] args)
    {
        game = new Game();

        // game loop
        for (;;)
        {
            game.Update();

            Console.WriteLine(game.Command);
        }
    }
}


public class Game
{
    private const bool _consoleLogging = true;
    private const int PlayerCount = 2;
    
    private Entity[] _players;
    private bool _gameRound;
    private bool _heroRound;

    public Entity Me => _players[0];

    public Game()
    {
        _players = new Entity[PlayerCount];
        Items = new List<Item>();

        for (var i = 0; i < PlayerCount; i++)
        {
            _players[i] = new Entity();
        }

        // Read initial game state
        TeamNumber = ConsoleToInt();

        BushSpawnCount = ConsoleToInt(); // useful from wood1, represents the number of bushes and the number of places where neutral units can spawn
        for (int i = 0; i < BushSpawnCount; i++)
        {
            var inputs = ConsoleToStrArray();
            string entityType = inputs[0]; // BUSH, from wood1 it can also be SPAWN
            int x = int.Parse(inputs[1]);
            int y = int.Parse(inputs[2]);
            int radius = int.Parse(inputs[3]);
        }
        
        int itemCount = ConsoleToInt(); // useful from wood2

        for (int i = 0; i < itemCount; i++)
        {
            var inputs = ConsoleToStrArray();

            Items.Add(new Item(inputs[0],            // contains keywords such as BRONZE, SILVER and BLADE, BOOTS connected by "_" to help you sort easier
                               int.Parse(inputs[1]), // BRONZE items have lowest cost, the most expensive items are LEGENDARY
                               int.Parse(inputs[2]), // keyword BLADE is present if the most important item stat is damage
                               int.Parse(inputs[3]), 
                               int.Parse(inputs[4]),
                               int.Parse(inputs[5]), 
                               int.Parse(inputs[6]), 
                               int.Parse(inputs[7]), // keyword BOOTS is present if the most important item stat is moveSpeed
                               int.Parse(inputs[8]), 
                               int.Parse(inputs[9]) != 0)); // 0 if it's not instantly consumed
        }
    }

    private int ConsoleToInt()
    {
        var input = Console.ReadLine();

        if (_consoleLogging)
        {
            Console.Error.WriteLine(input);
        }

        return int.Parse(input);
    }

    private string[] ConsoleToStrArray()
    {
        var input = Console.ReadLine();

        if (_consoleLogging)
        {
            Console.Error.WriteLine(input);
        }

        return input.Split(' ');
    }

    public void Update()
    {
        PlayerGold = ConsoleToInt(); 
        OpponentGold = ConsoleToInt();
        ParseRoundInformation(ConsoleToInt()); // a positive value will show the number of heroes that await a command
        EntityCount = ConsoleToInt();

        for (int i = 0; i < EntityCount; i++)
        {
            var inputs = ConsoleToStrArray();

            int unitId = int.Parse(inputs[0]);
            int team = int.Parse(inputs[1]);
            string unitType = inputs[2]; // UNIT, HERO, TOWER, can also be GROOT from wood1
            int x = int.Parse(inputs[3]);
            int y = int.Parse(inputs[4]);
            int attackRange = int.Parse(inputs[5]);
            int health = int.Parse(inputs[6]);
            int maxHealth = int.Parse(inputs[7]);
            int shield = int.Parse(inputs[8]); // useful in bronze
            int attackDamage = int.Parse(inputs[9]);
            int movementSpeed = int.Parse(inputs[10]);
            int stunDuration = int.Parse(inputs[11]); // useful in bronze
            int goldValue = int.Parse(inputs[12]);
            int countDown1 = int.Parse(inputs[13]); // all countDown and mana variables are useful starting in bronze
            int countDown2 = int.Parse(inputs[14]);
            int countDown3 = int.Parse(inputs[15]);
            int mana = int.Parse(inputs[16]);
            int maxMana = int.Parse(inputs[17]);
            int manaRegeneration = int.Parse(inputs[18]);
            string heroType = inputs[19]; // DEADPOOL, VALKYRIE, DOCTOR_STRANGE, HULK, IRONMAN
            int isVisible = int.Parse(inputs[20]); // 0 if it isn't
            int itemsOwned = int.Parse(inputs[21]); // useful from wood1
        }
    }

    private void ParseRoundInformation(int roundType)
    {
        // Positive value indicates number of heros to control in round
        if (roundType >= 0)
        {
            GameRound = true;
        }
        else
        {
            HeroRound = true;
        }
    }

    private void UpdatePlayers()
    {
        for (var i = 0; i < PlayerCount; i++)
        {
            // Parse current status from console input.
        }
    }

    public string Command
    {
        private set { }
        get
        {
            // Take current game environment and determine command to submit.
            if (HeroRound)
            {
                return "HULK";
            }
            else if (GameRound)
            {
                return "WAIT";
            }
            else
            {
                throw new InvalidOperationException();
            }
                
        }
        
    }

    public int TeamNumber { get; private set; }
    public int BushSpawnCount { get; private set; }
    public int ItemCount { get; private set; }
    public int PlayerGold { get; private set; }
    public int OpponentGold { get; private set; }
    public List<Item> Items { get; private set; }
    public List<Entity> Entities { get; set; }

    public bool GameRound
    {
        get
        {
            return _gameRound;
        }
        set
        {
            _gameRound = value;
            _heroRound = !value;
        }
    }
    public bool HeroRound
    {
        get
        {
            return _heroRound;
        }
        set
        {
            _heroRound = value;
            _gameRound = !value;
        }
    }

    public int EntityCount { get; private set; }
}

public class Item
{
    public Item(string name, int cost, int damage, int health, int maxhealth, int mana, int maxmana, int speed, int regeneration, bool ispotion)
    {
        Name = name;
        Cost = cost;
        Damage = damage;
        Health = health;
        MaxHealth = maxhealth;
        Mana = mana;
        MaxMana = maxmana;
        Speed = speed;
        Regeneration = regeneration;
        isPotion = ispotion;
    }

    public string Name { get; private set; }
    public int Cost { get; private set; }
    public int Damage { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Mana { get; private set; }
    public int MaxMana { get; private set; }
    public int Speed { get; private set; }
    public int Regeneration { get; private set; }
    public bool isPotion { get; private set; }
}
public class Hero:Entity
{
    public int Cooldown1 { get; set; }
    public int Cooldown2 { get; set; }
    public int Cooldown3 { get; set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    public int ManaRegeneration { get; set; }
    public string HeroType { get; set; }
    public bool Visible { get; set; }
    public int ItemCount { get; set; }
}

public class Entity
{
    public Vector Position { get; set; }

    public float X => Position.X;
    public float Y => Position.Y;

    public int Id { get; set; }
    public int Team { get; set; }
    public string UnitType { get; set; }
    public int Range { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Shield { get; set; }
    public int Damage { get; set; }
    public int Speed { get; set; }
    public int StunDuration { get; set; }
    public int GoldValue { get; set; }
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