using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shottest : MonoBehaviour
{

    public GameObject bullet;

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0.1f, 0);
        if (Input.GetKeyDown("space"))
        {
            GameObject runcherBullet = GameObject.Instantiate(bullet) as GameObject; //runcherbulletにbulletのインスタンスを格納
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.position = transform.position;
        }
    }
}
