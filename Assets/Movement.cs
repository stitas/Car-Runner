using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Movement : MonoBehaviour
{
    
    public float speed;
    public GameObject player;
    public RoadManager roadManager;
    public float waitBeforeAddingRoad;
    private Rigidbody rb;
    public Vector3 movement;
    public bool isGoingLeft, isGoingRight;
    private Vector3 moveForward = new Vector3(0,0,2);
    private Vector3 move = new Vector3(1,0,0);
    public AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }
    

    void Update()
    {
        isGoingLeft = Input.GetKey("a");
        isGoingRight = Input.GetKey("d");
        speed += (float) Math.Pow(10,-4);
    }

    void FixedUpdate()
    {
        MovePlayer(moveForward);

        if (isGoingLeft && rb.position.x > -1 && !isGoingRight)
        {
            rb.position = rb.position - move * Time.fixedDeltaTime * speed * 0.8f;
        }
        else if (isGoingRight && rb.position.x < 1 && !isGoingLeft)
        {
            rb.position = rb.position + move * Time.fixedDeltaTime * speed * 0.8f;
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider col) 
    {
        Invoke("SpawnNewRoad",waitBeforeAddingRoad);
    }

    private void SpawnNewRoad()
    {
        roadManager.MoveRoad();
    }

    private void OnCollisionEnter(Collision col)
    {
        speed = 0;
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
