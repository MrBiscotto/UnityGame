using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheely : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _health = 100;
        _speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Move(_distance);
        Orient();
    }
}
