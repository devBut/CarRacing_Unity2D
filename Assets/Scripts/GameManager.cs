using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    public float minSpawnTime;
    public float maxSpawnTime;
    public GameObject[] obstaclePbs;
    public GameObject player;
    public BGLoop bgLoop;
    public bool isGameover;
    public bool isGameplaying;
    private int m_score;

    public int Score
    {
        get
        {
            return m_score;
        }

        set
        {
            m_score = value;
        }
    }

    public override void Awake()
    {
        MakeSingleton(false);
    }


    public override void Start()
    {
        base.Start();

        StartCoroutine(SpawnObstacle());
    }


    IEnumerator SpawnObstacle()
    {
        while (!isGameover)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTime);

            if(obstaclePbs != null && obstaclePbs.Length > 0)
            {
                int obIdx = Random.Range(0, obstaclePbs.Length);

                GameObject obstacle = obstaclePbs[obIdx];

                if (obstacle)
                {
                    Vector3 spawnPos = new Vector3 (Random.Range(-1.4f, 1.4f), 8f, 0f);
                    Instantiate(obstacle, spawnPos, Quaternion.identity);
                }
            }
        }
    }
}
