using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainInnPortal : MonoBehaviour
{
    GameObject player;
    public GameObject quest2;
    public GameObject questGlow2;
    private AudioSource door;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<AudioSource>();
        player = GameObject.Find("mainPlayer");

    }

    // Update is called once per frame
    void Update()
    {


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            StartCoroutine(doors());
            
        }

            

        

    }
    IEnumerator doors()
    {
        
        if (!door.isPlaying)
            door.Play();
        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("prevScene", 1);
        PlayerPrefs.Save();
        quest2.SetActive(false);
        questGlow2.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
