using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private bool _isPaused = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        if (!_isPaused)
        {
            Time.timeScale = 0;
        }
        else if (_isPaused)
        {
            Time.timeScale = 1;
        }

        _isPaused = !_isPaused;
    }
}
