using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stud : MonoBehaviour
{
    public float radius;
    public float collectionRadius;
    public float collectionSpeed;
    public GameObject studCollecter;
    private Score SC;
    // Start is called before the first frame update
    void Start()
    {
        SC = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(studCollecter.transform.position, radius);
        Collider[] collectColliders = Physics.OverlapSphere(studCollecter.transform.position, collectionRadius);
        foreach (var i in hitColliders)
        {
            if (i.transform.tag == "Stud")
            {
                i.gameObject.GetComponent<Rigidbody>().useGravity = false;
                i.transform.position = Vector3.Slerp(i.transform.position, studCollecter.transform.position, collectionSpeed * Time.deltaTime);
                foreach (var x in collectColliders)
                {
                    if (x == i)
                    {
                        SC._score += x.gameObject.GetComponent<ItemWorth>().Worth;
                        Destroy(x.gameObject);
                    }
                }
            }
        }
    }
}
