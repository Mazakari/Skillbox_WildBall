using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelPausePopup = null;
    [SerializeField] private GameObject _levelPauseButton = null;
    [SerializeField] private GameObject _winPopup = null;

    [SerializeField] private Text _currentLevelNumberText = null;
    [SerializeField] private Text _bonusCounterText = null;

    private GameStateManager _gameStateManager = null;
    private WinParticles _winParticles = null;

    private int _maxLevelBonusCount = 0;
    public int MaxLevelBonusCount { get { return _maxLevelBonusCount; } }

    private int _currentLevelBonusCount = 0;
    public int CurrentLevelBonusCount { get { return _currentLevelBonusCount; } set { _currentLevelBonusCount = value; } }

    private bool _isGameFinished = false;
    public bool IsGameFinished { get { return _isGameFinished; } set { _isGameFinished = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _maxLevelBonusCount = FindObjectsOfType<Pickable>().Length;
        _gameStateManager = FindObjectOfType<GameStateManager>();
        _winParticles = FindObjectOfType<WinParticles>();

        _currentLevelNumberText.text = $"LEVEL {SceneManager.GetActiveScene().buildIndex}";
        _bonusCounterText.text = $"BONUS {_currentLevelBonusCount} / {_maxLevelBonusCount}";

        if (_levelPauseButton != null)
        {
            _levelPauseButton.SetActive(true);
        }

        if (_levelPausePopup != null)
        {
            _levelPausePopup.SetActive(false);
        }
        
    }

    private void Update()
    {
        GameStateControl();
    }

    private void GameStateControl()
    {
        if (_isGameFinished)
        {
            _isGameFinished = false;
            _gameStateManager.PauseGame();
            _winPopup.SetActive(true);
            if (_winParticles != null)
            {
                _winParticles.PlayWinParticles();
            }
        }
    }

    public void UpdateBonusCounter()
    {
        _bonusCounterText.text = $"BONUS {_currentLevelBonusCount} / {_maxLevelBonusCount}";
    }
}
