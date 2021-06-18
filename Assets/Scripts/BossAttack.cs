using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttack : MonoBehaviour
{
    public GameObject[] bossSkill;
    public int currentBossHealth;
    public Rigidbody rb;
    public int yOffSet;
    public int randomX,randomY,randomZ;
    public int pushBackForce;
    public Text bossHealthText;
    public GameObject player;
    public GameObject[] face;
    public GameObject bossIcon;
    public float spawnTime;
    public float faceTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("releaseSkill", 3f, spawnTime);
        InvokeRepeating("ChangeFace", 1f, faceTime);
        bossIcon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        bossHealthText.text = currentBossHealth.ToString() + " %";

        if (currentBossHealth == 0)
        {
            for(int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Enemy")[i]);
            }

            if(gameObject != null)
            {
                
                player.GetComponent<Movement>().winBoss = true;
                Destroy(gameObject);
            }
            

        } 
    }

    void releaseSkill()
    {
        Instantiate(bossSkill[RandomBossSkill()], new Vector3(transform.position.x, (transform.position.y + yOffSet), transform.position.z), transform.rotation);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Skill"))
        {
            if (currentBossHealth > 0)
            {
                currentBossHealth--;
            }
            Instantiate(player.GetComponent<Movement>().smallBoom, other.transform.position, transform.rotation);
            if(currentBossHealth == 0)
            {
                Instantiate(player.GetComponent<Movement>().bigBoom, other.transform.position, transform.rotation);
            }
        }
    }
    
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            rb.AddForce(BossRandomJump());
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.AddForce((transform.position - collision.transform.position).normalized * pushBackForce);
        }

        
    }


    Vector3 BossRandomJump()
    {
        Vector3 jumpPosition = new Vector3(Random.Range(-randomX, randomX), Random.Range(randomY, (randomY+randomY)), Random.Range(-randomZ, randomZ));
        return jumpPosition;
    }

    int RandomBossSkill()
    {
        return Random.Range(0, bossSkill.Length);
;    }

    public void ChangeFace()
    {
        int number = Random.Range(0, face.Length);

        for(int i = 0; i < face.Length; i++)
        {
               if(i == number)
                        { 
                        face[i].gameObject.SetActive(true);
                        }
                        else
                        {
                            face[i].gameObject.SetActive(false);
                        }
                        
                    
           
                
        }

    }
}
