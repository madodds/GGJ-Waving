using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoshArm : MonoBehaviour {
    Rigidbody2D rigidBody;
    bool leftDown = false;
    bool rightDown = false;
    float torqueSpeed = 5f;
    float prevTorque;

    public WaveIndicator left;
    public WaveIndicator middle;
    public WaveIndicator right;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A) && !leftDown)
        {
            GetComponent<Rigidbody2D>().AddTorque(torqueSpeed, ForceMode2D.Impulse);
            prevTorque = 5f;
            leftDown = true;
        }
        else if(Input.GetKeyUp(KeyCode.A) && leftDown)
        {
            leftDown = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && !rightDown)
        {
            GetComponent<Rigidbody2D>().AddTorque(-torqueSpeed, ForceMode2D.Impulse);
            prevTorque = -5f;
            rightDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.D) && rightDown)
        {
            rightDown = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == left.gameObject)
        {
            Debug.Log("Left");
            if (!right.Highlighted && !middle.Highlighted)
            {
                left.Highlighted = true;
            }
            else if (right.Highlighted && !middle.Highlighted)
            {
                right.Highlighted = false;
            }
            else if(left.Highlighted && middle.Highlighted)
            {
                left.Highlighted = false;
                middle.Highlighted = false;
            }
            else if(right.Highlighted && middle.Highlighted)
            {
                left.Highlighted = true;
            }
        }
        else if (col.gameObject == right.gameObject)
        {
            if (!left.Highlighted && !middle.Highlighted)
            {
                right.Highlighted = true;
            }
            else if (left.Highlighted && !middle.Highlighted)
            {
                left.Highlighted = false;
            }
            else if (right.Highlighted && middle.Highlighted)
            {
                right.Highlighted = false;
                middle.Highlighted = false;
            }
            else if (left.Highlighted && middle.Highlighted)
            {
                right.Highlighted = true;
            }
        }

        if(col.gameObject == middle.gameObject && (left.Highlighted || right.Highlighted))
        {
            middle.Highlighted = true;
        }
    }
}
