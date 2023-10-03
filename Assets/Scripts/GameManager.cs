using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public GameObject swapPrefab;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;
    private float widthvalue = 8;
    //public Color[] coinColors;
    public TextMeshPro playerScoreText;
    public int score = 0;
    public int coinValue;
    // Start is called before the first frame update
    void Start()
    {
       
        //SpawnCoin();
        Invoke("SpawnCoin", 1);
        Invoke("SpawnEnemy", 1.5f);
        Invoke("SpawnSwap", 3);
        //InvokeRepeating("SpawnEnemy", Random.Range(1.5f, 3f),0);
        //InvokeRepeating("SpawnCoin", Random.Range(1.5f, 3f),0);
        //InvokeRepeating("SpawnSwap", Random.Range(1.5f, 3f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
    } 

    public void GameOver()
    {
        CancelInvoke("SpawnCoin");
        CancelInvoke("SpawnEnemy");
        CancelInvoke("SpawnSwap");

    }
    /*public void IncrementScore(int scoreChange)
    {
        score += scoreChange;
    } */

    public void SpawnCoin()
    {
        float randomXValue = Random.Range(-widthvalue, widthvalue); 
        Vector3 pos = new Vector3(randomXValue, 5, 0);
        GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);

        CoinScript coinScript = coin.GetComponent<CoinScript>();
        coinScript.speed = Random.Range(50, 200);

        //int rndValue = Random.Range(0, 3);
        //coinScript.ChangeCoinValue(rndValue);
        //coinScript.ChangeCoinColor(coinColors[rndValue]);
        Invoke("SpawnCoin", Random.Range(1.5f, 3f));
    }

    public void SpawnEnemy()
    {
        float randomXValue = Random.Range(-widthvalue, widthvalue); 
        Vector3 pos = new Vector3(randomXValue, 5, 0);
        GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);

        EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
        enemyScript.speed = Random.Range(50, 200);

        Invoke("SpawnEnemy", Random.Range(1.5f, 3f));
    }

    public void SpawnSwap()
    {
        float randomXValue = Random.Range(-widthvalue, widthvalue); 
        Vector3 pos = new Vector3(randomXValue, 5, 0);
        GameObject spawn = Instantiate(swapPrefab, pos, Quaternion.identity);

        SwapScript swapScript = spawn.GetComponent<SwapScript>();
        swapScript.speed = Random.Range(50, 200);

        Invoke("SpawnSwap", Random.Range(2.5f, 4.0f));
    }
}
