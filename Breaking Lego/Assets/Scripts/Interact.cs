using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public List<GameObject> UIBottomText;
    public float radius;
    public GameObject RecentObject;
    public List<GameObject> enterList;
    PersonSwitcher _personSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        _personSwitcher = FindObjectOfType<PersonSwitcher>();

        foreach (var i in GameObject.FindGameObjectsWithTag("Enter"))
        {
            enterList.Add(i);
        }


        foreach (var i in UIBottomText)
        {
            i.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var i in enterList)
        {
            if (Vector3.Distance(_personSwitcher._currentCharacter.CharacterObj.transform.position, i.transform.position) <= radius)
            {
                RecentObject = i;
                if (RecentObject.GetComponent<EnterVehicle>() != null)
                {
                    foreach (var x in UIBottomText)
                    {
                        x.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        RecentObject.GetComponent<EnterVehicle>().EnterVehicleFunction();
                    }
                }
            }
        }
        if (RecentObject != null)
        {
            if (Vector3.Distance(_personSwitcher._currentCharacter.CharacterObj.transform.position, RecentObject.transform.position) > radius)
            {
                foreach (var i in UIBottomText)
                {
                    i.SetActive(false);
                }
            }
        }
    }
    
}
