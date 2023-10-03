using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    public int score = 0;
    public int coinValue;
    public TextMeshPro valueText;
    public SpriteRenderer sr;
    Rigidbody2D rb;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        //ChangeCoinColor(Random.ColorHSV());
        //ChangeCoinValue(Random.Range(1, 9));
         rb = GetComponent<Rigidbody2D>();
    }

    /*public void SpawnCoin()
    {
        rb.velocity = new Vector3(0, Random.Range(-5, -10));
    }*/
   
    public void ChangeCoinColor(Color c)
    {
        sr.color = c;
    }

    public void ChangeCoinValue(int v)
    {
        coinValue = v;
        valueText.text = coinValue.ToString();
    }
    
    public void IncrementScore(int scoreChange)
    {
        score += scoreChange;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, -speed * Time.deltaTime);
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GameManager>().IncrementScore(coinValue);
            
        }
        */

}

