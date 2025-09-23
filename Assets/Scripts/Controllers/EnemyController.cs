using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private MovementSystem _mS;
    public float speed;
    public float timeSeconds;
    void OnEnable()
    {
        TryGetComponent<MovementSystem>(out _mS);
        StartCoroutine(moveHorizontal());
    }


    // Update is called once per frame
    void Update()
    {

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
