using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float _speed = 0f;
    public float _Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, 3);
    }

    /// <summary>
    /// Destroy bullet if smthing has been hit
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Player" || other.gameObject.tag == "Walky" || other.gameObject.tag == "Wheely")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
} 
