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

	public GameObject[] point;

	int i = 0;

	// Use this for initialization
	void Start()
	{
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
			transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
			velocity = direction * walkSpeed;
			//Debug.Log(destination);
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		enemyController.Move(velocity * Time.deltaTime);
	}

	public void PointFind()
    {
		StartCoroutine(PointSlide());
	}

	private IEnumerator PointSlide()
    {
		yield return new WaitForSeconds(3);
		i = i + 1;
		if (i == 6) i = 0;
		destination = new Vector3(point[i].transform.position.x, point[i].transform.position.y, point[i].transform.position.z);
		Debug.Log(i);
	}
}
