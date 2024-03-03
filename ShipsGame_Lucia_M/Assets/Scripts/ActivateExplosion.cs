using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExplosion : MonoBehaviour
{
    ParticleSystem explosionParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        explosionParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateExplosions()
    {
        this.gameObject.SetActive(true);

        if (explosionParticleSystem != null)
        {

            explosionParticleSystem.Play();
        }
    }
}
