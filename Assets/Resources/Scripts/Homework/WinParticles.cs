using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinParticles : MonoBehaviour
{
    private ParticleSystem[] _winParticles = null;

    // Start is called before the first frame update
    void Start()
    {
        _winParticles = GetComponentsInChildren<ParticleSystem>();
        
        for (int i = 0; i < _winParticles.Length; i++)
        {
            ParticleSystem.MainModule main = _winParticles[i].main;
            main.loop = false;
            main.useUnscaledTime = true;
            main.stopAction = ParticleSystemStopAction.Disable;

            _winParticles[i].Stop();
        }
    }

    public void PlayWinParticles()
    {
        for (int i = 0; i < _winParticles.Length; i++)
        {
            _winParticles[i].Play();
        }
    }
}
