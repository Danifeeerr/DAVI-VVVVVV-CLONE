
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButonsGamepadController : MonoBehaviour

{
    public GameObject firstSelectedButton;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }
}
