using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadInput : MonoBehaviour
{

    private string input;
    public FinishTransition finishTransition;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s)
    {
        input = s;

        PlayerPrefs.SetInt("AddPerson", 1);
        PlayerPrefs.Save();

        PlayerPrefs.SetString("PersonName", input);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("PersonScore", finishTransition.finalScore);
        PlayerPrefs.Save();

        Debug.Log(input);
    }
}
