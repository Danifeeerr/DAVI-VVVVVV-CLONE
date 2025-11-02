using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{

    public float NumberOfFruits = 3;
    private float progress;
    public Scrollbar progressBar;

    private void Start()
    {
        progress = 1 / NumberOfFruits;
        TryGetComponent<Scrollbar>(out progressBar);
    }
    public void ProgressBarUpdate()
    {
        progressBar.value += progress;
    }

}
