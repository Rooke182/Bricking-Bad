using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject ghostStud;
    private bool isDispensing;
    public int worth;
    

    
    private void Update()
    {
        if (isDispensing)
        {
            GameObject destroyedVersionGO = Instantiate(destroyedVersion, transform.position, Quaternion.identity);
            destroyedVersionGO.GetComponent<ObjectExplosion>().explode = true;
            GameObject ghostStudGO = Instantiate(ghostStud, transform.position, Quaternion.identity);
            ghostStudGO.GetComponent<GhostStud>().StudInstantiate(worth);
            Destroy(gameObject);
        }
    }
    public void DoBreak()
    {
        isDispensing = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Car")
        {
            DoBreak();
        }
    }

}
