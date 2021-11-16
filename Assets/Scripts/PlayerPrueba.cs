using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrueba : MonoBehaviour
{

    public float Health = 100f;
    Rigidbody rig;
    public float speed = 1;
    public float jumpForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rig.velocity = transform.forward * vertical * speed + transform.right * horizontal * speed + new Vector3(0, rig.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y + jumpForce, rig.velocity.z);

        }
    }
    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
    void Shoot()
    {
        
    }

}
