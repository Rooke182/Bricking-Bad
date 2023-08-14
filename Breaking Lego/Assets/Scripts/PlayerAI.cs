using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour
{
    PersonSwitcher _personSwitcher;
    NavMeshAgent NMA;
    public float walkDistance;
    public float runDistance;
    // Start is called before the first frame update
    void Start()
    {
        _personSwitcher = FindObjectOfType<PersonSwitcher>();
        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_personSwitcher._currentCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().navMeshPos != null)
        {
            if (Vector3.Distance(gameObject.transform.position, _personSwitcher._currentCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().navMeshPos.transform.position) > walkDistance)
            {
                NMA.SetDestination(_personSwitcher._currentCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().navMeshPos.transform.position);
            }
            if (Vector3.Distance(gameObject.transform.position, _personSwitcher._currentCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().navMeshPos.transform.position) > runDistance)
            {
                NMA.speed = 10;
            }
        }
    }
}
