using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject _bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }

    /// <summary>
    /// Create bullet from spawnPoint
    /// </summary>
    void fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletSpawn = Instantiate(_bullet); ;
            bulletSpawn.transform.position = transform.position;
            bulletSpawn.transform.rotation = transform.rotation;
        }
    }
}
