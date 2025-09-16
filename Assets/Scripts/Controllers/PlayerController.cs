using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference playerChangeGravity;
    private MovementSystem _mv;
    private GravitySystem _gs;

    private Vector2 dir;
    public float speed = 7f;
    private Rigidbody2D _rb = null;

    void Start()
    {
        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<Rigidbody2D>(out _rb);
        TryGetComponent<GravitySystem>(out _gs);
       _rb.linearDamping = 0f;

        // Suscribir al evento performed (se llama solo una vez al presionar la tecla)
        playerChangeGravity.action.performed += ctx => _gs.ChangeGravity();

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


        if (dir.magnitude < 0.1f)
        {
            _mv.StopMovement();
        }
        Vector3 direction = new Vector3(dir.x, dir.y, 0);
        _mv.Move(direction, speed);



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