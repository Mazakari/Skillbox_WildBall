using System.Collections;
using System.Collections.Generic;
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
}
