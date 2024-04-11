using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text text;
    private float time = 3f;

    void Start()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        while (time > 0)
        {
            text.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
            
        }
        text.text = "GO!";
        yield return new WaitForSeconds(1.0f);
        text.gameObject.SetActive(false);
    }
}
