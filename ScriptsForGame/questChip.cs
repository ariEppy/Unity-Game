using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questChip : MonoBehaviour
{
    GameObject playerMotion;
    float distanceToPlayer;
    float originalY = 3f; 

    // Start is called before the first frame update
    void Start()
    {
        playerMotion = GameObject.Find("mainPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        //when we get closer to it it lowers and gets smaller (and hovers above the yellow glow)
        distanceToPlayer = Mathf.Abs(transform.position.x - playerMotion.transform.position.x);
       
        if (distanceToPlayer <= 20 && distanceToPlayer >= 3)
        {
            transform.position = new Vector3(transform.position.x, distanceToPlayer, transform.position.z);
            transform.localScale = new Vector3((distanceToPlayer / 3), (distanceToPlayer / 3), (distanceToPlayer / 3));
        }
        if(distanceToPlayer > 20 )
        {
            transform.position = new Vector3(transform.position.x, 20, transform.position.z);
            transform.localScale = new Vector3((20/3), (20/3), (20/3));
        }

 

    }
}
