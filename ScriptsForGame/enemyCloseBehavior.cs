using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCloseBehavior : MonoBehaviour
{
    public GameObject ourPlayer;
    public bool playerClose = false;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == ourPlayer)
        {
            playerClose = true;
            Debug.Log("near enemy");

        }
    }
}
