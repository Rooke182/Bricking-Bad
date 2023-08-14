using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudSpawner : MonoBehaviour
{
    StudPrefabs _studPrefabs;
    public GameObject spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        _studPrefabs = FindObjectOfType<StudPrefabs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int randomStud = Random.Range(0, _studPrefabs.AllStuds.Count);
            Instantiate(_studPrefabs.AllStuds[randomStud], spawnLocation.transform.position, Quaternion.identity);
        }
    }
}
