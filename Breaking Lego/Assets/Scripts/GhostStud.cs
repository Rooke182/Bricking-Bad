using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStud : MonoBehaviour
{
    bool isDispensing;
    int Worth;
    StudPrefabs _studPrefabs;
    public float flySpeed;
    public float height;

    private void Start()
    {
        _studPrefabs = FindObjectOfType<StudPrefabs>();
    }

    private void Update()
    {
        if (isDispensing)
        {
            if (Worth >= 10000)
            {
                StudSpawn("Purple");
                Worth -= 10000;
            }
            if (Worth >= 1000)
            {
                StudSpawn("Blue");
                Worth -= 1000;
            }
            if (Worth >= 100)
            {
                StudSpawn("Gold");
                Worth -= 100;
            }
            if (Worth >= 10)
            {
                StudSpawn("Silver");
                Worth -= 10;
            }
            if (Worth < 10)
            {
                Destroy(gameObject);
            }
        }
    }
    void StudSpawn(string Rarity)
    {
        if (Rarity == "Purple")
        {
            Instantiate(_studPrefabs.PurpleStud, gameObject.transform.position, Quaternion.identity);
        }
        if (Rarity == "Blue")
        {
            Instantiate(_studPrefabs.BlueStud, gameObject.transform.position, Quaternion.identity);
        }
        if (Rarity == "Gold")
        {
            Instantiate(_studPrefabs.GoldStud, gameObject.transform.position, Quaternion.identity);
        }
        if (Rarity == "Silver")
        {
            Instantiate(_studPrefabs.SilverStud, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void StudInstantiate(int worth)
    {
        Worth = worth;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position + new Vector3(0, height, 0), flySpeed * Time.deltaTime);
        StartCoroutine(StudBreakWait());
    }
    
    IEnumerator StudBreakWait()
    {
        yield return new WaitForSeconds(flySpeed);
        isDispensing = true;
    }
}
