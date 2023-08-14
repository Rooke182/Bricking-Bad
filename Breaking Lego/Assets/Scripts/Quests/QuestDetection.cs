using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDetection : MonoBehaviour
{
    StartQuest _startQuest;
    public List<Quest> quests;

    private void Start()
    {
        _startQuest = FindObjectOfType<StartQuest>();
    }

    private void Update()
    {
        if (quests.Count > 0)
        {
            quests.Clear();
        }
        foreach (var i in _startQuest._quests)
        {
            if (i.playerInRange && i.isAvailable)
            {
                quests.Add(i);
            }
        }

        if (quests.Count > 0)
            foreach (var i in _startQuest.textGOs)
            {
                i.SetActive(true);
            }
        else
            foreach (var i in _startQuest.textGOs)
            {
                i.SetActive(false);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var i in _startQuest._quests)
            {
                if (i.startArea == this)
                {
                    i.playerInRange = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var i in _startQuest._quests)
            {
                if (i.startArea == this)
                {
                    i.playerInRange = false;
                }
            }
        }
    }
}
