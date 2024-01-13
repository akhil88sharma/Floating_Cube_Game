using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D playerRB;
    bool isGround;
    public float playerSpeed = 2 , jumpForce;
    int gD = 1, coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            coinCount++;
            Debug.Log("Coins collected :" + coinCount);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerRB.gravityScale = -1;
            gD = -1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerRB.gravityScale = 1;
            gD = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&(isGround == true))
        {
            playerRB.AddForce(new Vector2(0, gD * jumpForce), ForceMode2D.Impulse);
            isGround = false;
        }

    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);
    }
}
