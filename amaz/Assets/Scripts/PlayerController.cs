using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float moveSpeed = 5f;
    public float jumpforce = 10f;

    public float groundDistanceThreshold = 0.55f;

    public LayerMask whatIsGround;

    private bool _isGrounded;
    private bool _enabled;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enabled) return;
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down,
            groundDistanceThreshold, whatIsGround); 

        if(_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = Vector2.up * jumpforce;
        }
        else
        {
            _animator.SetBool("Jumping", false);
        }

        _animator.SetBool("Falling", !_isGrounded);
    }
    void FixedUpdate()
    {
        if (!_enabled) return;       
        float movement = moveSpeed * Input.GetAxisRaw("Horizontal");

        _animator.SetBool("Moving", movement != 0);

        if (movement > 0)
        {
            transform.localScale = Vector3.one;                                                                                                                                                                                                                          
        }
        else if (movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        _rigidbody.position += movement * Time.deltaTime * Vector2.right;
    }

    public void Enable()
    {
        _enabled = true;
    }

    public void Disable()
    {
        _enabled = false;

        _animator.SetBool("Moving", false);
        _animator.SetBool("Jumping", false);
        _animator.SetBool("Falling", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            gameManager.KillPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            other.GetComponent<Animator>().SetBool("Active", true);
            gameManager.SetCheckpoint(other.transform);
        }
        else if (other.CompareTag("Collectible"))
        {
            gameManager.GotCollectible(other.transform);
            other.gameObject.SetActive(false);
            Debug.Log("Collected");
        }
        else if (other.CompareTag("Goal"))
        {
            gameManager.ReachedGoal();
        }
    }
}
