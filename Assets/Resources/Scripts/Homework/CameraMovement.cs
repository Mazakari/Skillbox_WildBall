using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject _player = null;

    private Vector3 _camOffset;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _camOffset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = _player.transform.position + _camOffset;
    }
}
