using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FriendBehavior : MonoBehaviour
{
    private Animator animator;
    public GameObject friend;
    public GameObject player;
    public Text friend_text;
    public Text instructions;
    public Text question1;
    public Text question2;
    public Text question3;
    public Text question4;
    public Text try_again_text;
    public Text win_text;
    public Text idle_text;
    private int currentQuestion = -1;
    public bool isRight = false;
    public bool isWrong = false;
    private bool isAnswering = false;
    private bool isFirstTime = true;
    private bool isFinish = false;
    public static bool playerHasKey = false;
    PlayerMotion playerMotion;
    public GameObject quest4;
    public GameObject questglow6;
    public GameObject questglow7;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMotion = FindObjectOfType<PlayerMotion>();
    }

    void Update()
    {
        if (!isAnswering)
        {
            if (currentQuestion == 0)
            {
                StartCoroutine(startGame());
              
            }
            else if (currentQuestion == 1)
            {
                question1.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.Alpha4))
                {
                    question1.gameObject.SetActive(false);
                    StartCoroutine(answerRight());
                }
                else if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
                {
                    question1.gameObject.SetActive(false);
                    StartCoroutine(answerWrong());
                }
            }
            else if (currentQuestion == 2)
            {
                question2.gameObject.SetActive(true);

                if (Input.GetKey(KeyCode.Alpha1))
                {
                    question2.gameObject.SetActive(false);
                    StartCoroutine(answerRight());
                }
                else if (Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
                {
                    question2.gameObject.SetActive(false);
                    StartCoroutine(answerWrong());
                }
            }
            else if (currentQuestion == 3)
            {
                question3.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.Alpha3))
                {
                    question3.gameObject.SetActive(false);
                    StartCoroutine(answerRight());
                }
                else if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha4))
                {
                    question3.gameObject.SetActive(false);
                    StartCoroutine(answerWrong());
                }
            }
            else if (currentQuestion == 4)
            {
                question4.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.Alpha2))
                {
                    question4.gameObject.SetActive(false);
                    StartCoroutine(answerRight());
                }
                else if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha3))
                {
                    question4.gameObject.SetActive(false);
                    StartCoroutine(answerWrong());
                }
            }
            else if (currentQuestion == 5)
            {
                StartCoroutine(won());
            }
        }
    }
    IEnumerator startGame()
    {
        isAnswering = true;
        playerMotion.SetPlayerMovement(false);

        friend_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(7.0f);
        friend_text.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        instructions.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        instructions.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        currentQuestion = 1;
        isAnswering = false;
    }
    
    IEnumerator answerWrong()
    {
        isAnswering = true;
        animator.SetInteger("state", 5);
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 6);

        try_again_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        try_again_text.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);

        isAnswering = false;
        currentQuestion = currentQuestion;
    }

    IEnumerator answerRight()
    {
        isAnswering = true;
        animator.SetInteger("state", 3);
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 4);

        if (currentQuestion < 5)
        {
            currentQuestion++;
        }
        isAnswering = false;
    }
    IEnumerator won()
    {
        isAnswering = true;
        win_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        win_text.gameObject.SetActive(false);
        animator.SetInteger("state", 2);

        isFinish = true;
        playerHasKey = true;
        quest4.SetActive(false);
        questglow6.SetActive(false);
        PlayerPrefs.SetInt("quest4", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow6", 0);
        PlayerPrefs.Save();
        questglow7.SetActive(true);
        playerMotion.SetPlayerMovement(true);
    }
    IEnumerator returns()
    {
        playerMotion.SetPlayerMovement(false);

        animator.SetInteger("state", 1);
        idle_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        idle_text.gameObject.SetActive(false);
        animator.SetInteger("state", 2);
        playerMotion.SetPlayerMovement(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && PlayerPrefs.GetInt("talkedToBarMaid2", 0) == 1)
        {
            if (!isFinish && isFirstTime)
            {
                animator.SetInteger("state", 1);
                currentQuestion = 0;
                isFirstTime = false;
            }
            //else if (isFinish)
            //{
            //    //player returns
            //    StartCoroutine(returns());
                
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            currentQuestion = -1;
            animator.SetInteger("state", 2);

        }
    }
}
