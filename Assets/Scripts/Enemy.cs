using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int pushForce;
    private GameObject player;
    Rigidbody rb;
    public float speed;
    public float additionalSpeed;
    public float explosionForce;
    private Movement trigger;
    public ParticleSystem blood;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        trigger = GameObject.Find("Player").GetComponent<Movement>();

        if (trigger.winLevel1)
        {
            rb.AddForce(new Vector3(0, explosionForce, 0), ForceMode.Impulse);
            speed = speed + additionalSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            rb.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.transform.position - transform.position) * pushForce);
        }   
    }

}
