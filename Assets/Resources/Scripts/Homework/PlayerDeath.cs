using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private ParticleSystem _particleSystem = null;

    private Animator _animator = null;

    private AnimationClip _playerDeadAnimationClip = null;

    private Coroutine _levelRestartDelay;

    // Start is called before the first frame update
    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _animator = GetComponent<Animator>();
        _playerDeadAnimationClip = Resources.Load<AnimationClip>("Animations/Homework/PlayerAnimation_Death");
 
        ParticleSystem.MainModule main = _particleSystem.main;
        main.loop = false;
        main.playOnAwake = false;
        main.stopAction = ParticleSystemStopAction.Disable;
    }

    public void PlayerDeathEffect()
    {
        _particleSystem.Play();
    }

    public void PlayerDied()
    {
       if (_levelRestartDelay != null)
       {
           StopCoroutine(RestaertDelay());
       }

       _levelRestartDelay = StartCoroutine(RestaertDelay());
    }

    private IEnumerator RestaertDelay()
    {
        _animator.Play(_playerDeadAnimationClip.name);
        yield return new WaitForSeconds(_playerDeadAnimationClip.length + 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
