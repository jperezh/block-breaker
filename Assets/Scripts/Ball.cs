using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool ballAttached = true;
    private Rigidbody2D m_rigidbody;

    // Use this for initialization
    void Start () {
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!ballAttached)
            gameObject.GetComponent<AudioSource>().Play();

        Vector2 tweek = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        m_rigidbody.velocity += tweek;
    }

    // Update is called once per frame
    void Update () {
        if (ballAttached) {
            transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0)) {
                //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*1000);
                m_rigidbody.velocity = new Vector2(1f, 10f);
                ballAttached = false;
            }
        }
    }
}
