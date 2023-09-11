using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int health;
    public int score;
    public int time;
    public float[] position;

    public PlayerData (PlayerController player)
    {
        health = player.GetHealth();
        score = player.scoreScript.GetScore();
        time = player.timeTimer.GetCurrentTime();

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
