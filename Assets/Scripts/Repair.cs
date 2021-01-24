using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField] private int repairPoints = 30;

    private void OnTriggerEnter(Collider other)
    {
        IDestroyable target = other.gameObject.GetComponentInParent<IDestroyable>();

        if (target != null)
        {
            target.Damage(-1 * repairPoints);
            Destroy(gameObject, 0);
            Debug.Log("Repair!");
        }

    }
}
