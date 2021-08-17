using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetshot : MonoBehaviour
{
    public string banana;

    public GameObject bullet;

    public float bulletSpeed;

    int shotcount = 0;

    private human tenshusc;
    public GameObject tenshu;

    // Start is called before the first frame update
    void Start()
    {
        tenshu = GameObject.Find("tenshu");
        tenshusc = tenshu.GetComponent<human>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == banana)
        {
            if (!tenshusc.csflag)
            {
                shotcount++;
                if (shotcount > 50)
                {
                    shotcount = 0;
                    GameObject runcherBullet = GameObject.Instantiate(bullet) as GameObject; //runcherbulletにbulletのインスタンスを格納
                    runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
                    runcherBullet.transform.position = transform.position;
                }
            }
        }
    }
}
