using UnityEngine;

public static class ScreenController {
    private static GameObject _previousScreen;
    private static GameObject _currentScreen;

    private static GameObject _lastCheckpointScreen;

    public static GameObject mainCamera;

    public static void Initialize()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    public static void changeScreen(GameObject screenToLoad)
    {
        _previousScreen.SetActive(false);
        screenToLoad.SetActive(true);
        mainCamera.transform.position = screenToLoad.transform.Find("CameraPosition").gameObject.transform.position;
    }

    public static void restartToLastCheckpoint()
    {
        if (_lastCheckpointScreen != null && _previousScreen != null)
        {
            _currentScreen.SetActive(false);
            changeScreen(_lastCheckpointScreen);
        }
    }

    public static void setPreviousScreen(GameObject previousScreen)
    {
        _previousScreen = previousScreen;
    }

    public static void setCurrentScreen(GameObject currentScreen)
    {
        _currentScreen = currentScreen;
    }

    public static void setLastCheckpointScreen(GameObject lastCheckpointScreen)
    {
        _lastCheckpointScreen = lastCheckpointScreen;
    }

    

}
