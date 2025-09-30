using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private Animator anim;
    public PlayerController _pC;
    public GameObject checkpointLevel;

    private bool checkpointGrabbed = false;
    void Start()
    {
        checkpointGrabbed = false;
        TryGetComponent<Animator>(out anim);
    }

    private void OnEnable()
    {
        if (checkpointGrabbed && anim != null)
        {
            anim.SetBool("CheckpointGrabbed", true);
        }
    }

    // Update is called once per frame
    public void changeAnimationState()
    {
        if (anim != null)
        {
            if (anim.GetBool("CheckpointGrabbed") == false)
            {
                anim.SetBool("CheckpointGrabbed", true);
            }
        }

        if (!checkpointGrabbed && _pC != null)
        {
            checkpointGrabbed = true;
            _pC.startPosition = this.transform.position;
            ScreenController.setLastCheckpointScreen(checkpointLevel);
        }
    }
}
