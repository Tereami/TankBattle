using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int mainAmmoCount = 5;
    [SerializeField] private int altAmmoCount = 3;


    private void OnTriggerEnter(Collider other)
    {
        IFightable fighter = other.gameObject.GetComponentInParent<IFightable>();

        if (fighter != null)
        {
            fighter.AddAmmo(mainAmmoCount, altAmmoCount);
            Destroy(gameObject, 0);
            Debug.Log("Add ammo!");
        }
    }
}
