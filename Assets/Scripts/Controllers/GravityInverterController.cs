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
        yield return new WaitForSeconds(0.1f);
        if (gs != null && gravityInvertable)
        {
            gravityInvertable = false;
            gs.ChangeGravity();
        }
        yield return new WaitForSeconds(0.5f);
        gravityInvertable = true;
   }
}
