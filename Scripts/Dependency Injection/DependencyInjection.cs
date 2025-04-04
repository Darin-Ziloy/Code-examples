using UnityEngine;

public interface IWeapon
{
    void Shoot();
}

public class Gun : IWeapon
{
    public void Shoot() => Debug.Log("Bang!");
}

public class Player
{
    private IWeapon _weapon;

    public Player(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Attack() => _weapon.Shoot();
}

public class Game : MonoBehaviour
{
    private void Start()
    {
        IWeapon gun = new Gun();  // Создаём зависимость
        Player player = new Player(gun);  // Внедряем её в Player
        player.Attack();
    }
}
