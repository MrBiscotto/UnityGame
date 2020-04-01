using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Walky : EnemyDistance
{
    protected override void Start()
    {
        base.Start();
        _health = 50;
        _distance = (float)Random.Range(15, 20);
        _hitPerSec = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Move(_distance);
        Orient();
        CheckShoot();
    }

 
}
