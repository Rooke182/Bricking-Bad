using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animations : MonoBehaviour
{
    public Animator Anim;
    public ThirdPersonMovement _thirdPersonMovement;
    public NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        _thirdPersonMovement = GetComponent<ThirdPersonMovement>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim == null)
        {
            return;
        }
        if (_thirdPersonMovement.enabled == true)
        {
            Anim.SetBool("isWalking", _thirdPersonMovement.controller.velocity.magnitude > 0.3f);
            Anim.SetBool("isRunning", _thirdPersonMovement.controller.velocity.magnitude > 7.0f);
        }
        if (_thirdPersonMovement.enabled == false)
        {
            if (_navMeshAgent != null && _navMeshAgent.enabled == true)
            {
                Anim.SetBool("isWalking", _navMeshAgent.velocity.magnitude > 0.3f);
                Anim.SetBool("isRunning", _navMeshAgent.velocity.magnitude > 7.0f);
            }
        }
    }
}
