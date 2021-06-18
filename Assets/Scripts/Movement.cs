using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Movement : MonoBehaviour
{
    GameObject yes;
    public float speed;
    public Joystick joyStick;
    Rigidbody rb;
    public float leftOrRight = 0f;
    public float upOrDown = 0f;
    public GameObject skill;
    public int crystalCount;
    public int crystalRequired;
    public Button attack;
    public Text currentCrystalText;
    public Text crystalRequiredText;
    public GameObject trigger;
    public BoxCollider stone;
    public bool winLevel1 = false;
    public bool winBoss = false;
    public GameObject spawnManager;
    public GameObject boss;
    public GameObject bossTrigger;
    public VideoPlayer movie;
    public GameObject screen;
    public GameObject winOrNot;
    public GameObject disco;
    public GameObject lighting;
    public GameObject lighting2;
    public AudioSource bossMusic;
    public AudioSource perfect;
    public ParticleSystem smallBoom;
    public ParticleSystem bigBoom;
    public GameObject focus;
    public int jumpForce;
    public bool triggerMou = true;
    public bool jumpCheck = true;
    public int jumpCooldown;
    public bool destroyEnemy = true;
    public GameObject picture;
    public GameObject arrow;
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        yes = GameObject.Find("Fix");
        perfect.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (true)
        {
            if(Input.GetKey(KeyCode.W))
                rb.AddForce(yes.transform.forward * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                rb.AddForce(yes.transform.forward * -speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                rb.AddForce(yes.transform.right * -speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                rb.AddForce(yes.transform.right * speed * Time.deltaTime);
            if (jumpCheck)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpCheck = false;
                    rb.AddForce(yes.transform.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
                    Invoke("turnTrue", jumpCooldown);
                }
            if (Input.GetMouseButtonDown(0))
                useSkill(); 

            currentCrystalText.text = crystalCount.ToString();
            crystalRequiredText.text = "/ " + crystalRequired.ToString();

            if (crystalCount == crystalRequired)
            {
                WinLevel1();
                arrow.gameObject.SetActive(true);
            }

            if (winBoss)
            {
                disco.gameObject.SetActive(true);
                winBoss = true;
                picture.SetActive(true);
            }


        }
    }

    public void turnTrue()
    {
        jumpCheck = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crystal")
        {
            if (crystalCount < crystalRequired)
            {
                crystalCount++;
            }
            if (other.gameObject != null)
                Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("OpenStone"))
        {
            stone.isTrigger = true;
            bossMusic.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BossTrigger"))
        {
            focus.SetActive(false);
            boss.gameObject.SetActive(true);
            if (other.gameObject != null)
                Destroy(other.gameObject);

        }
    }


    public void useSkill()
    {
        Instantiate(skill, transform.position, transform.rotation);
    }

    public void WinLevel1()
    {
        if(triggerMou)
        trigger.gameObject.SetActive(true);
        triggerMou = false;
        winLevel1 = true;
        if (spawnManager.gameObject != null)
            Destroy(spawnManager);
        focus.gameObject.SetActive(true);
        lighting.SetActive(false);
        perfect.Stop();
        if (destroyEnemy)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Enemy")[i]);
            }
            destroyEnemy = false;
        }
        
    }

    public void playMovie()
    {
        movie.Play();
    }
    public void stopMovie()
    {
        movie.Stop();
        movie.gameObject.SetActive(false);
        lighting2.SetActive(false);
        focus.SetActive(true);
    }

}
