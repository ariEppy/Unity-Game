using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class BarmaidMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    private Vector3 originalPosition;
   // public GameObject player;
    public Text keyText1;
    public Text keyText2;
    public Text keyText3;
    public Text keyText4;
    public Text keyText5;
    //public Text coinsText;
    public int hasCoins = 0;
    bool isCoroutineRunning = false;
    bool isCoroutine2Running = false;
    //bool showGold = false;
    int talkedToBarmaid1 = 0;
    int talkedToBarmaid2 = 0;
   
    int fatherChallengeAccepted;
    fatherScript fatherScriptInstance;
    PlayerMotion playerMotion;
    CoinBehavior coinBehavior;
    int spokeToBarOwner;
   
    public GameObject quest_glow4;
   


    //Start is called before the first frame update
    void Awake()
    {
        fatherScriptInstance = FindObjectOfType<fatherScript>();

    }
    void Start()
    {
        playerMotion = FindObjectOfType<PlayerMotion>();
        coinBehavior = FindObjectOfType<CoinBehavior>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        //fatherChallengeAccepted = fatherScriptInstance.challengeAccepted;
        
        fatherChallengeAccepted = PlayerPrefs.GetInt("acceptedFatherChallenge", 0);
        spokeToBarOwner = PlayerPrefs.GetInt("talkedToBarOwner", 0);
        talkedToBarmaid1 = PlayerPrefs.GetInt("talkedToBarMaid1", 0);  
        talkedToBarmaid2 = PlayerPrefs.GetInt("talkedToBarMaid2", 0); 

        if (fatherChallengeAccepted == 1 && spokeToBarOwner == 1)
        {
            if (talkedToBarmaid2 == 0)
            {
                //show quest glow
                quest_glow4.SetActive(true);
            }
            float proximityThreshold = .7f;

            if (Vector3.Distance(playerMotion.gameObject.transform.position, target.transform.position) <= proximityThreshold && talkedToBarmaid2 == 0)
            { //if we're in the proximity of the barmaid and we havent finished talking to her yet
                
                if (talkedToBarmaid1 == 0 )
                { //if we havent talked once to her then she'll tell us the mission or if we have talked to her but we dont have the amount of coins then retell the mission
                    
                    if (isCoroutineRunning == false)
                    {

                        StartCoroutine(ShowTextCoroutine());
                        
                    }

                }
                //if we have talked and have the coins
                if (hasCoins >= 5 && talkedToBarmaid1 == 1)
                {
                    if (isCoroutine2Running == false)
                    {
                        
                        StartCoroutine(ShowCoinsTextCoroutine());
                    }
                }

            }
            else
            {
                isCoroutineRunning = false;
                isCoroutine2Running = false;
            }


        }
        hasCoins = CoinBehavior.num_coins;
    }
    IEnumerator ShowTextCoroutine()
    {
        playerMotion.SetPlayerMovement(false);
        isCoroutineRunning = true;

        yield return new WaitForSeconds(2.0f);
        animator.SetInteger("State2", 2);

        // Show the first text
        keyText1.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        keyText1.gameObject.SetActive(false);


        yield return new WaitForSeconds(1.0f);

        // Show the second text
        keyText2.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        keyText2.gameObject.SetActive(false);

        animator.SetInteger("State2", 3);
        yield return new WaitForSeconds(1.0f);  

        talkedToBarmaid1 = 1;
        
        PlayerPrefs.SetInt("talkedToBarMaid1", 1);
        PlayerPrefs.Save();
        playerMotion.SetPlayerMovement(true);

        


    }
    IEnumerator ShowCoinsTextCoroutine()
    {
        playerMotion.SetPlayerMovement(false);
        isCoroutine2Running = true;

        //coinsText.gameObject.SetActive(false);

        yield return new WaitForSeconds(2.0f);
        animator.SetInteger("State2", 2);

        // Show the first text
        keyText3.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);

        hasCoins -= 5;
        coinBehavior.SetCoinAmount(hasCoins);
        keyText3.gameObject.SetActive(false);


        yield return new WaitForSeconds(1.0f);

        // Show the second text
        keyText4.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        keyText4.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        // Show the second text
        keyText5.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        keyText5.gameObject.SetActive(false);

        animator.SetInteger("State2", 3);
        yield return new WaitForSeconds(1.0f);

        talkedToBarmaid2 = 1;
        playerMotion.SetPlayerMovement(true);
        quest_glow4.SetActive(false);
        
        PlayerPrefs.SetInt("talkedToBarMaid2", 1);
        PlayerPrefs.Save();

    }

    
}
