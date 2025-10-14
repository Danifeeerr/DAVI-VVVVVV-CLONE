using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private MovementSystem _mS;
    public float speed;
    public Transform position1;
    public Transform position2;

    private Vector3 targetPosition;
    private Vector3 direction;


    void OnEnable()
    {
        TryGetComponent<MovementSystem>(out _mS);
        if (position1 != null && position2 != null && _mS != null)
        {
            transform.position = position1.position;
            targetPosition = position2.position;
            direction = (position2.position - position1.position).normalized;
        }
    }
    
    void Update()
    {
        _mS.Move(direction, speed);
        if (Vector3.SqrMagnitude(transform.position - targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == position1.position ? position2.position : position1.position;
            direction = -direction;
        }
    }


}
