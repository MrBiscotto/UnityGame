using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrainly : BulletMovement
{
    // Start is called before the first frame update
    private GameObject _player;

    protected override void Start()
    {
        base.Start();
        _player = GameObject.FindGameObjectWithTag("Player"); 
        Vector3 toTarget = _player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toTarget, Vector3.up);
        _speed = 40f;
    }
}
