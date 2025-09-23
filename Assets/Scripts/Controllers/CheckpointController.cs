using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private Animator anim;
    public PlayerController _pC;
    void Start()
    {
        TryGetComponent<Animator>(out anim);
    }

    // Update is called once per frame
    public void changeAnimationState()
    {
        if (anim != null)
        {
            if (anim.GetBool("CheckpointGrabbed") == false)
            {
                anim.SetBool("CheckpointGrabbed", true);
                if (_pC != null)
                {
                    _pC.setSpawnPosition(this.transform.position);
                }
            }
        }
    }
}
