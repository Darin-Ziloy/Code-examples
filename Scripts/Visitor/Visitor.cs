using UnityEngine;

public interface IVisitor
{
    void Visit(Player player);
    void Visit(Enemy enemy);
}

public interface IVisitable
{
    void Accept(IVisitor visitor);
}

public class Player : IVisitable
{
    public int Health = 100;
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class Enemy : IVisitable
{
    public int Damage = 10;
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class BuffVisitor : IVisitor
{
    public void Visit(Player player)
    {
        player.Health += 20;
        Debug.Log($"Player health increased to {player.Health}");
    }

    public void Visit(Enemy enemy)
    {
        enemy.Damage += 5;
        Debug.Log($"Enemy damage increased to {enemy.Damage}");
    }
}

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Player player = new Player();
        Enemy enemy = new Enemy();
        BuffVisitor buff = new BuffVisitor();

        player.Accept(buff);
        enemy.Accept(buff);
    }
}
