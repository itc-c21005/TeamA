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
            GameObject runcherBullet = GameObject.Instantiate(bullet) as GameObject; //runcherbullet��bullet�̃C���X�^���X���i�[
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //�A�^�b�`���Ă���I�u�W�F�N�g�̑O����bullet speed�̑����Ŕ���
            runcherBullet.transform.position = transform.position;
        }
    }
}
