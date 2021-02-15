using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody = null;

    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayer(Vector3 movement)
    {
        _rigidbody.AddForce(movement * (speed + Time.fixedDeltaTime));
    }
}
