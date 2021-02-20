using System.Collections;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pickupParticlesEffect = null;


    private void Awake()
    {
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
            gameObject.SetActive(false);
        }
    }
}
