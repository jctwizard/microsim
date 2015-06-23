using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour 
{
	public GameObject leftFoot;
	public GameObject rightFoot;
	public float minTime;
	public float maxTime;
	public float minForce;
	public float maxForce;
	private bool leftLegForward;
	
	void Start () 
	{
		MoveLeftLeg();
	}
	
	void Update () 
	{
		if (leftLegForward)
		{
			float randomForce = Random.Range(minForce, maxForce);
			leftFoot.GetComponent<Rigidbody>().AddForceAtPosition(leftFoot.transform.forward * randomForce, leftFoot.transform.position);
		}

		else
		{
			float randomForce = Random.Range(minForce, maxForce);
			rightFoot.GetComponent<Rigidbody>().AddForceAtPosition(rightFoot.transform.forward * randomForce, rightFoot.transform.position);
		}
	}

	IEnumerator MoveLeftLeg ()
	{
		leftLegForward = true;

		float randomTimer = Random.Range(minTime, maxTime);

		yield return new WaitForSeconds(randomTimer);

		MoveRightLeg();
	}

	IEnumerator MoveRightLeg ()
	{
		leftLegForward = false;

		float randomTimer = Random.Range(minTime, maxTime);

		yield return new WaitForSeconds(randomTimer);

		MoveLeftLeg();
	}
}