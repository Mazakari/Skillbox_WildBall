using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour
{
    [SerializeField] private GameObject _startLiftTip = null;

    [SerializeField] private LiftHandler _liftHandler = null;

    private bool _isLiftActivated = false;
    public bool IsLiftActivated { get { return _isLiftActivated; } set { _isLiftActivated = value; } }

    private bool _isButtonPressed = false;
    private bool _isTrigger = false;

    private void Start()
    {
        _startLiftTip.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isTrigger)// Попап активен для всех кнопок
        {
            _isButtonPressed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (!_isLiftActivated)
            {
                _isTrigger = true;
                _startLiftTip.SetActive(true);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && _isButtonPressed)
        {
            if (!_isLiftActivated)
            {
                _isLiftActivated = !_isLiftActivated;
                _startLiftTip.SetActive(false);
                _liftHandler.ActivateLift();
                _isButtonPressed = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (!_isLiftActivated)
            {
                _isTrigger = false;
                _startLiftTip.SetActive(false);
            }
        }
    }
}
