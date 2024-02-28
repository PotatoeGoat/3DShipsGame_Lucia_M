using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float time = 0.0f;

    public float lifeTime = 5f;

    [SerializeField]
    LifeSystem lifeSystem;

    //hago referencia a la nave enemiga

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime)
        {
            DesactivateBullets();
        }
    }

    private void OnEnable()
    {

        time = 0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            DesactivateBullets();
        }

        if (collision.gameObject.tag == "enemy")
        {
            DesactivateBullets();

            
        }
    }

    void DesactivateBullets()
    {
        this.gameObject.SetActive(false);
        BulletPool.Instance.ReturnBullet(this.gameObject);
    }
}
