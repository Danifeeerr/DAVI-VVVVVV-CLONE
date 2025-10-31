using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Events;
using System.Collections;
public class MenuController : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip level1Music;

    void OnEnable()
    {
        if (menuMusic != null)
        {
            AudioController.Instance.PlayMusic(menuMusic);
        }
    }

    public void LoadScene(SceneAsset escena)
    {
        string nomEscena = escena.name;
        SceneManager.LoadScene(nomEscena);
    }

    public void CloseGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ActivateGameObject(GameObject menuToOpen)
    {
        menuToOpen.SetActive(true);
    }
    public void DeactivateGameObject(GameObject menuToClose)
    {
        menuToClose.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void Play()
    {
        AudioController.Instance.PlayMusic(level1Music);
    }
}
