using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Spawn Variables")]
    public List<Enemy> _spawnEnemy;
    public int _spawnTime = 5;

    //Nb enemy kill && nb Walky kill && nb Whelly kill
    protected ScorePlayer scoreP = new ScorePlayer();

    //Random spawn with Whelly & Walky
    private int valWalky;
    private int valWhelly;
    private int result;


    private void Start()
    {
        StartCoroutine(SpawnMobs());
    }

    /// <summary>
    /// Coroutine spawn mobs
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnMobs()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);

            if (scoreP.NbWalkyKill >= 5 && scoreP.NbWhellyKill >= 5)
            {
                scoreP.NbWhellyKill = 0;
                scoreP.NbWalkyKill = 3;
                SpawnBrainly(Random.Range(1, 4));
            }
            else if (scoreP.NbWalkyKill >= 3)
            {
                RandomSpawn();
            }
            else
            {
                SpawnWalky();
            }
        }
    }

    /// <summary>
    /// Spawn random for each spawn (Walky or Wheely)
    /// </summary>
    protected void RandomSpawn()
    {
        valWalky = Random.Range(0, 5);
        valWhelly = Random.Range(0, 5);

        result = Math.Abs(valWalky - valWhelly);

        switch (result)
        {
            case 0:
                SpawnWalky();
                break;
            case 1:
                SpawnWalky();
                break;
            case 2:
                SpawnWalky();
                break;
            case 3:
                SpawnWhelly();
                break;
            case 4:
                SpawnWhelly();
                break;
            case 5:
                SpawnWhelly();
                break;
        }
    }

    /// <summary>
    /// Walky spawn every 15 secondes 
    /// </summary>
    protected void SpawnWalky()
    {
        if (scoreP.NbEnemy <= 10)
        {
            Instantiate(_spawnEnemy[0], new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            scoreP.NbEnemy += 1;
        }
    }

    /// <summary>
    /// Wheely spawn every 15 secondes 
    /// </summary>
    protected void SpawnWhelly()
    {
        if (scoreP.NbEnemy <= 10)
        {
            Instantiate(_spawnEnemy[1], new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            scoreP.NbEnemy += 1;
        }
    }

    /// <summary>
    /// Brainly Spawn when 10 kills Walky & Wheely
    /// </summary>
    protected void SpawnBrainly(int rdn)
    {
        string spawnTag = "Spawn" + rdn;
        GameObject spawn = GameObject.FindGameObjectWithTag(spawnTag);

        Instantiate(_spawnEnemy[2], new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z), Quaternion.identity);

        scoreP.NbEnemy += 1;
    }


}
