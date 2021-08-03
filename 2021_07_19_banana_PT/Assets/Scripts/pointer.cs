using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour
{
    public human human;

    // Start is called before the first frame update
    void Start()
    {
        human = GameObject.Find("PeoplePrototype_0008:pCube5").GetComponent<human>();
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
