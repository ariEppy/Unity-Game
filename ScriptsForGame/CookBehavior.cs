using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookBehavior : MonoBehaviour
{
    private Animator animator;
    public GameObject cook;
    public GameObject player;
    public Text start_text;
    public Text win_text;
    public Text task0;
    public Text task1;
    public Text task2;
    public Text task3;
    public GameObject book_in_hand;
    public GameObject flower_in_hand;
    public GameObject wine_in_hand;
    public GameObject basket_in_hand;
    PlayerMotion playerMotion;
    bool talking = false;
    bool talkedToCook = false;
    public GameObject quest5;
    public GameObject questglow8;
    public GameObject cookStandIn;

    // Start is called before the first frame update
    void Start()
    {
        playerMotion = FindObjectOfType<PlayerMotion>();
        animator = GetComponent<Animator>();
      

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("acceptedFatherChallenge", 0) == 1 && PlayerPrefs.GetInt("fatherEnd", 0) == 0 || PlayerPrefs.GetInt("cookEnd", 0) == 1)
        {
            //if we accepted the father challenge then disable the cook quest
            cook.SetActive(false);
            cookStandIn.SetActive(true);
            quest5.SetActive(false);
            questglow8.SetActive(false);
        }
        if (PlayerPrefs.GetInt("fatherEnd", 0) == 1 && PlayerPrefs.GetInt("cookFinish", 0) == 0)
        {
            //if we finished the father challenge and the cook quest isnt done yet then enable the cook quest
            cook.SetActive(true);
            cookStandIn.SetActive(false);
            quest5.SetActive(true);
            questglow8.SetActive(true);
        }
        
        //check which task
        if (PlayerPrefs.GetInt("nearCook", 0) == 1)
        {
            if (PlayerPrefs.GetInt("currentCookTask", 0) == -1 && talkedToCook == false)
            {
                if (talking == false)
                    StartCoroutine(startTexts1(start_text));
            }
             if (Input.GetKey(KeyCode.Space) && PlayerPrefs.GetInt("currentCookTask", 0) == -1 && talkedToCook == true)
               {
                    PlayerPrefs.SetInt("cookChallenge", 1);
                    PlayerPrefs.Save();
                    PlayerPrefs.SetInt("currentCookTask", 0);
                    PlayerPrefs.Save();
                    talking = false;
                      

                }
            
             if (PlayerPrefs.GetInt("currentCookTask", 0) == 0)
            {
                if (PlayerPrefs.GetInt("hasIngredient", 0) == 0)
                {
                    book_in_hand.SetActive(false);
                    PlayerPrefs.SetInt("currentCookTask", 1);
                    PlayerPrefs.Save();
                }
                else
                {
                    if (talking == false)
                        StartCoroutine(startTexts(task0));
                }
                   
            }
           
             if (PlayerPrefs.GetInt("currentCookTask", 0) == 1)
            {
                if (PlayerPrefs.GetInt("hasIngredient", 0) == 1)
                {
                    flower_in_hand.SetActive(false);
                    PlayerPrefs.SetInt("currentCookTask", 2);
                    PlayerPrefs.Save();
                }
                else
                {
                    if (talking == false)
                        StartCoroutine(startTexts(task1));
                }
            }
             if (PlayerPrefs.GetInt("currentCookTask", 0) == 2)
            {
                if (PlayerPrefs.GetInt("hasIngredient", 0) == 2)
                {
                    wine_in_hand.SetActive(false);
                    PlayerPrefs.SetInt("currentCookTask", 3);
                    PlayerPrefs.Save();
                }
                else
                {
                    if (talking == false)
                        StartCoroutine(startTexts(task2));
                }
            }
             if (PlayerPrefs.GetInt("currentCookTask", 0) == 3)
            {
                if (PlayerPrefs.GetInt("hasIngredient", 0) == 3)
                {
                    basket_in_hand.SetActive(false);
                    PlayerPrefs.SetInt("currentCookTask", 4);
                    PlayerPrefs.Save();
                }
                else
                {
                    if (talking == false)
                        StartCoroutine(startTexts(task3));
                }
            }
             if(PlayerPrefs.GetInt("currentCookTask", 0) == 4)
            {

                if (talking == false)
                {
                    
                    StartCoroutine(end());
                }
                
            }
            
                
            }
        else
        {
            talking = false;
        }
    }
    IEnumerator end()
    {
        talking = true;
        playerMotion.SetPlayerMovement(false);

        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 1);
        win_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        win_text.gameObject.SetActive(false);
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(1);
        playerMotion.SetPlayerMovement(true);

        PlayerPrefs.SetInt("cookFinish", 1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("cookEnd", 1);
        PlayerPrefs.Save();
        talking = false;
    }
    IEnumerator startTexts1(Text text)
    {
        talking = true;
        playerMotion.SetPlayerMovement(false);

        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 1);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        text.gameObject.SetActive(false);
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(1);

        talkedToCook = true;
    playerMotion.SetPlayerMovement(true);


}
    IEnumerator startTexts(Text text)
    {
        talking = true;
        playerMotion.SetPlayerMovement(false);
        
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 1);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        text.gameObject.SetActive(false);
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(1);

        
        playerMotion.SetPlayerMovement(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            
            //if we're starting
            if (PlayerPrefs.GetInt("currentCookTask", 0) == -2 && PlayerPrefs.GetInt("cookFinish", 0) == 0)
            {
                PlayerPrefs.SetInt("currentCookTask", -1);
                PlayerPrefs.Save();
                
            }

            PlayerPrefs.SetInt("nearCook", 1);
            PlayerPrefs.Save();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            
            animator.SetInteger("state", 2);
            PlayerPrefs.SetInt("nearCook", 0);
            PlayerPrefs.Save();
        }
    }
}