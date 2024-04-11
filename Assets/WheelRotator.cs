using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public Movement playerMovement;
    private float speed;

    // Update is called once per frame
    void Update()
    {
        speed = playerMovement.speed;

        foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if(gameObj.name.Contains("Wheel"))
            {
               gameObj.transform.Rotate( Time.deltaTime * speed * 50, 0, 0 );
            }
        }
    }
}
