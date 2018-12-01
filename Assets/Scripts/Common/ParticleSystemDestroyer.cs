using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{
    private ParticleSystem particleSystem;

    public void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (!particleSystem.IsAlive())
            Destroy(gameObject);
    }
}
