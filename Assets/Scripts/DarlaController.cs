using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarlaController : MonoBehaviour
{

    public float Health = 100f;
    Rigidbody rig;
    public float speed = 1;
    public float jumpForce = 1;
    public AudioClip damageSound;
    AudioSource audioSource;
 
    [Header("Player Setting")]
         public float turnSpeed = 10f;
        public float runSpeed = 3f;  
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
        
           // move vector 
           
            //animation    
            bool has_H_Input = !Mathf.Approximately(horizontal, 0);
            bool has_V_Input = !Mathf.Approximately(vertical, 0);

            if (!stopMoverment) moving = has_H_Input || has_V_Input;
            else moving = false;

            float inputSpeed = Mathf.Clamp01( Mathf.Abs(horizontal) + Mathf.Abs(vertical));

            m_Animator.SetBool(Const.Moving, moving);
            m_Animator.SetFloat(Const.Speed, inputSpeed);
 
    }
     
    public void Hit()
    { 
        Health=Health -1;
        if (Health == 0) Destroy( gameObject);
        audioSource.clip= damageSound;
        audioSource.Play();
    }
    public void HitSpider()
    { 
        Health=Health -3;
        if (Health == 0) Destroy( gameObject);
        audioSource.clip= damageSound;
        audioSource.Play();
    }
     public void HitMonster()
    { 
        Health=Health -3;
        if (Health == 0) Destroy( gameObject);
        audioSource.clip= damageSound;
        audioSource.Play();
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