using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.Animations;

public class HeartUIController : MonoBehaviour
{

    public HealthSystem _hS;
    public GameObject[] hearts;
    private float heartsId;
    private float currentHealth;
    private SpriteRenderer _sr;
    private float healthOffset = 0f;

    private void OnEnable()
    {
        heartsId = hearts.Length - 1;
        currentHealth = _hS.GetCurrenthealth();
        _hS.OnChangeHealth.AddListener(heartsUpdate);
    }

    private void OnDisable()
    {
        _hS.OnChangeHealth.RemoveListener(heartsUpdate);
    }

    public void heartsUpdate(float newHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].TryGetComponent<SpriteRenderer>(out _sr);
            _sr.enabled = true;
        }
        if (currentHealth > newHealth)
        {
            while (currentHealth > newHealth && heartsId >= 0)
            {
                hearts[(int)heartsId].SetActive(false);
                heartsId--;
                currentHealth--;
                healthOffset += 0.3f;
            }
            StartCoroutine(DisableRenderer(true));
        }
        else if (currentHealth < newHealth)
        {
            while (currentHealth < newHealth && heartsId < hearts.Length - 1)
            {
                heartsId++;
                hearts[(int)heartsId].SetActive(true);
                currentHealth++;
                healthOffset -= 0.3f;
            }
            StartCoroutine(DisableRenderer(false));
        }
    }

    IEnumerator DisableRenderer(bool hurt)
    {
        if (hurt)
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (GameObject heart in hearts)
                {
                    heart.TryGetComponent<SpriteRenderer>(out _sr);
                    _sr.enabled = false;
                }
                yield return new WaitForSeconds(0.1f);
                foreach (GameObject heart in hearts)
                {
                    heart.TryGetComponent<SpriteRenderer>(out _sr);
                    _sr.enabled = true;
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);  
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
        }
        


        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].TryGetComponent<SpriteRenderer>(out _sr);
            _sr.enabled = false;
        }
    }
    public void Update()
    {
        if (_hS == null) return;
        this.transform.position = _hS.transform.position + new Vector3(healthOffset, 0.7f, 0);
    }
}
