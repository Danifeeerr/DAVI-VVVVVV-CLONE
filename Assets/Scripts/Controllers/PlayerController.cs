using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference playerChangeGravity;
    private MovementSystem _mv;
    private GravitySystem _gs;

    private Vector2 dir;
    public float speed = 7f;
    private Rigidbody2D _rb = null;

    public Vector3 startPosition;

    private HealthSystem _hS = null;

    void Start()
    {
        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<Rigidbody2D>(out _rb);
        TryGetComponent<GravitySystem>(out _gs);
        TryGetComponent<HealthSystem>(out _hS);
       //_rb.linearDamping = 0f;
        startPosition = transform.position;

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

    public void RestartPosition()
    {
        _mv.StopMovement();
        transform.position = startPosition;
        _hS.canGetHurt = false;
        StartCoroutine(SpriteFlicker());
    }

    IEnumerator SpriteFlicker()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

            if (sprite.enabled != false) 
            {
                for (int i = 0; i < 5; i++)
                {
                    sprite.enabled = false;
                    yield return new WaitForSeconds(0.1f);
                    sprite.enabled = true;
                    yield return new WaitForSeconds(0.1f);
                }
                _hS.canGetHurt = true;
            }   
    }
}