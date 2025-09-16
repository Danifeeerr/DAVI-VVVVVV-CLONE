using UnityEngine;
using UnityEngine.Events;

public class CollisionSystem : MonoBehaviour
{
    public UnityEvent Collided;

    void OnCollisionEnter2D(Collision2D collision)
        {
            Collided.Invoke();
        }
}
