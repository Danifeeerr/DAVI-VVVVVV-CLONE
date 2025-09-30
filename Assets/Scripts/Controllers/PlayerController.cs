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

    private bool isOnGround = false;
    public GameObject groundToucher;


    void Start()
    {
        ScreenController.Initialize();
        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<Rigidbody2D>(out _rb);
        TryGetComponent<GravitySystem>(out _gs);
        TryGetComponent<HealthSystem>(out _hS);
        startPosition = transform.position;

        // Suscribir al evento performed (se llama solo una vez al presionar la tecla)
        playerChangeGravity.action.performed += ctx => TryChangeGravity();

    }

    public void TryChangeGravity()
    {
        if (_gs != null && isOnGround)
        {
            _gs.ChangeGravity();
            isOnGround = false;
        }
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
        isOnGround = Physics2D.OverlapCircle(groundToucher.transform.position, 0.3f, LayerMask.GetMask("ground"));
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
        ScreenController.restartToLastCheckpoint();
        if (_gs != null && _gs.isGravityInverted())
        {
            _gs.ChangeGravity();
        }
        transform.position = startPosition;
        _hS.canGetHurt = false;
        StartCoroutine(SpriteFlicker());
    }

    public void setSpawnPosition(Vector3 pos)
    {
        startPosition = pos;
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


    public void SetIsOnGround(GameObject other, GameObject myself)
    {
        if (myself == this.gameObject)
        {
            isOnGround = true;
        }
    }
    
}