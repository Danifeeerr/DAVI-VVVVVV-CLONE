using UnityEngine;
using UnityEngine.Events;

public class FruitController : MonoBehaviour
{

    public UnityEvent OnFruitGrabbed;
    public GameObject fruitIndicator;
    private bool grabbed = false;
    public AudioClip FruitSFX;


    public void FruitGrabbed()
    {
        if (grabbed) return;
        grabbed = true;
        AudioController.Instance.PlaySFX(FruitSFX);
        if (fruitIndicator != null)
        {
            fruitIndicator.SetActive(true);
            OnFruitGrabbed.Invoke();
        }
    }
}   
