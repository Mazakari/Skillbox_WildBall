using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private ParticleSystem _particleSystem = null;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public void PlayerDeathEffect()
    {
        _particleSystem.Play();
    }
}
