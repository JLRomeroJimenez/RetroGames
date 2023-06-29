using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private GameManager _gameManager;

    [SerializeField] private float paddleLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Transform.position = " + transform.position);
        Debug.Log("Delta time = " + Time.deltaTime);

        _gameManager = FindObjectOfType<GameManager>();

        paddleLimit = 7.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < paddleLimit)
        {
            transform.position += Vector3.right * (Time.deltaTime * speed);
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > -paddleLimit)
        {
            transform.position += Vector3.left * (Time.deltaTime * speed);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (_gameManager.BallOnPlay == false)
            {
                _gameManager.BallOnPlay = true;
            }
            if (_gameManager.GameStarted == false)
            {
                _gameManager.GameStarted = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
        }
    }
}
