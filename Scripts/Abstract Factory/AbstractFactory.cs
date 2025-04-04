using UnityEngine;

public abstract class Enemy
{
    public abstract void Attack();
}

public class Goblin : Enemy
{
    public override void Attack() => Debug.Log("Goblin attacks with a dagger!");
}

public class Orc : Enemy
{
    public override void Attack() => Debug.Log("Orc smashes with a club!");
}

public interface IEnemyFactory
{
    Enemy CreateEnemy();
}

public class GoblinFactory : IEnemyFactory
{
    public Enemy CreateEnemy() => new Goblin();
}

public class OrcFactory : IEnemyFactory
{
    public Enemy CreateEnemy() => new Orc();
}

public class EnemySpawner : MonoBehaviour
{
    private void Start()
    {
        IEnemyFactory goblinFactory = new GoblinFactory();
        IEnemyFactory orcFactory = new OrcFactory();

        Enemy goblin = goblinFactory.CreateEnemy();
        Enemy orc = orcFactory.CreateEnemy();

        goblin.Attack();
        orc.Attack();
    }
}
