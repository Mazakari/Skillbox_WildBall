using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPopup = null;
    [SerializeField] private GameObject _selectLevelPopup = null;

    void Start()
    {
        _mainMenuPopup.SetActive(true);
        _selectLevelPopup.SetActive(false);
    }

    private void Update()
    {
        ExitGame();
    }

    /// <summary>
    /// Метод для выхода из игры
    /// </summary>
    public void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnButtonExitGame()
    {
        Application.Quit();
    }
}