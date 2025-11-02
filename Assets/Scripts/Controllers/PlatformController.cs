using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformController : MonoBehaviour
{
    private MovementSystem _mS;
    private Rigidbody2D _rb;

    public float speed = 2f;
    public Transform position1;
    public Transform position2;

    private Vector3 targetPosition;
    private Vector3 direction;
    private Vector3 lastPosition;
    private Vector3 platformDelta;

    private GameObject playerOnPlatform; // para guardar al jugador encima

    void OnEnable()
    {
        TryGetComponent(out _mS);
        _rb = GetComponent<Rigidbody2D>();

        if (position1 != null && position2 != null)
        {
            transform.position = position1.position;
            targetPosition = position2.position;
            direction = (position2.position - position1.position).normalized;
        }

        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (_mS == null) return;

        // Mover la plataforma
        _mS.Move(direction, speed);

        // Calcular desplazamiento entre frames
        platformDelta = transform.position - lastPosition;
        lastPosition = transform.position;

        // Si hay jugador encima, lo movemos con la plataforma
        if (playerOnPlatform != null)
        {
            playerOnPlatform.transform.position += platformDelta;
        }

        // Invertir dirección si llegamos a destino
        if (Vector3.SqrMagnitude(transform.position - targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == position1.position ? position2.position : position1.position;
            direction = -direction;
        }
    }
}
