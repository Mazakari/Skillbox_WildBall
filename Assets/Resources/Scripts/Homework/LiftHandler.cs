using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftHandler : MonoBehaviour
{
    [SerializeField] private Transform _liftPlatform = null;

    [SerializeField] private LiftButton _liftButton = null;

    [SerializeField] private float _yStartPosition;
    [SerializeField] private float _yTargetPosition;
    [SerializeField] private float _waitingTime = 3f;

    private Vector3 _liftPlatformStartPoint;
    private Vector3 _liftPlatformTargetPoint;

    private float _platfomMoveSpeed = 1f;

    

    private Coroutine _movePlatformCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        _liftPlatformStartPoint = new Vector3(_liftPlatform.position.x, _yStartPosition, _liftPlatform.position.z);
        _liftPlatformTargetPoint = new Vector3(_liftPlatform.position.x, _yTargetPosition, _liftPlatform.position.z);
        _liftPlatform.position = _liftPlatformStartPoint;
    }

    public void ActivateLift()
    {
        if (_movePlatformCoroutine != null)
        {
            StopCoroutine(_movePlatformCoroutine);
        }

        _movePlatformCoroutine = StartCoroutine(movePlatform());
    }
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
