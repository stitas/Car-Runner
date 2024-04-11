using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject player;
    private float startPos;
    
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        startPos = player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z - startPos > 10)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
