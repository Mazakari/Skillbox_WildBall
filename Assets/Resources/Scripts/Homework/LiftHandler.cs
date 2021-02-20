using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftHandler : MonoBehaviour
{
    [SerializeField] private Transform _liftPlatform = null;// Ссылка на объект, который будет работать как лифт

    [SerializeField] private LiftButton _liftButton = null;// Ссылка на объект, который будет кнопкой активации лифта

    [SerializeField] private float _yStartPosition = 0f;// Начальное значение высоты (Y) для точки А объекта _liftPlatform
    [SerializeField] private float _yTargetPosition = 0f;// Конечное значение высоты (Y) для точки B объекта _liftPlatform
    [SerializeField] private float _waitingTime = 3f;// Время нахождения _liftPlatform между точками A и B

    private Vector3 _liftPlatformStartPoint;// Координаты для точки A для платформы лифта
    private Vector3 _liftPlatformTargetPoint;// Координаты для точки B для платформы лифта

    private float _platfomMoveSpeed = 1f;// Скорость движения _liftPlatform

    private Coroutine _movePlatformCoroutine = null;// Переменная для хранения корутины для движения _liftPlatform

    // Start is called before the first frame update
    void Start()
    {
        _liftPlatformStartPoint = new Vector3(_liftPlatform.position.x, _yStartPosition, _liftPlatform.position.z);
        _liftPlatformTargetPoint = new Vector3(_liftPlatform.position.x, _yTargetPosition, _liftPlatform.position.z);
        _liftPlatform.position = _liftPlatformStartPoint;
    }

    /// <summary>
    /// Активирует курутину для движения лифта
    /// </summary>
    public void ActivateLift()
    {
        if (_movePlatformCoroutine != null)
        {
            StopCoroutine(_movePlatformCoroutine);
        }

        _movePlatformCoroutine = StartCoroutine(movePlatform());
    }
    /// <summary>
    /// Поднимает и опускает лифт между двумя точками
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator movePlatform()
    {
       float lerpAmount = 0;

       while (Vector3.Distance(_liftPlatform.position, _liftPlatformTargetPoint) > 0.0001f)
       {
            lerpAmount += Time.fixedDeltaTime * _platfomMoveSpeed;
            _liftPlatform.position = Vector3.Lerp(_liftPlatformStartPoint, _liftPlatformTargetPoint, lerpAmount);

            yield return new WaitForFixedUpdate();
       }

        yield return new WaitForSeconds(_waitingTime);
        
       lerpAmount = 0;
       while (Vector3.Distance(_liftPlatform.position, _liftPlatformStartPoint) > 0.0001f)
       {
            lerpAmount += Time.fixedDeltaTime * _platfomMoveSpeed;
            _liftPlatform.position = Vector3.Lerp(_liftPlatformTargetPoint, _liftPlatformStartPoint, lerpAmount);

            yield return new WaitForFixedUpdate();
       }

        _liftButton.IsLiftActivated = false;

        yield return null;
    }
}
