using UnityEngine;

public interface ICommand
{
    void Execute();
}

public class JumpCommand : ICommand
{
    private readonly Rigidbody _rigidbody;

    public JumpCommand(Rigidbody rigidbody) => _rigidbody = rigidbody;

    public void Execute() => _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
}

public class PlayerController : MonoBehaviour
{
    private ICommand _jumpCommand;

    private void Start() => _jumpCommand = new JumpCommand(GetComponent<Rigidbody>());

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _jumpCommand.Execute();
    }
}
