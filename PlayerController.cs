using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    #region Variables
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;


    private PlayerStats _StatsPlayer;
    public int goldToGive;

    private Animator _animator;
    private Rigidbody2D _myRigidbody;

    private bool _playerMoving;
    public Vector2 lastMove;

    private static bool _playerExists;

    private bool _attacking;
    public float attackTime;
    private float _attackTimeCounter;

    public string startPoint;

    #endregion  
    // Use this for initialization
    void Start ()
    {
        _StatsPlayer = FindObjectOfType<PlayerStats>();
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();

        // Checking if player exist and adding/deleting player
        if (!_playerExists)
        {
            _playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update ()
	{
	    _playerMoving = false;

	    if (!_attacking)
	    {
	        
            // Moving left and right
	        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
	        {
	            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                _myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, _myRigidbody.velocity.y);
	            _playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
	        }

            // Moving up and down
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
	        {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                _playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            // Stoping our player moving left and right when we dont click any button
	        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
	        {
	            _myRigidbody.velocity = new Vector2(0f, _myRigidbody.velocity.y);
	        }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x,0f);
            }

            // Attacking
	        if (Input.GetKeyDown(KeyCode.F))
	        {
	            _attackTimeCounter = attackTime;
	            _attacking = true;
	            _myRigidbody.velocity = Vector2.zero;
                _animator.SetBool("Attack", true);
	        }

            // Moving in diagonal directions
	        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
	        {
	            currentMoveSpeed = moveSpeed * diagonalMoveModifier;
	        }
        }

	    if (_attackTimeCounter > 0)
	    {
	        _attackTimeCounter -= Time.deltaTime;
	    }

	    if (_attackTimeCounter <= 0)
	    {
	        _attacking = false;
            _animator.SetBool("Attack", false);
	    }

        // Setting right animations
        _animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        _animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        _animator.SetBool("PlayerMoving", _playerMoving);
        _animator.SetFloat("LastMoveX", lastMove.x);
        _animator.SetFloat("LastMoveY", lastMove.y);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Loot")
        {
            Destroy(col.gameObject);
            _StatsPlayer.AddGold(goldToGive);
        }
    }

}
