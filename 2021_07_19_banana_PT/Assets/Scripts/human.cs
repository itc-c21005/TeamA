using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{

	private CharacterController enemyController;
	//private Animator animator;
	//�@�ړI�n
	private Vector3 destination;
	//�@�����X�s�[�h
	[SerializeField]
	private float walkSpeed = 1.0f;
	//�@���x
	private Vector3 velocity;
	//�@�ړ�����
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

	int i = 0; //point�p�ϐ�
	//int g = 0; //gimmickpoint�p�ϐ�

	bool stopflag = false;

	private int randompoint;

	private GameObject nearObj;         //�ł��߂��I�u�W�F�N�g

	private float searchTime = 0;    //�o�ߎ���

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

		//�o�ߎ��Ԃ��擾
		//searchTime += Time.deltaTime;

		searchTime += 0.1f;

		//if (searchTime >= 1.0f)
		//{

		//�ł��߂������I�u�W�F�N�g���擾
		nearObj = serchTag(gameObject, "point");

		//�o�ߎ��Ԃ�������
		searchTime = 0;

		destination = new Vector3(nearObj.transform.position.x, nearObj.transform.position.y, nearObj.transform.position.z);

		//}
	}

	//�w�肳�ꂽ�^�O�̒��ōł��߂����̂��擾
	GameObject serchTag(GameObject nowObj, string point)
	{
		//Debug.Log("ok");

		float tmpDis = 0;           //�����p�ꎞ�ϐ�

		float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���

		string nearObjName = "";    //�I�u�W�F�N�g����

		GameObject targetObj = null; //�I�u�W�F�N�g

		//�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
		foreach (GameObject obs in GameObject.FindGameObjectsWithTag(point))
		{
			//���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
			tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

			//�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
			//�ꎞ�ϐ��ɋ������i�[
			if (nearDis == 0 || nearDis > tmpDis)
			{
				nearDis = tmpDis;
				nearObjName = obs.name;
				targetObj = obs;
			}

		}
		//�ł��߂������I�u�W�F�N�g��Ԃ�
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
