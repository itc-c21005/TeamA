using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{

	private CharacterController enemyController;
	//private Animator animator;
	//　目的地
	private Vector3 destination;
	//　歩くスピード
	[SerializeField]
	private float walkSpeed = 1.0f;
	//　速度
	private Vector3 velocity;
	//　移動方向
	private Vector3 direction;

	public string pointtag;
	public string north;
	public string south;

	public GameObject Fire;
	public GameObject floornorth;
	public GameObject floorsouth;
	public GameObject banana;

	public GameObject[] point;
	//public GameObject[] gimmickpoint;

	public Firegimmick FG;

	int i = 0; //point用変数
	//int g = 0; //gimmickpoint用変数

	bool stopflag = false;

	private int randompoint;

	private GameObject nearObj;         //最も近いオブジェクト

	private float searchTime = 0;    //経過時間

	//private bool searchflag = true;

	public bool csflag = false;

	private int stalker;


	// Use this for initialization
	void Start()
	{
		Application.targetFrameRate = 60;
		enemyController = GetComponent<CharacterController>();
		//animator = GetComponent<Animator>();
		destination = new Vector3(point[0].transform.position.x, point[0].transform.position.y, point[0].transform.position.z);
		velocity = Vector3.zero;
	}

	// Update is called once per frame
	void Update()
	{
		if (enemyController.isGrounded)
		{
			velocity = Vector3.zero;
			//animator.SetFloat("Speed", 2.0f);
			direction = (destination - transform.position).normalized;
			if(!stopflag) transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
			velocity = direction * walkSpeed;
			//Debug.Log(destination);
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		enemyController.Move(velocity * Time.deltaTime);

        if (csflag)
        {
			destination = new Vector3(banana.transform.position.x, banana.transform.position.y, banana.transform.position.z);
			stalker++;
			if (stalker > 300)
            {
				Search();
				csflag = false;
				stalker = 0;
			}

		}

		//ebug.Log(FG.fireflag);
		//Debug.Log(i);
		//Debug.Log(stopflag);
	}

	private void Search()
	{

		//経過時間を取得
		//searchTime += Time.deltaTime;

		searchTime += 0.1f;

		//if (searchTime >= 1.0f)
		//{

		//最も近かったオブジェクトを取得
		nearObj = serchTag(gameObject, "point");

		//経過時間を初期化
		searchTime = 0;

		destination = new Vector3(nearObj.transform.position.x, nearObj.transform.position.y, nearObj.transform.position.z);

		//}
	}

	//指定されたタグの中で最も近いものを取得
	GameObject serchTag(GameObject nowObj, string point)
	{
		//Debug.Log("ok");

		float tmpDis = 0;           //距離用一時変数

		float nearDis = 0;          //最も近いオブジェクトの距離

		string nearObjName = "";    //オブジェクト名称

		GameObject targetObj = null; //オブジェクト

		//タグ指定されたオブジェクトを配列で取得する
		foreach (GameObject obs in GameObject.FindGameObjectsWithTag(point))
		{
			//自身と取得したオブジェクトの距離を取得
			tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

			//オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
			//一時変数に距離を格納
			if (nearDis == 0 || nearDis > tmpDis)
			{
				nearDis = tmpDis;
				nearObjName = obs.name;
				targetObj = obs;
			}

		}
		//最も近かったオブジェクトを返す
		return GameObject.Find(nearObjName);
		//return targetObj;
	}

	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == pointtag && !FG.fireflag)
        {
			StartCoroutine(PointSlide());
		}

		if(FG.fireflag)
        {
			if(other.gameObject == point[4] || other.gameObject == point[5])
            {
				floornorth.SetActive(false);
				floorsouth.SetActive(false);
				StartCoroutine(FireGimmickStop());
            }

			if(other.gameObject == point[6])
            {
				stopflag = true;
            }
        }

	}

    private void OnTriggerStay(Collider styother)
    {
		if (FG.fireflag)
		{
			if (styother.gameObject.tag == north)
			{
				i = 4;
				destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
			}

			if (styother.gameObject.tag == south)
			{
				i = 5;
				destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
			}
		}
	}

    private IEnumerator PointSlide()
    {
		yield return new WaitForSeconds(3);

        switch (i)
        {
			case 0:
				randompoint = Random.Range(1, 4);
                switch (randompoint)
                {
					case 1:
						i = 5;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 2:
						i = 3;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 3:
						i = 1;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;
				}
				break;

			case 1:
				randompoint = Random.Range(1, 3);
				switch (randompoint)
				{
					case 1:
						i = 0;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 2:
						i = 2;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;
				}
				break;

			case 2:
				randompoint = Random.Range(1, 3);
				switch (randompoint)
				{
					case 1:
						i = 1;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 2:
						i = 3;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;
				}
				break;

			case 3:
				randompoint = Random.Range(1, 4);
				switch (randompoint)
				{
					case 1:
						i = 4;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 2:
						i = 0;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 3:
						i = 2;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;
				}
				break;

			case 4:
				randompoint = Random.Range(1, 3);
				switch (randompoint)
				{
					case 1:
						i = 5;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 2:
						i = 3;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;
				}
				break;

			case 5:
				randompoint = Random.Range(1, 3);
				switch (randompoint)
				{
					case 1:
						i = 0;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;

					case 2:
						i = 4;
						destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
						break;
				}
				break;
		}
	}

    IEnumerator FireGimmickStop()
    {
		i = 6;
		destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);

		yield return new WaitForSeconds(5);
        if (stopflag)
        {
			i = 7;
			destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
			yield return new WaitForSeconds(5);
			FG.fireflag = false;
			stopflag = false;
		}
		//FG.fireflag = false;
		//stopflag = false;

		if (!stopflag)
        {
			i = 4;
			destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
		}
		//StopCoroutine(FireGimmickStop());
	}

	public bool CsFlag(bool flag)
    {
		return csflag = flag;
    }

}
