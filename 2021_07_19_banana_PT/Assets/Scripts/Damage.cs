using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private int HP = 4;
    private int flagHP;
    private bool damageflag = true;
    public string human_body;
    public string knife;
    public string mouse;

    // Start is called before the first frame update
    void Start()
    {
        flagHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(flagHP != HP)
        {
            StartCoroutine(FlagHP());
        }

        if (HP == 0) Destroy(gameObject);

        Debug.Log(HP);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (damageflag){

            if (collision.gameObject.tag == knife) HP -= 1;

            if (collision.gameObject.tag == mouse) HP -= 2;

            if (collision.gameObject.tag == human_body) HP -= 4;

        }
    }

    IEnumerator FlagHP()
    {
        flagHP = HP;
        damageflag = false;
        yield return new WaitForSeconds(5);
        damageflag = true;
    }


}
