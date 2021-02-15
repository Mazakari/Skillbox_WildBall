using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelPausePopup = null;
    [SerializeField] private GameObject _levelPauseButton = null;

    // Start is called before the first frame update
    void Start()
    {
        if (_levelPauseButton != null)
        {
            _levelPauseButton.SetActive(true);
        }

        if (_levelPausePopup != null)
        {
            _levelPausePopup.SetActive(false);
        }
        
    }
}
