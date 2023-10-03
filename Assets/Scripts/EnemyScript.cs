using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public SpriteRenderer sr;
    Rigidbody2D rb;
    GameManager gameManager;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GM_Object").GetComponent<GameManager>();
         rb = GetComponent<Rigidbody2D>();
        
    }
    
    /*public void SpawnEnemy()
    {
        //rb.velocity = new Vector3(0, Random.Range(-5, -10));
        //rb.velocity = new Vector3(0, -speed * Time.deltaTime);
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, -speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            gameManager.GameOver();
            Debug.Log("Game Over");
            Destroy(collision.gameObject);
            

        }
    }
}
