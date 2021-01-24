using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //variables

    public float moveSpeed = 5f;

    public float jumpForce = 400f;

    // LayerMask to determine what is considered ground for the player
	public LayerMask whatIsGround; //Put the prefab of the ground here

	// Transform just below feet for checking if player is grounded
	public Transform groundCheck; //Insert the layer here

    // store references to components on the gameObject
    Rigidbody2D _rigidbody;
    GameObject _gameobject;
    Transform _transform;

    //player tracking
    bool isGrounded = false;

    // hold player motion in this timestep
	float _vx;
	float _vy;

    void Awake(){

        _transform = GetComponent<Transform> ();

        _rigidbody = GetComponent<Rigidbody2D> ();
		if (_rigidbody==null) // if Rigidbody is missing
			Debug.LogError("Rigidbody2D component missing from this gameobject");
    }

    void Update(){

        // determine horizontal velocity change based on the horizontal input
		_vx = Input.GetAxisRaw ("Horizontal");

        // get the current vertical velocity from the rigidbody component
		_vy = _rigidbody.velocity.y;

        // Change the actual velocity on the rigidbody
		_rigidbody.velocity = new Vector2(_vx * moveSpeed, _vy);

        // Check to see if character is grounded by raycasting from the middle of the player
		// down to the groundCheck position and see if collected with gameobjects on the
		// whatIsGround layer
		isGrounded = Physics2D.Linecast(_transform.position, groundCheck.position, whatIsGround);

        //this will be fly for Goose but jump for now
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            DoJump();
        }
    }

    void DoJump(){

        // reset current vertical motion to 0 prior to jump
		_vy = 0f;
        // add a force in the up direction
		_rigidbody.AddForce(new Vector2(0, jumpForce));

    }
}