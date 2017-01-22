using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    float fillAmount = 0;

   

    int pOneWaves;
    int pTwoWaves;

    float width;

	// Use this for initialization
	void Start () {

        GameObject score = GameObject.Find("GameOver");

        pOneWaves = score.GetComponent<Score>().PlayerOneWaves;

        pTwoWaves = score.GetComponent<Score>().PlayerTwoWaves;

        width = GetComponent<RectTransform>().rect.size.x;

        width = 0;




		
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

        width = fillAmount;
		
	}
}
