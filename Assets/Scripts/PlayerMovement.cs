using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rbody;
    private Animator anim;
    private int run = 1;

    private Vector2 downVector = new Vector2(0, -1);
    private Vector2 upVector = new Vector2(0, 1);
    private Vector2 rightVector = new Vector2(1, 0);
    private Vector2 leftVector = new Vector2(-1, 0);

    public bool canMove;
    public PlayerDir currentDirection;

    public enum PlayerDir {
        down,
        up,
        left,
        right
    };

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   
	}
	
	// Update is called once per frame
	void Update () {
        if (!canMove)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            run = 2;
        }
        else
        {
            run = 1;
        }

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);

            if (movement_vector == upVector)
                currentDirection = PlayerDir.up;
            else if (movement_vector == downVector)
                currentDirection = PlayerDir.down;
            else if (movement_vector == rightVector)
                currentDirection = PlayerDir.right;
            else if (movement_vector == leftVector)
                currentDirection = PlayerDir.left;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * run);
	}
}
