using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private float _horizontalMov;
    private float _verticalMov;

    private Vector3 _movement;

    private PlayerMovement _playerMovement = null;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMov = Input.GetAxis("Horizontal");
        _verticalMov = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _movement = new Vector3(_horizontalMov, 0, _verticalMov);

        _playerMovement.MovePlayer(_movement);
    }
}
