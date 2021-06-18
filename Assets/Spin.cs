using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 spin;
    public GameObject player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Movement>().winBoss == true)
        {
            transform.Rotate(spin);
        }
    }
}
