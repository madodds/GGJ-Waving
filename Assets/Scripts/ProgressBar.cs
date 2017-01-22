using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    float fillAmount = 0;

    GameObject score = GameObject.Find("GameOver");

    int pOneWaves;
    int pTwoWaves;

    float width;



	// Use this for initialization
	void Start () {

        pOneWaves = score.GetComponent<Score>().PlayerOneWaves;

        pTwoWaves = score.GetComponent<Score>().PlayerTwoWaves;

        width = GetComponent<RectTransform>().rect.width;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (name == "PlayerOneBar")
        {
            fillAmount = width / pOneWaves;
        }
        else if (name == "PlayerTwoBar")
        {
            fillAmount = width / pTwoWaves;
        }
		
	}
}
