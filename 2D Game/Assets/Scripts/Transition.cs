using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{

    [SerializeField] private Image uiFill;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;

    public int Duration;

    private int remainingDuration;

    public bool isTimerOn;

    // Start is called before the first frame update
    void Start()
    {

        isTimerOn = false;
        gameObject.SetActive(false);
    }

    public void Begin(int Second)
    {
        isTimerOn = true;
        remainingDuration = Second;
        gameObject.SetActive(true);
        StartCoroutine(UpdateTimer());

    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {

            slider.value = 3-remainingDuration;
            uiFill.color = gradient.Evaluate(slider.normalizedValue);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        isTimerOn = false;
        gameObject.SetActive(false);
    }

  
}
