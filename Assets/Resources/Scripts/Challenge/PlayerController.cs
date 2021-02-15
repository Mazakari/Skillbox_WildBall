using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    private Rigidbody _rigidbody = null;
    private Animator _animator = null;
    private bool _isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTrain();
        AnimationController();
    }

    private void MoveTrain()
    {
        if (_isMoving)
        {
            _rigidbody.AddForce(transform.forward * _moveSpeed);
        }  
    }

    public void StartMovement()
    {
        _isMoving = true;
    }

    public void StopMovement()
    {
        _isMoving = false;
    }

    private void AnimationController()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
    }
}
