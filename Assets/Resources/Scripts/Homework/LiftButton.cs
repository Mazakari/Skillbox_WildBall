using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour
{
    [SerializeField] private GameObject _startLiftTip = null;

    [SerializeField] private LiftHandler _liftHandler = null;

    private bool _isLiftActivated = false;
    public bool IsLiftActivated { get { return _isLiftActivated; } set { _isLiftActivated = value; } }

    private void Start()
    {
        _startLiftTip.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (!_isLiftActivated)
            {
                _startLiftTip.SetActive(true);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && Input.GetKeyDown(KeyCode.E))
        {
            if (!_isLiftActivated)
            {
                _isLiftActivated = !_isLiftActivated;
                _startLiftTip.SetActive(false);
                _liftHandler.ActivateLift();
            }
        }
    }
}
