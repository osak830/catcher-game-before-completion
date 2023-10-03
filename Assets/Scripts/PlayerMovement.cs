using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip coinSound;
    public float MovementSpeed = 5;
    Rigidbody2D rb;
    float xMove;
    int playerScore;
    public int coinValue;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xMove, 0) * (Time.deltaTime * MovementSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.GetComponent<CoinScript>().IncrementScore(coinValue);

            Destroy(collision.gameObject);

            audioSource.PlayOneShot(coinSound);

            gameManager.AddScore();
        }
        /*if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);

        }*/
        if (collision.gameObject.tag == "Swap")
        {

            Debug.Log("Swap Scene");
            Destroy(collision.gameObject);

        }
    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy(collision.gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Swap")
        {

            Debug.Log(gameObject.name);

        }

    */
    }
    

