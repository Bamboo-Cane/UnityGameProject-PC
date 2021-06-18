using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] crystal;
    public GameObject[] enemy;
    public float spawnCrystalSpeed;
    public float spawnEnemySpeed;
    private Vector3 setRotation = new Vector3(-90,0,0);
    public float randomRangeStartX;
    public float randomRangeEndX;
    public float randomRangeStartZ;
    public float randomRangeEndZ;
    private Movement player;
    // Start is called before the first frame update
    public void StartSpawn()
    {

        player = GameObject.Find("Player").GetComponent<Movement>();

        if (true)
        {
            InvokeRepeating("spawnCrystal", spawnCrystalSpeed, spawnCrystalSpeed);
            InvokeRepeating("spawnEnemy", spawnEnemySpeed, spawnEnemySpeed);
        }
    }

    // Update is called once per frame

    int RandomCrystal()
    {
        int number = Random.Range(0, crystal.Length);
        return number;
    }

    int RandomEnemy()
    {
        int number = Random.Range(0, enemy.Length);
        return number;
    }

    void spawnCrystal()
    {
        Instantiate(crystal[RandomCrystal()].gameObject, spawnRandom(), transform.rotation);
    }

    void spawnEnemy()
    {
        Instantiate(enemy[RandomEnemy()].gameObject, spawnRandom(), transform.rotation);
    }

    Vector3 spawnRandom()
    {
        return new Vector3 (Random.Range(randomRangeStartX,randomRangeEndX),-4f,Random.Range(randomRangeStartZ,randomRangeEndZ));
    }
}
