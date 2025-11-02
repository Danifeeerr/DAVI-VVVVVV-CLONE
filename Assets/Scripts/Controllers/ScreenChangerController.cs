using System.Buffers.Text;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenChangerController : MonoBehaviour
{

    public GameObject _previousScreen;
    public GameObject _newCurrentScreen;

    void OnTriggerEnter2D(Collider2D other)

    {
        ScreenController.setPreviousScreen(_previousScreen);
        ScreenController.setCurrentScreen(_newCurrentScreen);
        ScreenController.changeScreen(_newCurrentScreen);
    }
    

}
