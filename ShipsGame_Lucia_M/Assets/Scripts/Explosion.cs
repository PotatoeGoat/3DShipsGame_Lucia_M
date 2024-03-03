using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Transform whoDied;

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
        if (whoDied != null)
        {
            
            transform.position = whoDied.position;
            transform.rotation = whoDied.rotation;
        }
    }

    public void ActivateExplosion()
    {
        this.gameObject.SetActive(true);
        
        if (explosionParticleSystem != null)
        {
            
            explosionParticleSystem.Play();
        }
    }
}
