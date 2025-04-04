using UnityEngine;

public interface IMovementStrategy
{
    void Move(Transform transform);
}

public class WalkStrategy : IMovementStrategy
{
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 2);
        Debug.Log("Walking...");
    }
}

public class RunStrategy : IMovementStrategy
{
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
        Debug.Log("Running...");
    }
}

public class FlyStrategy : IMovementStrategy
{
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.up * Time.deltaTime * 3);
        Debug.Log("Flying...");
    }
}

public class Character : MonoBehaviour
{
    private IMovementStrategy _movementStrategy;

    public void SetMovementStrategy(IMovementStrategy strategy) => _movementStrategy = strategy;

    private void Update()
    {
        _movementStrategy?.Move(transform);

        if (Input.GetKeyDown(KeyCode.W)) SetMovementStrategy(new WalkStrategy());
        if (Input.GetKeyDown(KeyCode.R)) SetMovementStrategy(new RunStrategy());
        if (Input.GetKeyDown(KeyCode.F)) SetMovementStrategy(new FlyStrategy());
    }
}