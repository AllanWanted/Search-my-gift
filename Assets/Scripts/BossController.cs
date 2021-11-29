using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public float HealthBoss = 300f;
   

    //aca se crea todo el sistema de navmesh y maquina de estado
    NavMeshAgent agent;
    public Transform player;
    State actualState;
    Animator anim;
    public float speed = 1;
    public AudioClip clownLaugh;
    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {   
        
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        actualState = new Idle(gameObject, agent, player, anim);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        actualState = actualState.Process();
    }
    public void Hit()
    {
        HealthBoss = HealthBoss - 10;
        if (HealthBoss == 0) Destroy(gameObject);
        audioSource.clip = clownLaugh;
        audioSource.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Sword")
        {
            Hit();
        }

    }

}
