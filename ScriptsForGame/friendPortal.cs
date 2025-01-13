using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class friendPortal : MonoBehaviour
{
    public GameObject player;
    public GameObject questglow7;
    private AudioSource door;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject && FriendBehavior.playerHasKey == true)
        {
            //if we're entering the room
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {

                StartCoroutine(doors1());
            }

            else
            {
                //we're leaving the room

                StartCoroutine(doors2());
            }

        }

    }
    IEnumerator doors1()
    {

        if (!door.isPlaying)
            door.Play();

        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("prevScene", 1);
        PlayerPrefs.Save();
        //quest3.SetActive(false);
        //questGlow5.SetActive(false);
        questglow7.SetActive(false);
        SceneManager.LoadScene(3);
    }
    IEnumerator doors2()
    {

        if (!door.isPlaying)
            door.Play();

        yield return new WaitForSeconds(1.0f);
        transform.position = new Vector3(48.6f, .05f, -70f);
        PlayerPrefs.SetInt("prevScene", 3);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow9", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("quest6", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        transform.position = new Vector3(48.6f, .05f, -70f);
    }
    }
