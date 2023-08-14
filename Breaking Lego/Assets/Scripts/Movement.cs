using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;

    public float jumpHeight = 3f;
    public bool isGrounded;

    public Animator Anim;

    public bool canMove;
    Vector3 velocity;
    public bool isDown;

    public bool canJump;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = true;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded == true)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        if (canMove)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        if (velocity.y >= -100)
        {
            velocity.y += gravity * gravityMultiplier * Time.deltaTime;
        }
        else
        {
            velocity.y = -100;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && canJump == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * gravityMultiplier);
        }

        controller.Move(velocity.normalized * Time.deltaTime);

        if (Anim != null)
        {
            Anim.SetBool("isWalking", Input.GetKey(KeyCode.W));
        }
    }

}
