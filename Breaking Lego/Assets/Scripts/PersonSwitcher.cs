using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonSwitcher : MonoBehaviour
{
    public List<Character> _characterList;
    public Character _currentCharacter;
    public Character _secondCharacter;
    public Cinemachine.CinemachineFreeLook CM;
    private Animator timeReflectionAnimator;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var i in _characterList)
        {
            i._headAim = i.CharacterObj.GetComponent<ThirdPersonMovement>().headAim;
            i.CharacterObj.GetComponent<ThirdPersonMovement>().isMainPlayer = false;
            if (i == _currentCharacter)
            {
                i.CharacterObj.GetComponent<ThirdPersonMovement>().isMainPlayer = true;
            }
        }
        SwitchCharacter(0);
        _secondCharacter = _characterList[1];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= 2; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                Debug.Log(i.ToString());
                SwitchCharacter(i);
            }
        }
    }
    void SwitchCharacter(int characterIndex)
    {
        _currentCharacter = _characterList[characterIndex];
        if (characterIndex == 0)
        {
            _secondCharacter = _characterList[1];
        }
        if (characterIndex == 1)
        {
            _secondCharacter = _characterList[0];
        }
        CM.Follow = _currentCharacter._headAim.transform;
        CM.LookAt = _currentCharacter._headAim.transform;

        timeReflectionAnimator = _secondCharacter.CharacterObj.GetComponent<Animator>();
        foreach (AnimatorControllerParameter parameter in _secondCharacter.CharacterObj.GetComponent<Animator>().parameters)
        {
            timeReflectionAnimator.SetBool(parameter.name, false);
        }
        _secondCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().enabled = false;
        _currentCharacter.CharacterObj.GetComponent<ThirdPersonMovement>().enabled = true;

        _secondCharacter.CharacterObj.GetComponent<PlayerAI>().enabled = true;
        _currentCharacter.CharacterObj.GetComponent<PlayerAI>().enabled = false;

        _currentCharacter.CharacterObj.GetComponent<NavMeshAgent>().enabled = false;
        _secondCharacter.CharacterObj.GetComponent<NavMeshAgent>().enabled = true;
    }
    
}

[System.Serializable]
public class Character
{
    public GameObject CharacterObj;
    public GameObject _headAim;
    
    public Character(GameObject _CharObj)
    {
        CharacterObj = _CharObj;
    }
}
