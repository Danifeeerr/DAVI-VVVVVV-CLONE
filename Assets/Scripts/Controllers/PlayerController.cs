using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{
    public UnityEvent winner;
    private MovementSystem _mv;
    private GravitySystem _gs;
    private float fruitCounter = 0;

    public float speed = 7f;

    public Vector3 startPosition;
    public GameObject pauseMenu;

    private HealthSystem _hS = null;

    private bool isOnGround = false;
    public GameObject groundToucher;

    private InputSystem_Actions _inputSA;
    private Vector2 _moveValue;
    private Rigidbody2D _rb;

    //-----------------------------------Funcions d'inicialització-----------------------------------//
    void Start()
    {
        ScreenController.Initialize();
    }

    private void OnEnable()
    {
        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<GravitySystem>(out _gs);
        TryGetComponent<HealthSystem>(out _hS);
        TryGetComponent<Rigidbody2D>(out _rb);
        startPosition = transform.position;
        fruitCounter = 0;

        _inputSA = new InputSystem_Actions();
        _inputSA.Player.Enable();
        _inputSA.Player.Move.canceled += OnStop;
        _inputSA.Player.Move.performed += OnMove;
        _inputSA.Player.Jump.performed += OnGravityChange;
        _inputSA.Player.Pause.performed += OpenPauseMenu;
    }

    //-----------------------------------Funcions d'Input System-----------------------------------//
    private void OnMove(InputAction.CallbackContext c)
    {
        _moveValue = c.ReadValue<Vector2>();
    }

    private void OnStop(InputAction.CallbackContext c)
    {
        _moveValue = Vector2.zero;
    }

    private void OnGravityChange(InputAction.CallbackContext c)
    {
        TryChangeGravity();
    }

    private void OpenPauseMenu(InputAction.CallbackContext c)
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }


    //-----------------------------------Funcions de moviment i gravetat-----------------------------------//
    public void TryChangeGravity()
    {
        if (_gs != null && isOnGround)
        {
            _gs.ChangeGravity();
            isOnGround = false;
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


    //-----------------------------------Altres funcions-----------------------------------//

    public void fruitGrabbed()
    {
        Debug.Log("frutita");
        fruitCounter += 1;
        if (fruitCounter == 3)
        {
            winner.Invoke();
        }
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////

    void FixedUpdate()
    {

        //Comrprovem si estem tocant terra
        isOnGround = Physics2D.OverlapCircle(groundToucher.transform.position, 0.3f, LayerMask.GetMask("ground"));
       
        //Apliquem el moviment amb el vector direccional que ens dona l'input system
        Vector3 direction = new Vector3(_moveValue.x, _rb.linearVelocity.y * Time.deltaTime, 0);
        _mv.Move(direction, speed);


        //Girem el personatge segons la direcció del moviment
        if (_moveValue.x > 0.01f)
        {
            transform.localScale = new Vector3(0.4f, transform.localScale.y, 0.4f);
        }
        else if (_moveValue.x < -0.01f)
        {
            transform.localScale = new Vector3(-0.4f, transform.localScale.y, 0.4f);
        }
    }

    
    
}