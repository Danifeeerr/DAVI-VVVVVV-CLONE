using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MenuController : MonoBehaviour
{
    public AudioClip menuMusic;

    void OnEnable()
    {
        AudioController.Instance.PlayMusic(menuMusic);
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
}
