using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        text.text = "Score: " + Distance.distance.ToString();
    }
}
