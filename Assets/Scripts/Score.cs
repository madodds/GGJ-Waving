using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	[HideInInspector]
	public int PlayerOneWaves;

	[HideInInspector]
	public int PlayerTwoWaves;

	// Use this for initialization
	void Start ()
	{
		PlayerOneWaves = 0;
		PlayerTwoWaves = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (PlayerOneWaves - PlayerTwoWaves >= 10)
		{

		}
		else if (PlayerTwoWaves - PlayerOneWaves >= 10)
		{

		}
	}
}