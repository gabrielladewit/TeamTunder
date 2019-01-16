﻿using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem Main;
    public ParticleSystem[] Ring;
    public SparkParticles Sparks;
    public ParticleSystem Flash;
    public ParticleSystem[] Debris;

    void Start()
    {
        for (int i = 0; i < Ring.Length; i++)
        {
            Ring[i].Play();
        }
        Sparks.Play();
        Flash.Play();
        if (Debris[0] != null)
        {
            for (int i = 0; i < Debris.Length; i++)
            {
                Debris[i].Play();
            }
            Destroy(gameObject, Main.duration);
        }
    }
}

