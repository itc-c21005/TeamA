using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananacontrolle : MonoBehaviour
{

    public float bspeed_x;
    public float bspeed_z;
    public float higth;

    Vector3 movebanana = Vector3.zero;
    private Rigidbody rgd;

    public float fSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetAxis("Vertical") != 0.0f)
        {
            rgd.angularVelocity = new Vector3(Input.GetAxis("Vertical") * bspeed_x, 0, 0);
        }

        if(Input.GetAxis("Horizontal") != 0.0f)
        {
            rgd.angularVelocity = new Vector3(0, 0, Input.GetAxis("Horizontal") * bspeed_z);
        }*/

        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
        Vector3 left = Camera.main.transform.TransformDirection(Vector3.left);
        Vector3 moveDirection = Input.GetAxis("Horizontal") * -forward + Input.GetAxis("Vertical") * -left;
        //transform.Rotate((moveDirection * fSpeed * Time.deltaTime), Space.World);
        rgd.angularVelocity = (moveDirection * fSpeed * Time.deltaTime);


    }

    //ƒWƒƒƒ“ƒv‚ÍŒã‰ñ‚µ
    /*private void OnCollisionStay(Collision collision)
    {
        if (Input.GetButton("Jump"))
        {
            rgd.velocity = new Vector3(0, higth, 0);
        }
    }*/
}
