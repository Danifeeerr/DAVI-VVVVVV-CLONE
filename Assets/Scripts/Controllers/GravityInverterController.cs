using UnityEngine;
using System.Collections;
public class GravityInverterController : MonoBehaviour
{
    private bool gravityInvertable = true;

    void Start()
    {
        gravityInvertable = true;
    }

    IEnumerator OnTriggerStay2D(Collider2D other)
    {
        other.TryGetComponent<GravitySystem>(out GravitySystem gs);
        if (gs != null && gravityInvertable)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            gravityInvertable = false;
            gs.ChangeGravity();
        }
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        gravityInvertable = true;
    }
   
}
