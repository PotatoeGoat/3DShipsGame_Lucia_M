using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float time = 0.0f;

    public float lifeTime = 5f;

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
            this.gameObject.SetActive(false);
            BulletPool.Instance.ReturnBullet(this.gameObject);
        }
    }

    private void OnEnable()
    {

        time = 0.0f;
    }
}
