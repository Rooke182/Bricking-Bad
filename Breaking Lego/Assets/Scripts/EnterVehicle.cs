using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class EnterVehicle : MonoBehaviour
{
    public GameObject _firstSeat;
    public GameObject _secondSeat;
    public GameObject CamLock;
    PersonSwitcher _pS;
    private CinemachineFreeLook CM;

    void Start()
    {
        _pS = FindObjectOfType<PersonSwitcher>();
        CM = FindObjectOfType<CinemachineFreeLook>();
    }
    public void EnterVehicleFunction()
    {
        _pS._currentCharacter.CharacterObj.transform.position = _firstSeat.transform.position;
        _pS._secondCharacter.CharacterObj.transform.position = _secondSeat.transform.position;

        _pS._currentCharacter.CharacterObj.GetComponent<CharacterController>().enabled = false;
        _pS._secondCharacter.CharacterObj.GetComponent<CharacterController>().enabled = false;
        
        _pS._currentCharacter.CharacterObj.GetComponent<PlayerAI>().enabled = false;
        _pS._secondCharacter.CharacterObj.GetComponent<PlayerAI>().enabled = false;
        
        _pS._currentCharacter.CharacterObj.GetComponent<NavMeshAgent>().enabled = false;
        _pS._secondCharacter.CharacterObj.GetComponent<NavMeshAgent>().enabled = false;

        _pS._currentCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().enabled = false;
        _pS._secondCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().enabled = false;
        
        _pS._currentCharacter.CharacterObj.GetComponent<CapsuleCollider>().enabled = false;
        _pS._secondCharacter.CharacterObj.GetComponent<CapsuleCollider>().enabled = false;

        _pS._currentCharacter.CharacterObj.GetComponent<Stud>().radius = 15f;
        _pS._secondCharacter.CharacterObj.GetComponent<Stud>().radius = 15f;

        _pS._currentCharacter.CharacterObj.gameObject.transform.parent = gameObject.transform.parent;
        _pS._secondCharacter.CharacterObj.gameObject.transform.parent = gameObject.transform.parent;

        CM.Follow = CamLock.transform;
        CM.LookAt = CamLock.transform;

        CM.m_Orbits[0].m_Height = 22;
        CM.m_Orbits[0].m_Radius = 40;

        CM.m_Orbits[1].m_Height = 5;
        CM.m_Orbits[1].m_Radius = 30;
        
        CM.m_Orbits[1].m_Height = 0;
        CM.m_Orbits[1].m_Radius = 20;

        CM.GetComponent<Cinemachine.CinemachineCollider>().m_IgnoreTag = "Car";

        gameObject.transform.parent.GetComponent<CarMovement>().enabled = true;
    }
}
