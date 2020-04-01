using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Brainly : EnemyDistance
{
    System.Random randomDistance = new System.Random();
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _health = 200;
        _distance = 30f;
        _hitPerSec = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move(_distance);
        Orient();
        CheckShoot();
    }
}
