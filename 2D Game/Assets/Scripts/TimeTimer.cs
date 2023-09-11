using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTimer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    public int currentTime;
    public bool isTimerOn;

    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
        currentTime = 0;

    }

    public void Begin()
    {
        isTimerOn = true;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (isTimerOn)
        {
            uiText.text = $"Time : {currentTime / 60:00} : {currentTime % 60:00}";
            currentTime++;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        isTimerOn = false;
    }

    public void SetCurrentTime(int newTime)
    {
        currentTime = newTime;
    }

    public int GetCurrentTime()
    {
        return currentTime;
    }
}
