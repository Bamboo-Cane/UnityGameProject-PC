using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMove : MonoBehaviour
{
    public float angle;
    public float force;
    private GameObject FixRotation;
    private Rigidbody skillRB;
    private GameObject enemy;
    public ParticleSystem bigBoom;
    public ParticleSystem smallBoom;
    // Start is called before the first frame update
    void Start()
    {
        FixRotation = GameObject.Find("Fix");
        skillRB = GetComponent<Rigidbody>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        float xcomponent = Mathf.Cos(FixRotation.transform.eulerAngles.y * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(FixRotation.transform.eulerAngles.y * Mathf.PI / 180) * force;
        skillRB.AddForce(new Vector3(ycomponent , 0, xcomponent ) * Time.deltaTime);
        Invoke("DestroyObject", 4f);
    }
    

    void DestroyObject()
    {
        Destroy(skillRB.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other.gameObject != null)
            {
                if(enemy.gameObject != null)
                Instantiate(enemy.GetComponent<Enemy>().blood.gameObject, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                if(gameObject!=null)
                Destroy(gameObject);
            }
            
        }


    }
}
