using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    // Start is called before the first frame update
    public float groundDistanceThreshold = 0.55f;

    public LayerMask whatIsGround;

    private bool _isGrounded;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down,
            groundDistanceThreshold, whatIsGround);
        
        if(_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = Vector2.up * jumpForce;
           
        }
    }

    private void FixedUpdate()
    {
        float movement = moveSpeed * Input.GetAxisRaw("Horizontal");

        _rigidbody.position += movement * Time.deltaTime * Vector2.right;
    }
}
