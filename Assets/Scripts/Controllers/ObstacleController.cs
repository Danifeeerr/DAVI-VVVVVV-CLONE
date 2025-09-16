using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    void Start()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            CollisionSystem playerCollisionSystem = player.GetComponent<CollisionSystem>();
            if (playerCollisionSystem != null)
            {
                TryGetComponent<DamageSystem>(out DamageSystem ds);
                if (ds != null)
                {
                    playerCollisionSystem.Collided.AddListener(ds.DoDamage);
                }
                
            }
        }
    }    

}
