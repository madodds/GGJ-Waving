using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodLogic : MonoBehaviour {

	public Transform ArmJoint;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Nothing"))
		{
			if (ArmJoint.eulerAngles.z > 150 && ArmJoint.eulerAngles.z < 210)
			{
				int animChoice = Random.Range(0, 4);
				animator.SetTrigger(string.Format("blood_{0}", animChoice));
			}
		}
	}
}
