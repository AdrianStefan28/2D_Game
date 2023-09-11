using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishTransition : MonoBehaviour
{
    public int finalScore;

    [SerializeField] private Text uiText1;
    [SerializeField] private Text uiText2;
    [SerializeField] private TimeTimer timeTimer;
    [SerializeField] private ScoreScript scoreScript;

  

    // Start is called before the first frame update
    void Start()
    {

        gameObject.SetActive(false);
        uiText1.text = $"Congratulations";
        uiText2.text = $"Your final score is: 0";
    }

    public void FinalGame()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        uiText2.text = $"Your final score is: " + (scoreScript.scoreNum - timeTimer.currentTime / 10);
        finalScore = (scoreScript.scoreNum - timeTimer.currentTime / 10);
        Debug.Log(finalScore);
    }

    public void FinishGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }


}
