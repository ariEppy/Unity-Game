using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class fatherScript : MonoBehaviour
{
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;
    public Text helpText1;
    public Text helpText2;
    public Text helpText3;
    public Text helpText4;
    public Text helpText5;
    public Text helpText6;
    public Text helpText7;
    public GameObject target;
    private Vector3 originalPosition;
    bool isCoroutineRunning = false;
    bool talkedToFatherPart1 = false;
    bool talkedToFatherPart2 = false;
    bool isCoroutine2Running = false;
    public bool challengeAccepted = false;
    PlayerMotion playerMotion;
    public GameObject quest;
    public GameObject quest_glow;
    public GameObject quest2;  
    public GameObject quest_glow2;

    int fatherAccepted;

    // Start is called before the first frame update
    void Start()
    {
        playerMotion = FindObjectOfType<PlayerMotion>();
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        originalPosition = transform.position;

        fatherAccepted = PlayerPrefs.GetInt("acceptedFatherChallenge", 0);
        if (fatherAccepted == 1)
        {
            animator.SetInteger("approach", 2);
            quest.SetActive(false);
            quest_glow.SetActive(false);
            challengeAccepted = true;
            
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        float proximityThreshold = 1.5f;

        if (fatherAccepted == 0)
        {

            if (Vector3.Distance(playerMotion.transform.position, target.transform.position) <= proximityThreshold &&
                (talkedToFatherPart1 == false || (talkedToFatherPart1 == true && talkedToFatherPart2 == false)))
            {
                if (isCoroutineRunning == false && talkedToFatherPart1 != true)
                {

                    StartCoroutine(ShowHelpCoroutine());


                }

                if (Input.GetKey(KeyCode.Space) && isCoroutine2Running == false && talkedToFatherPart1 == true)
                {

                    StartCoroutine(AcceptHelpCoroutine());

                }
            }
            else
            {
                isCoroutineRunning = false;
                isCoroutine2Running = false;
            }
        }
    }

    IEnumerator ShowHelpCoroutine()
    {
       
        playerMotion.SetPlayerMovement(false);
   
        isCoroutineRunning = true;
        // yield return new WaitForSeconds(2.0f);
        animator.SetInteger("approach", 1);

        // Show the first text
        helpText1.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        helpText1.gameObject.SetActive(false);


        yield return new WaitForSeconds(1.0f);

        // Show the second text
        helpText2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        helpText2.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        // Show the second text
        helpText3.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        helpText3.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        // Show the second text
        helpText4.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        helpText4.gameObject.SetActive(false);

        animator.SetInteger("approach", 2);
        //yield return new WaitForSeconds(1.0f);

        playerMotion.SetPlayerMovement(true);
        talkedToFatherPart1 = true;
        
    }
    IEnumerator AcceptHelpCoroutine()
    {
        playerMotion.SetPlayerMovement(false);
        
        isCoroutine2Running = true;
        // yield return new WaitForSeconds(2.0f);
        animator.SetInteger("approach", 1);

        // Show the first text
        helpText5.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        helpText5.gameObject.SetActive(false);


        yield return new WaitForSeconds(1.0f);

        // Show the second text
        helpText6.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        helpText6.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        // Show the third text
        helpText7.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        helpText7.gameObject.SetActive(false);

        animator.SetInteger("approach", 2);
        yield return new WaitForSeconds(1.0f);

        playerMotion.SetPlayerMovement(true);
        talkedToFatherPart2 = true;
        challengeAccepted = true;
        quest.SetActive(false);
        quest_glow.SetActive(false);

        fatherAccepted = 1;
       
        PlayerPrefs.SetInt("acceptedFatherChallenge", 1);
        PlayerPrefs.Save();
        quest2.SetActive(true);
        quest_glow2.SetActive(true);
        PlayerPrefs.SetInt("quest2", 1);
        PlayerPrefs.Save();
    }
}
