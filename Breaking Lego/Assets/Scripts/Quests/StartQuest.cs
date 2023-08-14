using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartQuest : MonoBehaviour
{
    public List<Quest> _quests;
    public PersonSwitcher _pS;
    public List<GameObject> textGOs;

    private void Start()
    {
        _pS = FindObjectOfType<PersonSwitcher>();
    }

    private void Update()
    {
        foreach (var i in _quests)
        {
            if (i.playerInRange && i.isAvailable)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    i.isActive = true;
                    i.isAvailable = false;
                }
            }
        }
    }
}

[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool isAvailable;
    public bool playerInRange;

    public string title;
    public string descriptionPlayer;
    public string descriptionAdmin;
    public QuestDetection startArea;
    public int ID;
}
