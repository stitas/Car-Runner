using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    
    public List<Rigidbody> prefabs;
    public List<Rigidbody> enemies;
    public GameObject player;
    private float gapOffset = 7f;
    private int prefab;
    private Vector3 scale = new Vector3(0.07f,0.07f,0.07f);
    private Rigidbody rb;
    private Vector3 moveForward = new Vector3(0,0,2);
    public float speed;
    public Movement playerMovement;
    private bool enemySpawned = false;
    
    
    void Update()
    {
        speed = playerMovement.speed / 4;

        DestroyEnemy();             
        SpawnEnemy();
        
    }

    void FixedUpdate()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            enemies[i].transform.position += moveForward * Time.fixedDeltaTime * speed;
        }   
    }

    private void SpawnEnemy()
    {
        if (enemies.Count < 20)
        {
            enemySpawned = false;
            while(!enemySpawned)
            {
                prefab = Random.Range(0,prefabs.Count);
                Rigidbody enemy = (Rigidbody) Instantiate(prefabs[prefab].GetComponent<Rigidbody>(), GetPosition(), player.transform.rotation);
                enemy.transform.localScale = scale;
                enemy.gameObject.tag = "enemy";
                Vector3 enemyCenter = enemy.gameObject.GetComponent<BoxCollider>().transform.position;
                Vector3 enemyHalfExtents = enemy.gameObject.GetComponent<BoxCollider>().bounds.extents;
                Quaternion enemyOrientation = player.transform.rotation;
                LayerMask enemyMask = LayerMask.GetMask("enemy");
                if (Physics.CheckBox(enemyCenter,enemyHalfExtents,enemyOrientation,enemyMask))
                {
                    continue;
                }
                else
                {
                    enemySpawned = true;
                }
               
                enemies.Add(enemy);
            }
        }
    }

    private void DestroyEnemy()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].position.z < player.transform.position.z - 10)
            {
                if (enemies[i].transform.gameObject.name.Contains("(Clone)"))
                {
                    Destroy(enemies[i].transform.gameObject);
                }
                enemies.RemoveAt(i);
            }
        }
    }

    private Vector3 GetPosition()
    {
        int x = Random.Range(-1,2);
        float z = player.transform.position.z + Random.Range(4,7);
        float y = 0.1f;

        Vector3 position = new Vector3(x,y,z);

        foreach (Rigidbody enemy in enemies)
        {
            if (position.z - enemy.position.z >= gapOffset)
            {
                continue;
            }
            else
            {
                position.z += gapOffset;
            }
        }

        return position;
    }

    
}
