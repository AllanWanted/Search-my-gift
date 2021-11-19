using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrueba : MonoBehaviour
{
    public float gunSpeed = 1;
    public GameObject SnowBall;
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
    public void HitSpider()
    {
        Health = Health - 3;
        if (Health == 0) Destroy(gameObject);
       
    }
    public void HitMonster()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);

    }
    public void HitArms()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
    void Shoot()
    {   
        GameObject newSnowball = Instantiate(SnowBall, transform.position + transform.forward, new Quaternion(0, 0, 0, 0));
        Rigidbody snowballRig = newSnowball.transform.GetComponent<Rigidbody>();
        snowballRig.velocity = transform.forward * gunSpeed;

        Destroy(newSnowball, 5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spider"))
        {
            HitSpider();
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            HitMonster();
        }
        else if (collision.gameObject.CompareTag("Arms"))
        {
            HitArms();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        IBox box = other.GetComponent<IBox>();
        if (box != null)
        {
            int res = box.OpenBox();
            if (box.getID() == (int)BoxID.HEALT)
            {
                Health += res;
               
            }
            Destroy(other.gameObject);
        }


    }


}
