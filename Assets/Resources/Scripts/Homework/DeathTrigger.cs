using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    private PlayerDeath _playerDeath = null;

    private void Start()
    {
        _playerDeath = FindObjectOfType<PlayerDeath>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _playerDeath.PlayerDied();
        }
    }
}
