using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bombPortal : MonoBehaviour
{
    public GameObject quest3;
    public GameObject questGlow5;
    public GameObject quest4;
    public GameObject questGlow6;
    private AudioSource door;
    public GameObject player;

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
        if (other.gameObject == player.gameObject)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1 && PlayerPrefs.GetInt("keyFromChest", 0) == 1)
            {
                StartCoroutine(doors1());
            }
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
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
        PlayerPrefs.SetInt("keyFromChest", 0);
        PlayerPrefs.Save();
        // quest3.SetActive(false);
        PlayerPrefs.SetInt("quest3", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow5", 0);
        PlayerPrefs.Save();
        //questGlow5.SetActive(false);
        SceneManager.LoadScene(4);
    }
    IEnumerator doors2()
    {

        if (!door.isPlaying)
            door.Play();
        yield return new WaitForSeconds(1.0f);
        transform.position = new Vector3(58.29f, .11f, -2.57f);
        PlayerPrefs.SetInt("prevScene", 4);
        PlayerPrefs.Save();
        //quest4.SetActive(true);
        //questGlow6.SetActive(true);
        PlayerPrefs.SetInt("quest4", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow6", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        transform.position = new Vector3(58.29f, .11f, -2.57f);

    }
    }
