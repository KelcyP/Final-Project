using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isRide : MonoBehaviour
{
    public GameObject sledge;
    public GameObject sledgeSanta;
    public GameObject santa;
    public GameObject reindeer1;
    public GameObject reindeer2;

    public bool isride = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isride == true)
        {
            isride = false;
            sledgeSanta.SetActive(false);
            santa.SetActive(true);
            reindeer1.GetComponent<reindeerMove>().enabled = false;
            reindeer2.GetComponent<reindeerMove>().enabled = false;
            sledge.GetComponent<sledgeMove>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) && isride == false)
        {
            isride = true;
            sledgeSanta.SetActive(true);
            santa.SetActive(false);
            reindeer1.GetComponent<reindeerMove>().enabled = true;
            reindeer2.GetComponent<reindeerMove>().enabled = true;
            sledge.GetComponent<sledgeMove>().enabled = true;
        }
    }
}
