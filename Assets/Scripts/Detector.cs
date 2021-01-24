using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] GameObject host = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        host.GetComponent<IDetective>().Activate(other.gameObject);
    }
}
