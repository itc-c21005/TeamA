using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Transform surch;

    //public Transform surchr;

    //bool flag = false;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(PtoP(surch.gameObject.transform.position, gameObject.transform.position));
    }

    bool PtoP(Vector3 pStart, Vector3 pNext)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        RaycastHit hit;
        float dx = pNext.x - pStart.x;
        float dy = pNext.y - pStart.y;
        float dz = pNext.z - pStart.z;
        float distance = Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
        rb.position = pStart;
        return rb.SweepTest((pNext - pStart).normalized, out hit, distance, QueryTriggerInteraction.UseGlobal);
    }
}
