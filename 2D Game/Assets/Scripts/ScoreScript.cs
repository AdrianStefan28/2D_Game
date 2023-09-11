using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text myScoreText;
    public int scoreNum;

    // Start is called before the first frame update
    void Start()
    {
        //scoreNum = 0;
        myScoreText.text = "Score : " + scoreNum;

    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.tag == "MyCoins")
        {
            scoreNum += 1;
            Destroy(coin.gameObject);
            myScoreText.text = "Score : " + scoreNum;
        }
    }

    public void SetScore(int newScore)
    {
        scoreNum = newScore;   
    }

    public int GetScore()
    {
        return scoreNum;
    }
   
   
}
