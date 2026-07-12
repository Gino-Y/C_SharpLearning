namespace TLS_HX.Lesson09_Practice2;

public class Lesson09_Practice2
{
    public static void Run()
    {
        Player player = new Player("张三", 100, 10, 5);
        player.SelfKill();
        Console.WriteLine(player.hp);
    }
}

public class Player
{
    public string name{get; set;} = "Unknown";
    public int hp{get; set;} = 100;
    public int attack{get; set;} = 10;
    public int defense{get; set;} = 5;

    public Player(string name, int hp, int attack, int defense)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
    }

    public void Move()
    {
        Console.WriteLine($"{name} is moving");
    }

    public void Wound(int damage)
    {
        hp -= damage;
    }

    public void Attack(Player target)
    {
        target.hp -= attack;
    }

    public void Defend(int damage)
    {
        hp -= damage;
    }
}

static class Tools
{
    public static void SelfKill(this Player source)
    {
        source.hp = 0;
    }
}