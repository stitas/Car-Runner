using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        text.text = "Highscore: " + PlayerPrefs.GetInt("Highscore",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Distance.distance > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore",Distance.distance);
            text.text = "Highscore: " + Distance.distance.ToString();
        }
    }
}
