using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private MovementSystem _mS;
    public float speed;
    public float timeSeconds;
    private Vector3 initialPosition;
    private bool positionSaved = false;


    void OnEnable()
    {
        if (!positionSaved)
        {
            initialPosition = transform.position;
            positionSaved = true;
        }
        transform.position = initialPosition;
        TryGetComponent<MovementSystem>(out _mS);
        StartCoroutine(moveHorizontal());
    }

    IEnumerator moveHorizontal()
    {
        while (true)
        {
            _mS.Move(Vector3.right, speed);
            yield return new WaitForSeconds(timeSeconds);
            _mS.Move(Vector3.left, speed);
            yield return new WaitForSeconds(timeSeconds);
        }
    }
}
