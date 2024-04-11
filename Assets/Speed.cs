using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speed : MonoBehaviour
{
    private int speed;
    public TMP_Text text;

    void Start()
    {
        speed = 50;
        StartCoroutine(SpeedCounter());
    }

    private IEnumerator SpeedCounter()
    {
        yield return new WaitForSeconds(5f);
        while(true)
        {
            text.text = "Speed: " + speed.ToString() + " km/h";
            speed++;
            yield return new WaitForSeconds(3f);
        }
    }
}
