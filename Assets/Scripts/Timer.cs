﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timer;

    public Transform parent;

    Text text;
    

	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();


		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        text.text = timer.ToString("000");
        
		
	}

}
