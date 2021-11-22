using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
public class DarlaController : MonoBehaviour
{

    public float Health = 100f;
    Rigidbody rig;
    public float speed = 1;
    public float jumpForce = 1;
    public AudioClip damageSound;
    AudioSource audioSource;

    [Header("Player Setting")]
       
        public bool stopMoverment = false;
        public bool moving { get; set; }
        
        float m_Horizontal, m_Vertical;
        private Vector3 m_MoveVector;
         
    [HideInInspector]
        public Animator m_Animator;
        private Quaternion m_Rotation = Quaternion.identity;
        private Transform camTrans;
        private Vector3 camForward;

        private Vector3 offset;  

    // Start is called before the first frame update
    void Start()
    {   
        
        rig = GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();
        m_Animator = GetComponent<Animator>();     
        camTrans = Camera.main.transform;  
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
          
        }
        
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rig.velocity = transform.forward * vertical * speed + transform.right * horizontal * speed + new Vector3(0, rig.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y + jumpForce, rig.velocity.z);

        }

 
    }
     void FixedUpdate()
    {
           // move vector 
            if (camTrans != null)
            {
                camForward = Vector3.Scale(camTrans.forward, new Vector3(1, 0, 1).normalized);
                m_MoveVector = m_Vertical * camForward + m_Horizontal * camTrans.right;
                m_MoveVector.Normalize();
            }
            //animation    
            bool has_H_Input = !Mathf.Approximately(m_Horizontal, 0);
            bool has_V_Input = !Mathf.Approximately(m_Vertical, 0);

            if (!stopMoverment) moving = has_H_Input || has_V_Input;
            else moving = false;

            float inputSpeed = Mathf.Clamp01( Mathf.Abs(m_Horizontal) + Mathf.Abs(m_Vertical));

            m_Animator.SetBool(Const.Moving, moving);
            m_Animator.SetFloat(Const.Speed, inputSpeed);

            //move and rotate
            if (moving)
            {
                Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_MoveVector, turnSpeed * Time.deltaTime, 0f);
                m_Rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredForward), turnSpeed);
                m_Rigidbody.MoveRotation(m_Rotation);
                m_Rigidbody.MovePosition(m_Rigidbody.position + inputSpeed*m_MoveVector * runSpeed * Time.deltaTime);
            }
    }
    public void Hit()
    { 
        Health=Health -1;
        if (Health == 0) Destroy( GameObject);
        audioSource.clip= damageSound;
        audioSource.play();
    }
    public void HitSpider()
    { 
        Health=Health -3;
        if (Health == 0) Destroy( GameObject);
        audioSource.clip= damageSound;
        audioSource.play();
    }
     public void HitMonster()
    { 
        Health=Health -3;
        if (Health == 0) Destroy( GameObject);
        audioSource.clip= damageSound;
        audioSource.play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.compareTag("Spider"))
        {
            HitSpider();
        }
        else if (collision.gameObject.compareTag("Monster"))
        {
            HitMonster();
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
=======
/*public class DarlaController : MonoBehaviour
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
   void Shoot()
   {
       GameObject newSnowBall = Instantiate( SnowBall, tranform.position + tranform.forward, new Quaternion( 0,0,0,0));
       Rigidbody snowBallRig = newSnowBall.tranform.GetComponent<Rigidbody>();
       snowBallRig.velocity = transform.forward * gunSpeed;

       Destroy(newSnowBall, 5);

   }
}*/
>>>>>>> e9ec5cbcba55a52d2c5da3452822848c0c6d98d5
