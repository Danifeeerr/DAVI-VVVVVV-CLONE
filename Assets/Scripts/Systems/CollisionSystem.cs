using UnityEngine;
using UnityEngine.Events;


public class CollisionSystem : MonoBehaviour
{
    public UnityEvent<GameObject, GameObject> Collided;
    public UnityEvent<GameObject, GameObject> Triggered;
    public UnityEvent<GameObject, GameObject> CollidedExit;

    private GameObject myself;

    void Start()
    {
        myself = this.gameObject;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collided.Invoke(myself, collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Triggered.Invoke(myself, other.gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        CollidedExit.Invoke(myself, collision.gameObject);
    }
}
