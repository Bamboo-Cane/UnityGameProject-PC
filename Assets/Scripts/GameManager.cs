using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Toggle toggle;
    public Camera camera1;
    public Camera camera2;
    private Movement walao;
    public Button closeButton;
    public GameObject firstPage;
    public GameObject secondPage;
    public GameObject thirdPage;
    public GameObject gaming;
    public GameObject spawn;
    public GameObject openClose;
    public bool toggleCheck = true;
    // Start is called before the first frame update
    private void Start()
    {
        walao = GameObject.Find("Player").GetComponent<Movement>();
    }
    public void StartTime()
    {
  
        
            InvokeRepeating("plusTime", 11.45f, 11.45f);
        
    }

    void Update()
    {
        if (true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (toggleCheck)
                {
                    camera1.gameObject.SetActive(true);
                    camera2.gameObject.SetActive(false);
                    toggleCheck = false;
                }

                else
                {
                    camera1.gameObject.SetActive(false);
                    camera2.gameObject.SetActive(true);
                    toggleCheck = true;
                }
            }
        }
    }

    public void Close()
    {
        firstPage.gameObject.SetActive(true);
        secondPage.gameObject.SetActive(false);
        thirdPage.gameObject.SetActive(false);
    }

    public void ReadInstruction()
    {
        secondPage.gameObject.SetActive(true);
        firstPage.gameObject.SetActive(false);
    }

    public void ReadControl()
    {
        thirdPage.gameObject.SetActive(true);
        firstPage.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnterGame()
    {
        firstPage.SetActive(false);
        gaming.gameObject.SetActive(true);
        spawn.GetComponent<Spawn>().StartSpawn();
    }

    public void openQuit()
    {
        openClose.SetActive(true);
    }

    public void closeQuit()
    {
        openClose.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //firstPage.SetActive(true);
    }
}
