using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIndicator : MonoBehaviour {
    bool highlighted = false;

    public bool Highlighted
    {
        get { return highlighted; }
        set { highlighted = value; }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(highlighted)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
	}
}
