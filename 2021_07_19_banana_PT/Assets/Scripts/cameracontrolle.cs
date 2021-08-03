using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrolle : MonoBehaviour
{
    Vector3 diff;
    Vector3 targetpos;

    public GameObject target;
    public float followSpeed;
    bool rbuttonflag;
    bool lbuttonflag;

    // Start is called before the first frame update
    void Start()
    {
        diff = target.transform.position - transform.position;
        targetpos = target.transform.position;
    }

    // Update is called once per frame
    /*void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position - diff, Time.deltaTime * followSpeed);
    }*/

    private void Update()
    {
        transform.position += target.transform.position - targetpos;
        targetpos = target.transform.position;

        if (rbuttonflag)
        {
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetpos, Vector3.up, 1 * Time.deltaTime * 200f);
        }

        if (lbuttonflag)
        {
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetpos, Vector3.up, -1 * Time.deltaTime * 200f);
        }


        /*if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            if(mousePosition.x > 960)
            {
                // targetの位置のY軸を中心に、回転（公転）する
                transform.RotateAround(targetpos, Vector3.up, 1 * Time.deltaTime * 200f);
            }

            if (mousePosition.x < 960)
            {
                // targetの位置のY軸を中心に、回転（公転）する
                transform.RotateAround(targetpos, Vector3.up, -1 * Time.deltaTime * 200f);
            }
        }*/
    }

    public void RightButtonDown()
    {
        rbuttonflag = true;
    }

    public void RightButtonUp()
    {
        if (rbuttonflag)
        {
            rbuttonflag = false;
        }
    }

    public void LeftButtonDown()
    {
        lbuttonflag = true;
    }

    public void LeftButtonUp()
    {
        if (lbuttonflag)
        {
            lbuttonflag = false;
        }
    }

}
