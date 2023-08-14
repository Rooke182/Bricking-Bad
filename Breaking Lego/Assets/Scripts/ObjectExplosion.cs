using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExplosion : MonoBehaviour
{
    public bool explode;
    public List<Rigidbody> rb;
    public float explosionPower;
    void Start()
    {
        foreach (var i in gameObject.GetComponentsInChildren<Rigidbody>())
        {
            rb.Add(i);
        }
    }

    void Update()
    {
        if (explode == true)
        {
            explode = false;
            foreach (var i in rb)
            {
                Debug.Log("Exploded");
                float x = Random.Range(0, explosionPower);
                float y = Random.Range(0, explosionPower);
                float z = Random.Range(0, explosionPower);
                i.AddForce(new Vector3(x, y, z));
            }
        }
    }
}
