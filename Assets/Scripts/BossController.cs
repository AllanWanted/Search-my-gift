using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform player;
    State actualState;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        actualState = new Idle(gameObject, agent, player, anim);
    }

    // Update is called once per frame
    void Update()
    {
        actualState = actualState.Process();
    }

}
