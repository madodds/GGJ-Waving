using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattArm : MonoBehaviour
{
    Rigidbody2D rigidBody;
    bool leftDown = false;
    bool rightDown = false;
    float torqueSpeed = 5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !leftDown)
        {
            GetComponent<Rigidbody2D>().AddTorque(torqueSpeed, ForceMode2D.Impulse);
            leftDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && leftDown)
        {
            leftDown = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !rightDown)
        {
            GetComponent<Rigidbody2D>().AddTorque(-torqueSpeed, ForceMode2D.Impulse);
            rightDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && rightDown)
        {
            rightDown = false;
        }
    }
}
