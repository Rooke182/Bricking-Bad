using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockMouse : MonoBehaviour
{
    public bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isLocked)
            {
                isLocked = !isLocked;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                isLocked = !isLocked;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
