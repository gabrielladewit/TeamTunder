using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem Main;
    public ParticleSystem[] Ring;
    public ParticleSystem Flash;
    public ParticleSystem[] Debris;

    void OnEnable()
    {
        for (int i = 0; i < Ring.Length; i++)
        {
            Ring[i].Play();
        }
        Flash.Play();
        if (Debris[0] != null)
        {
            for (int i = 0; i < Debris.Length; i++)
            {
                Debris[i].Play();
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < Ring.Length; i++)
        {
            Ring[i].Clear();
        }
        if (Debris[0] != null)
        {
            for (int i = 0; i < Debris.Length; i++)
            {
                Debris[i].Clear();
            }
        }
        Main.Clear();
        Flash.Clear();
    }
}

