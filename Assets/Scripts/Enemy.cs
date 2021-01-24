using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable, IDetective
{
    [SerializeField] int hp = 200;
    [SerializeField] int firePeriod = 3;
    [SerializeField] private GameObject bullet = null;
    private Transform bulletStartPosition = null;

    GameObject tower = null;
    Transform target = null;
    private bool targetFound = false;

    private float fireTimer = 0;


    void Start()
    {
        tower = transform.GetChild(0).gameObject;
        bulletStartPosition = tower.transform.GetChild(0);
    }



    void Update()
    {
        fireTimer += Time.deltaTime;
        if (targetFound)
        {
            tower.transform.LookAt(target);
            if(fireTimer >= firePeriod)
            {
                fireTimer = 0;
                Fire(bullet);
            }
        }
    }

    private void Fire(GameObject bullet)
    {
        GameObject bulletInstance = Instantiate(bullet, bulletStartPosition.position, tower.transform.rotation);
    }

    public void Damage(int value)
    {
        hp -= value;
        if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }
    }

    public int GetHP()
    {
        return hp;
    }

    public void Activate(GameObject other)
    {
        Debug.Log("Enemy detects target: " + gameObject.tag);
        if (other.tag == "Player")
        {
            targetFound = true;
            target = other.transform;
        }
    }
}
