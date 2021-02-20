using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    private PlayerDeath _playerDeath = null;

    private void Start()
    {
        _playerDeath = FindObjectOfType<PlayerDeath>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _playerDeath.PlayerDied();
        }
    }
}
