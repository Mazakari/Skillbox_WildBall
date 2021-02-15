using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelLoader : MonoBehaviour
{
    [SerializeField] private int _levelIndexToLoad;

    public void LoadLevel()
    {
        if (_levelIndexToLoad < SceneManager.sceneCountInBuildSettings && _levelIndexToLoad > 0)
        {
            SceneManager.LoadScene(_levelIndexToLoad);
        }
        else
        {
            Debug.Log($"Level {_levelIndexToLoad} not found!");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

