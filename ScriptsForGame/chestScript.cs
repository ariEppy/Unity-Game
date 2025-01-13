using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    GameObject player;
    public GameObject lid;
    public GameObject key;
    GameObject keyInHand;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mainPlayer");
         keyInHand= player.transform.GetChild(3).gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player  && PlayerPrefs.GetInt("talkedToBarMaid2", 1) == 1)
        {
            //open chest
            lid.transform.rotation = Quaternion.Euler(-95f, 180f, 0f);
            //wait a bit to show pick up of key
            StartCoroutine(pickUpKeyCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            lid.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            PlayerPrefs.SetInt("keyFromChest", 1);
            PlayerPrefs.Save();
        }
    }
    IEnumerator pickUpKeyCoroutine()
    {
        
        yield return new WaitForSeconds(1.0f);
        key.SetActive(false);
        keyInHand.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        lid.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        
    }
}
