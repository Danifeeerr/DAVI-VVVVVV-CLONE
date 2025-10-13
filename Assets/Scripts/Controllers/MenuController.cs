using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MenuController : MonoBehaviour
{
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
}
