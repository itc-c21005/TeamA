using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firegimmick : MonoBehaviour
{
    public GameObject Fire;

    public bool fireflag;

    void Start()
    {
        Fire.SetActive(false);
        fireflag = false;
    }

    private void Update()
    {
        if (!fireflag)
        {
            Fire.SetActive(false);
        }
    }

    public void FireButtonDown()
    {
        Fire.SetActive(true);
        fireflag = true;
    }
}
