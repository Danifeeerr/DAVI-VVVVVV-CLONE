using UnityEngine;
using UnityEngine.Events;

public class FruitController : MonoBehaviour
{

    public UnityEvent OnFruitGrabbed;
    public GameObject fruitIndicator;
    private bool grabbed = false;


    public void FruitGrabbed()
    {
        if (grabbed) return;
        grabbed = true;
        if (fruitIndicator != null)
        {
            fruitIndicator.SetActive(true);
            OnFruitGrabbed.Invoke();
        }
    }
}   
