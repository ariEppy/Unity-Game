using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarOwnerBehaviorScript : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject barOwner;
    PlayerMotion player;
    private int currentState = 0;
    private Vector3 targetPosition0 = new Vector3(53.973f, 0.471f, -2.01f);//start pos
    private Vector3 targetPosition1 = new Vector3(46.97f, 3.83f, -8.48f);//guests pos
    private Vector3 targetPosition2 = new Vector3(46.69f, 1.047f, -2.329f);//table pos
    private bool isCoroutineRunning = false; // Flag to track if a coroutine is running
    int fatherChallengeAccepted = 0;
    int barOwnerChatted = 0;
    public Text Threat1;
    public Text Threat2;
    public Text Threat3;
    public static int life = 10;
    Text life_text;
    bool inRange = false;
    private bool isCoroutine2Running = false;
    public GameObject quest_glow3;
    CoinBehavior coins;
    BombBehavior bombs;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMotion>();
        life_text = GameObject.Find("lifeNum").GetComponent<Text>();
        life = PlayerPrefs.GetInt("SetLifeAmount", 0);
        coins = FindObjectOfType<CoinBehavior>();
        bombs = FindObjectOfType<BombBehavior>();


    }

    // Update is called once per frame
    void Update()
    {
        
        fatherChallengeAccepted = PlayerPrefs.GetInt("acceptedFatherChallenge", 0);
        barOwnerChatted = PlayerPrefs.GetInt("talkedToBarOwner", 0); 

        if (fatherChallengeAccepted == 1)
        {
            quest_glow3.SetActive(true);
            if (barOwnerChatted == 1)
            {
                quest_glow3.SetActive(false);
                if (!isCoroutineRunning)
                {
                    if (currentState == 0)
                    {
                        Debug.Log(currentState);
                        MoveTargetToPosition(targetPosition1);
                        StartCoroutine(goToGuestRoutine());
                    }

                    else if (currentState == 1)
                    {
                        Debug.Log(currentState);
                        MoveTargetToPosition(targetPosition2); // Move the target to position for currentState 2
                        StartCoroutine(goToTableRoutine());
                    }

                    else
                    {
                        Debug.Log(currentState);
                        MoveTargetToPosition(targetPosition0); // Move the target to position for currentState 2
                        StartCoroutine(goBackRoutine());
                    }
                }
            }
            if(inRange == true)
            {
                if (isCoroutine2Running == false)
                {
                    StartCoroutine(seenCoroutine());
                }
            }
            if (life <= 0)
            {
                playerDies();
            }
        }
    }

    void playerDies()
    {

       
        SceneManager.LoadScene(0);


    }
    IEnumerator seenCoroutine()
    {
        isCoroutine2Running = true;
        
        life--;
        SetLifeAmount(life);
       // PlayerPrefs.SetInt("lives", life);
        //PlayerPrefs.Save();
        //life_text.text = "Lives: " + life;
        yield return new WaitForSeconds(2.0f);

        inRange = false;
        isCoroutine2Running = false;

    }
    IEnumerator ShowThreatCoroutine()
    {

        player.SetPlayerMovement(false);

        isCoroutineRunning = true;
        // yield return new WaitForSeconds(2.0f);
        animator.SetInteger("state", 7);

        // Show the first text
        Threat1.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Threat1.gameObject.SetActive(false);


        yield return new WaitForSeconds(1.0f);

        // Show the second text
        Threat2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Threat2.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        // Show the second text
        Threat3.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        Threat3.gameObject.SetActive(false);

        animator.SetInteger("state", 6);

        player.SetPlayerMovement(true);
        isCoroutineRunning = false;
        barOwnerChatted = 1;

        //turn off quest glow
        quest_glow3.SetActive(false);
  
        PlayerPrefs.SetInt("talkedToBarOwner", 1);
        PlayerPrefs.Save();


    }
    void MoveTargetToPosition(Vector3 position)
    {
        target.transform.position = position;
    }

    IEnumerator goToGuestRoutine()
    {
        isCoroutineRunning = true; // Set the flag to indicate the coroutine is running
        //yield return new WaitForSeconds(2);
        animator.SetInteger("state", 1);
        agent.SetDestination(target.transform.position);
        // Wait until the NPC has arrived at the target
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }

        animator.SetInteger("state", 3);
        barOwner.transform.rotation = Quaternion.Euler(0f, 30f, 0f);
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 4);
        yield return new WaitForSeconds(2);
        
        isCoroutineRunning = false; // Reset the flag when the coroutine is done
        currentState = 1; // Update currentState after the coroutine finishes
    }

    IEnumerator goToTableRoutine()
    {
        isCoroutineRunning = true; // Set the flag to indicate the coroutine is running
        //yield return new WaitForSeconds(2);

        animator.SetInteger("state", 1);
        agent.SetDestination(target.transform.position);
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }

        animator.SetInteger("state", 5);
        yield return new WaitForSeconds(5);
        animator.SetInteger("state", 6);
        yield return new WaitForSeconds(2);
        isCoroutineRunning = false; // Reset the flag when the coroutine is done
        currentState = 2; // Update currentState after the coroutine finishes
    }

    IEnumerator goBackRoutine()
    {
        isCoroutineRunning = true; // Set the flag to indicate the coroutine is running
        //yield return new WaitForSeconds(2);

        animator.SetInteger("state", 1);
        agent.SetDestination(target.transform.position);
        // Wait until the NPC has arrived at the target
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }
        animator.SetInteger("state", 2);
        barOwner.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        yield return new WaitForSeconds(10);

        isCoroutineRunning = false; // Reset the flag when the coroutine is done
        currentState = 0; // Update currentState after the coroutine finishes
    }

   
        private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject == player.gameObject)
        {
            
            if (barOwnerChatted == 0 && fatherChallengeAccepted == 1)
            {
                
                //speak to our player
                if (isCoroutineRunning == false)  
                {
                    StartCoroutine(ShowThreatCoroutine());
                }
            }
            else
                inRange = true;

            //if (ChestScript.isNearChest)
            //{
            //    PersistentObjectManager.lives--;
            //    Debug.Log("Player near chest");
            //}
        }

    }
    private void onTriggerExit(Collider other)
    {
        inRange = false;
    }
    public void SetLifeAmount(int amount)
    {
        life = amount;
        life_text.text = "Lives: " + life;

        PlayerPrefs.SetInt("SetLifeAmount", amount);
        PlayerPrefs.Save();
    }

}
