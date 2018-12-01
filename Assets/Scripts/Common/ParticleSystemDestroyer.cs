using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{
    private ParticleSystem particles;

    public void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (!particles.IsAlive())
            Destroy(gameObject);
    }
}
