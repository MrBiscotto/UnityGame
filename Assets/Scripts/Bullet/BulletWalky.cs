using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWalky : BulletMovement
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _speed = 30f;
    }
}
