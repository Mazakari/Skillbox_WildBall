using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private GameObject _openDoorTip = null;// Ссылка на объект с подсказкой (E) для открытия двери

    private Animator _animator = null;// Ссылка на аниматор объекта двери для проигрывания анимаций открытия и закрытия дверей

    private bool _isDoorOpened = false;// Открыта ли дверь
    private bool _isButtonPressed = false;// Нажата ли кнопка открытия двери
    private bool _isTrigger = false;// Находится ли шарик игрока внутри триггера двери

    private void Start()
    {
        _openDoorTip.SetActive(false);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Если шарик игрока находится внутри триггера двери и нажимает кнопку открытия двери
        if (Input.GetKeyDown(KeyCode.E) && _isTrigger)
        {
            _isButtonPressed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Показываем подсказку для открытия двери при входе в триггер двери
        if (other.GetComponent<PlayerMovement>())
        {
            if (!_isDoorOpened)
            {
                _isTrigger = true;
                _openDoorTip.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Если шарик игрока находится внутри триггера двери и нажал кнопку открытия двери = проигрываем анимацию открытия двери
        if (other.GetComponent<PlayerMovement>() && _isButtonPressed)
        {
            if (!_isDoorOpened)
            {
                _isDoorOpened = !_isDoorOpened;
                _openDoorTip.SetActive(false);
                _animator.Play("SlidingDoorAnimation_SlideOut");
                _isButtonPressed = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // При выходе шарика игрока из триггера двери проигрываем анимацию закрытия двери
        if (other.GetComponent<PlayerMovement>() && _isDoorOpened)
        {
            _isDoorOpened = !_isDoorOpened;
            _isTrigger = false;
            _animator.Play("SlidingDoorAnimation_SlideIn");
        }
    }
}
