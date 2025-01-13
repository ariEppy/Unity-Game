using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hideoutScript : MonoBehaviour
{
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
        //turn off quest buttons and take me to hideout
        StartCoroutine(doors());

    }
    IEnumerator doors()
    {

        if (!door.isPlaying)
            door.Play();
        yield return new WaitForSeconds(1.0f);
        PlayerPrefs.SetInt("prevScene", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("quest6", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow9", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(5);
    }
    }
