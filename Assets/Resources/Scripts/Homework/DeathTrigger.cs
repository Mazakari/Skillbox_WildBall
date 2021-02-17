using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    private PlayerDeath _playerDeath = null;

    private Coroutine _deathDelayCoroutine = null;

    private void Start()
    {
        _playerDeath = FindObjectOfType<PlayerDeath>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (_deathDelayCoroutine != null)
            {
                StopCoroutine(DeathDelay());
            }
            _deathDelayCoroutine = StartCoroutine(DeathDelay());
        }
    }

    private IEnumerator DeathDelay()
    {
        _playerDeath.PlayerDeathEffect();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
