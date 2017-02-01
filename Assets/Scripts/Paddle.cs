using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool test = false;

    private float mousePosInBlocks;
    private Ball ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (test) {
            AutoMove();
        } else {
            MoveWithMouse();
        }
	}

    private void MoveWithMouse() {
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), transform.position.y, 0f);
        transform.position = paddlePos;
    }

    private void AutoMove() {
        float ballPosX = ball.transform.position.x;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(ballPosX, 0.5f, 15.5f), transform.position.y, 0f);
        transform.position = paddlePos;
    }
}
