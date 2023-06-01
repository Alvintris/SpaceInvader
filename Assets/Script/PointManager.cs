using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int points){
        score += points;
        text.text = "Score : " + score;
    }
}
