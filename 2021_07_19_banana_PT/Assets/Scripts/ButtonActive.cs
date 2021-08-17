using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    public GameObject button;

    void Start()
    {
        button.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "banana")
        {
            button.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        button.SetActive(false);
    }
}
