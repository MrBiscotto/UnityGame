using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : BulletMovement
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _speed = 20f;   
    }
}
