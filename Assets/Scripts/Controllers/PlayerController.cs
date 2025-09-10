using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference playerChangeGravity;
    private MovementSystem _mv;

    private Vector2 dir;
    public float speed = 7;

    void Start()
    {
        TryGetComponent<MovementSystem>(out _mv);

        // Suscribir al evento performed (se llama solo una vez al presionar la tecla)
        playerChangeGravity.action.performed += ctx => _mv.ChangeGravity();
    }

    void OnEnable()
    {
        move.action.Enable();
        playerChangeGravity.action.Enable();
    }

    void OnDisable()
    {
        move.action.Disable();
        playerChangeGravity.action.Disable();
    }

    void FixedUpdate()
    {
        dir = move.action.ReadValue<Vector2>();
        dir = new Vector2(dir.x, 0);
        _mv.MoveTransform(dir, speed * Time.deltaTime);

        if (dir.x > 0.01f)
        {
            transform.localScale = new Vector3(0.4f, transform.localScale.y, 0.4f);
        }
        else if (dir.x < -0.01f)
        {
            transform.localScale = new Vector3(-0.4f, transform.localScale.y, 0.4f);
        }
    }
}