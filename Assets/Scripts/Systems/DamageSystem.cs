using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DamageSystem : MonoBehaviour
{
    public float damage = 1.0f;
    public void DoDamage(GameObject gameObject){
        if (gameObject.TryGetComponent<HealthSystem>(out HealthSystem hs))
        {
            hs.Hurt(damage);
        }
    }
}