using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Attack();
}

public class Zombie : Enemy
{
    public override void Attack() => Debug.Log("Zombie attacks!");
}

public class Factory
{
    public static Enemy CreateEnemy(GameObject prefab, Vector3 position)
    {
        GameObject obj = Object.Instantiate(prefab, position, Quaternion.identity);
        return obj.GetComponent<Enemy>();
    }
}
