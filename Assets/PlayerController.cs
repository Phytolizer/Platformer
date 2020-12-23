using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private CharacterController _controller;

    private const float speed = 3;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _controller = GetComponent<CharacterController>();
    }

    private bool Grounded => Physics.Raycast(transform.position, Vector3.down, _controller.height / 2 + 0.01f);

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            _rigidbody.AddForce(speed * Vector3.right);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            _rigidbody.AddForce(speed * Vector3.left);
        }

        if (Grounded)
        {
            var v = _rigidbody.velocity;
            v.y = 0;
            _rigidbody.velocity = v;
        }
        else
        {
            _rigidbody.velocity += 0.1f * Vector3.down;
        }
    }
}