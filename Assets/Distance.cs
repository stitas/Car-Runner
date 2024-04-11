using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    public static int distance;
    public TMP_Text text;

    void Start()
    {
        distance = 0;
        StartCoroutine(DistanceCounter());
    }

    private IEnumerator DistanceCounter()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            text.text = "Distance: " + distance.ToString();
            distance++;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
