using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag != "Player")dddd return;

        IDestroyable target = other.gameObject.GetComponentInParent<IDestroyable>();
        if (target == null)
        {
            target = other.GetComponent<IDestroyable>();
        }



        if (target != null)
        {
            target.Damage(damage);
            Destroy(gameObject, 0);
            Debug.Log("Damage! Target hp:" + target.GetHP().ToString());
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
