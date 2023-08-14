using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabQuests : MonoBehaviour
{
    PersonSwitcher _pS;
    public GameObject player;
    public List<GameObject> Areas;
    public GameObject Marker;
    GameObject markerGO;
    StartQuest _sQ;

    private void Start()
    {
        _sQ = FindObjectOfType<StartQuest>();
        _pS = FindObjectOfType<PersonSwitcher>();
        markerGO = Instantiate(Marker, new Vector3(), Quaternion.identity);
        markerGO.SetActive(false);
    }

    private void Update()
    {
        if (player == null)
        {
            player = _pS._currentCharacter.CharacterObj;
        }
        foreach (var i in _sQ._quests)
        {
            if (i.isActive == true)
            {
                if (i.ID == 1)
                {
                    i.isActive = false;
                    StartCoroutine(FirstQuest());
                }
                if (i.ID == 2)
                {
                    i.isActive = false;
                    StartCoroutine(SecondQuest());
                }
            }
        }
    }

    public IEnumerator FirstQuest()
    {
        //Barrel Collection
        ShowMarker();
        markerGO.transform.position = Areas[0].transform.position;
        yield return new WaitUntil(() => AreaDetectionQuest(Areas[0], 5f) && Input.GetKeyDown(KeyCode.F));
        Debug.LogError("AREA 1 FOUND");
        //Waste Deposited
        markerGO.transform.position = Areas[1].transform.position;
        yield return new WaitUntil(() => AreaDetectionQuest(Areas[1], 5f) && Input.GetKeyDown(KeyCode.F));
        Debug.LogError("AREA 2 FOUND");
        HideMarker();
    }
    
    public IEnumerator SecondQuest()
    {
        ShowMarker();
        markerGO.transform.position = Areas[3].transform.position;
        yield return new WaitUntil(() => AreaDetectionQuest(Areas[3], 5f) && Input.GetKeyDown(KeyCode.F));
        Debug.LogError("AREA 1 FOUND");
        //Waste Deposited
        markerGO.transform.position = Areas[4].transform.position;
        yield return new WaitUntil(() => AreaDetectionQuest(Areas[4], 5f) && Input.GetKeyDown(KeyCode.F));
        Debug.LogError("AREA 2 FOUND");
        HideMarker();
    }

    public bool AreaDetectionQuest(GameObject area, float radius)
    {
        return Vector3.Distance(player.transform.position, area.transform.position) < radius;
    }

    public void ShowMarker()
    {
        if (markerGO != null)
        {
            markerGO.SetActive(true);
        }
    }
    public void HideMarker()
    {
        if (markerGO != null)
        {
            markerGO.SetActive(false);
        }
    }

}
