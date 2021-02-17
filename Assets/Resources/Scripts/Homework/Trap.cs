using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    private PlayerDeath _playerDeath = null;

    private Coroutine _deathDelayCoroutine = null;

    private void Start()
    {
        _playerDeath = FindObjectOfType<PlayerDeath>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            if (_deathDelayCoroutine != null)
            {
                StopCoroutine(DeathDelay(collision));
            }
            _deathDelayCoroutine = StartCoroutine(DeathDelay(collision));
        }
    }

    private IEnumerator DeathDelay(Collision collision)
    {
        _playerDeath.PlayerDeathEffect();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
