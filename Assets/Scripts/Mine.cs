using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int damage = 60;
    private void OnTriggerEnter(Collider other)
    {
        IDestroyable target = other.gameObject.GetComponentInParent<IDestroyable>();

        if (target != null)
        {
            target.Damage(damage);
            Destroy(gameObject, 0);
            Debug.Log("Boom!");
        }

    }
}
