using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ThirdPersonMovement : MonoBehaviour
{
    public bool isGrounded;

    public CharacterController controller;
    public Transform cam;

    public float speed;
    public float walkspeed = 6;
    public float runSpeed = 10;
    public float crouchSpeed = 3;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    public float jumpDelay = 0.2f;
    public float attackRadius = 5.0f;
    private bool canJump;

    Vector3 velocity;

    public GameObject headAim;
    public GameObject navMeshPos;
    public BoxCollider navMeshPosBC;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    public Animator Anim;
    public bool isJumping;
    public bool isMainPlayer; 
    int layerMask;

    public float maxAttackTimer;
    public float attackTimer;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        speed = walkspeed;
        StartCoroutine(JumpDelayFunc(jumpDelay));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = crouchSpeed;
        }
        else
        {
            speed = walkspeed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }


        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = gravity;
        }

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            StartCoroutine(JumpDelayFunc(jumpDelay));
            StartCoroutine(FallDelayFunc(0.5f, "isFalling"));
            canJump = false;
            isJumping = true;
        }

        if (isGrounded && canJump)
        {
            isJumping = false;
            Anim.SetBool("isFalling", false);
        }

        //Attack Timer
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (Anim != null)
        {
            Debug.Log(controller.velocity.magnitude);
            Anim.SetBool("isJumping", isJumping);
        }
    }


    IEnumerator JumpDelayFunc(float jumpingDelay)
    {
        yield return new WaitForSeconds(jumpingDelay);
        canJump = true;
    }

    IEnumerator FallDelayFunc(float jumpingDelay, string condition)
    {
        yield return new WaitForSeconds(jumpingDelay);
        if (isJumping && condition == "isFalling")
        {
            Anim.SetBool(condition, true);
        }
        if (condition == "isAttacking")
        {
            Anim.SetBool(condition, false);
        }
    }

    public void Attack()
    {
        if (attackTimer > 0)
        {
            Anim.SetTrigger("secondAttack");
            attackTimer = 0;
        }
        else
        {
            Anim.SetTrigger("firstAttack");
            attackTimer = maxAttackTimer;
        }
        StartCoroutine(FallDelayFunc(1.0f, "isAttacking"));
        Debug.Log("Attack");

        RaycastHit hit;
        Debug.DrawRay(headAim.transform.position, headAim.transform.forward * attackRadius, Color.yellow);
        if (Physics.Raycast(headAim.transform.position, headAim.transform.forward, out hit, attackRadius))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Breakable")
            {
                hit.collider.transform.gameObject.GetComponent<BreakableObject>().DoBreak();
            }
        }
    }
}
