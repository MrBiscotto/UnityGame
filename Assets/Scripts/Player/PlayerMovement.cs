using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;

    Vector3 _movement;
    Rigidbody _playerRigidbody;
    GameObject _camera;

    private Vector3 lookPos;
    private Ray m_Ray;

    /// <summary>
    /// Initialize
    /// </summary>
    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    /// <summary>
    /// Launche Move and orient 
    /// </summary>
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Orient();
    }

    /// <summary>
    /// Move Character
    /// </summary>
    /// <param name="h"></param>
    /// <param name="v"></param>
    void Move(float h, float v)
    {
        _movement.Set(h, 0, v);
        _movement = _movement.normalized * speed * Time.deltaTime;

        _playerRigidbody.MovePosition(transform.position + _movement);
    }


    /// <summary>
    /// Orient player in terms of cursor
    /// </summary>
    void Orient()
    {
        m_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(m_Ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }
}
