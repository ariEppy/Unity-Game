using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalGlow : MonoBehaviour
{
    public Text congrats;
    playerMotion2 playerMotion;
     bool talking = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMotion = FindObjectOfType<playerMotion2>();
    }

    // Update is called once per frame
    void Update()
    {
        float proximityThreshold = .5f;
        Debug.Log("in update");
        if (Vector3.Distance(playerMotion.transform.position, transform.position) <= proximityThreshold)
        {
            PlayerPrefs.SetInt("princess", 1);
            PlayerPrefs.Save();
            if (talking == false)  
                StartCoroutine(congratsShow());
        }
    }
  //  private void OnTriggerEnter(Collider other)
   // {
       // Debug.Log("in enter");
        //show a text saying congratulations and then bring me back to the main page
        //StartCoroutine(congratsShow());

   // }
    IEnumerator congratsShow()
    {
        talking = true;
        playerMotion.SetPlayerMovement(false);

        yield return new WaitForSeconds(1.0f);
        congrats.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        congrats.gameObject.SetActive(false);
       
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetInt("fatherEnd", 1);
        PlayerPrefs.Save();
        playerMotion.SetPlayerMovement(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
        talking = false;
        
    }
}
