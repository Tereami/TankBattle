using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour, IDestroyable
{
    [SerializeField] private int hp = 10;
    [SerializeField] private List<Transform> route = null;
    private int targetPointNumber = 0;

    private NavMeshAgent agent = null;

    public void Damage(int value)
    {
        hp -= value;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHP()
    {
        return hp;
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(route[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < agent.stoppingDistance)
        {
            targetPointNumber = (targetPointNumber + 1) % route.Count;
            agent.SetDestination(route[targetPointNumber].position);
        }
    }


}
