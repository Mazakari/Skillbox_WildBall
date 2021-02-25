using System.Collections;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pickupParticlesEffect = null;

    private LevelManager _levelManager = null;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        ParticleSystem.MainModule main = _pickupParticlesEffect.main;
        main.loop = false;
        main.playOnAwake = false;
        main.stopAction = ParticleSystemStopAction.Disable;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _pickupParticlesEffect.Play();
            if (_levelManager.CurrentLevelBonusCount < _levelManager.MaxLevelBonusCount)
            {
                _levelManager.CurrentLevelBonusCount++;
                _levelManager.UpdateBonusCounter();
            }
            
            gameObject.SetActive(false);
        }
    }
}
