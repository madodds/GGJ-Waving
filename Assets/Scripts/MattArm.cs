using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattArm : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Score gameOver;

    bool leftDown = false;
    bool rightDown = false;
    float torqueSpeed = 5f;
    float prevTorque;

    public WaveIndicator left;
    public WaveIndicator middle;
    public WaveIndicator right;
    // Use this for initialization
    void Start ()
    {
        gameOver = FindObjectOfType<Score>();

    }
    public void Restart()
    {
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        right.Highlighted = false;
        middle.Highlighted = false;
        left.Highlighted = false;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == left.gameObject)
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
            else if (left.Highlighted && middle.Highlighted)
            {
                left.Highlighted = false;
                middle.Highlighted = false;
            }
            else if (right.Highlighted && middle.Highlighted)
            {
                left.Highlighted = true;
                right.Highlighted = false;
                middle.Highlighted = false;
                left.Highlighted = false;
                gameOver.PlayerTwoWaves++;
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
                right.Highlighted = false;
                middle.Highlighted = false;
                left.Highlighted = false;
                gameOver.PlayerTwoWaves++;
            }
        }

        if (col.gameObject == middle.gameObject && (left.Highlighted || right.Highlighted))
        {
            middle.Highlighted = true;
        }
    }
}
