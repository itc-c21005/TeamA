using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour
{
    public human human;

    // Start is called before the first frame update
    void Start()
    {
        human = GameObject.Find("tenshu").GetComponent<human>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //StartCoroutine(Pointer());
        human.PointFind();
    }

    /*private IEnumerator Pointer()
    {
        yield return new WaitForSeconds(3);
        human.PointFind();
    }*/

}
