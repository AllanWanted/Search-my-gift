using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RealPatrol))]
public class PatrolMonster : MonoBehaviour
{
    public float coneLength;
    public float coneWidth;

    MonsterController controller;
    RealPatrol patrol;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<MonsterController>();
        patrol = GetComponent<RealPatrol>();
    }

   
    void Update()
    {
        
        GameObject target = CheckCone();
        if (target != null)
        {
            // disable the patrol
            patrol.enabled = false;

            // and chase the player
            float doubleSpeed = controller.speed * 2;
            controller.Move(target.transform.position, doubleSpeed);
        }
        else
        {
            patrol.enabled = true;
        }
    }

  
    public GameObject CheckCone()
    {
        RaycastHit hit;
        float sliceWidth = coneWidth / 10;

        for (int i = -5; i <= 5; ++i)
        {
            Vector3 direction = transform.forward + transform.right * i * sliceWidth;
            if (Physics.Raycast(transform.position, direction, out hit, coneLength))
            {
                if (hit.collider.tag == "Player")
                {
                    return hit.collider.gameObject;
                }
            }
        }
        return null;
    }

    
    private void OnDrawGizmos()
    {
        float sliceWidth = coneWidth / 10;

        for (int i = -5; i <= 5; ++i)
        {
            Vector3 direction = transform.forward + transform.right * i * sliceWidth;
            Vector3 end = (direction.normalized * coneLength) + transform.position;
            Debug.DrawLine(transform.position, end, Color.green);
        }
    }
}
