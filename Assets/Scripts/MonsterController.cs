using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MonsterController : MonoBehaviour
{
    public float speed;

    Rigidbody rb;
    public AudioClip damageSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Move(Vector3 target, float speed = 0)
    {
        // If the AI controller didn't provide speed, use the default
        if (speed == 0) speed = this.speed;

        transform.LookAt(target);
        rb.velocity = transform.forward * speed + Vector3.down * rb.velocity.y;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Sword")
        {
            audioSource.clip = damageSound;
            audioSource.Play();
            Destroy(gameObject, 2);
        }
    }


}
