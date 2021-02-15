using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private GameObject _openDoorTip = null;

    private Animator _animator = null;

    private bool _isDoorOpened = false;

    private void Start()
    {
        _openDoorTip.SetActive(false);
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (!_isDoorOpened)
            {
                _openDoorTip.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && Input.GetKeyDown(KeyCode.E))
        {
            if (!_isDoorOpened)
            {
                _isDoorOpened = !_isDoorOpened;
                _openDoorTip.SetActive(false);
                _animator.Play("SlidingDoorAnimation_SlideOut");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && _isDoorOpened)
        {
            _isDoorOpened = !_isDoorOpened;
            _animator.Play("SlidingDoorAnimation_SlideIn");
        }
    }
}
