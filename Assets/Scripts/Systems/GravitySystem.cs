using UnityEngine;

public class GravitySystem : MonoBehaviour
{
    private Rigidbody2D _rb = null;

    public void Awake()
    {
        TryGetComponent<Rigidbody2D>(out _rb);
    }

    public void ChangeGravity()
    {
        if (_rb != null)
        {
            _rb.gravityScale = _rb.gravityScale * -1;
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y * -1, this.transform.localScale.z);
        }
    }
}
