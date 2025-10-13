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


    void OnEnable()
    {
        TryGetComponent<MovementSystem>(out _mS);
        if (position1 != null && position2 != null && _mS != null)
        {
            transform.position = position1.position;
            targetPosition = position2.position;
        }
    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            targetPosition = targetPosition == position1.position ? position2.position : position1.position;
        }
    }


}
