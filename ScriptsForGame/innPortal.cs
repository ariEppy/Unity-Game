using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class innPortal : MonoBehaviour
{
    private PlayerMotion player;
    public GameObject quest3;
    public GameObject quest_glow5;
    private AudioSource door;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMotion>();
        door = GetComponent<AudioSource>();
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
        transform.position = new Vector3(41, .17f, 1);
        PlayerPrefs.SetInt("prevScene", 2);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("quest3", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow5", 1);
        PlayerPrefs.Save();
        //quest3.SetActive(true);
        //quest_glow5.SetActive(true);
        SceneManager.LoadScene(1);
        transform.position = new Vector3(41, .17f, 1);
    }
    }
