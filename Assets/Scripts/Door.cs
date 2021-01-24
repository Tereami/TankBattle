using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IDetective
{
    private bool isOpen = false;
    private bool startOpening = false;

    private Vector3 openAngle = new Vector3(0, 180, 90);
    public void Activate(GameObject target)
    {
        startOpening = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (startOpening && !isOpen)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, openAngle, 0.03f));
            if (transform.rotation.eulerAngles == openAngle)
            {
                startOpening = false;
                isOpen = true;
            }
        }
    }
}
