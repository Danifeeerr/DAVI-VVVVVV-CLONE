using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DamageSystem : MonoBehaviour
{
    public float damage = 1.0f;

    public void DoDamage(GameObject other, GameObject myself){
        if (other.TryGetComponent<HealthSystem>(out HealthSystem hs) && myself == this.gameObject)
        {
            hs.Hurt(damage);
        }
    }
}