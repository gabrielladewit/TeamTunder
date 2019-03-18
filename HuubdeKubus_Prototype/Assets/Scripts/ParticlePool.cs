using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool SharedInstance;
    public GameObject explosion;
    public GameObject starParticle;

    public int explosionAmount = 10;
    List<GameObject> explosions;
    List<GameObject> starParticles;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        explosions = new List<GameObject>();

        for (int i = 0; i < explosionAmount; i++)
        {
            GameObject exp = (GameObject)Instantiate(explosion);
            exp.SetActive(false);
            explosions.Add(exp);
        }
    }

    public GameObject GetPooledParticles()
    {
        for (int i = 0; i < explosions.Count; i++)
        {
            if (!explosions[i].activeInHierarchy)
            {
                return explosions[i];
            }
        }
        return null;

    }
}