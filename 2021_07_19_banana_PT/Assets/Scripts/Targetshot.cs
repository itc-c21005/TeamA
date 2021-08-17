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
                    GameObject runcherBullet = GameObject.Instantiate(bullet) as GameObject; //runcherbullet��bullet�̃C���X�^���X���i�[
                    runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //�A�^�b�`���Ă���I�u�W�F�N�g�̑O����bullet speed�̑����Ŕ���
                    runcherBullet.transform.position = transform.position;
                }
            }
        }
    }
}
