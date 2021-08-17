using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CensoreBullet : MonoBehaviour
{

    private human tenshusc;
    public GameObject tenshu;
    public string banana;
    public string censore;

    // Start is called before the first frame update
    void Start()
    {
        tenshu = GameObject.Find("tenshu");
        tenshusc = tenshu.GetComponent<human>();
        Invoke("Des", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == banana)
        {
            tenshusc.CsFlag(true);
            Destroy(gameObject);
        }
    }

    private void Des()
    {
        Destroy(gameObject);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == banana)
        {
            tenshu.CsFlag(true);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == censore)
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }*/
}
