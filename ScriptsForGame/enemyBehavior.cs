using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyBehavior : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Animator animator;
    private Vector3 targetPos1; 
    private Vector3 targetPos2;
    public GameObject targetPos3; 
    public GameObject targetPos4; 
    
    bool playerSeen = false;
    bool playerclose;
    float detectionRange = 20f;
    private int start = 0;
    Vector3 target;
    float offsetDistance = 1.0f;
    Vector3 targetPosition;
    Vector3 offsetDirection;
    enemyCloseBehavior enemyClose;
    swordPlayerBehavior swordBehav;
    bool nextToPlayer = false;

    public GameObject sphere;
    public GameObject playerMotion;
    public GameObject bodyTransform;
    int isEnemyDead;
    string enemyIdentifier;
    GameObject enemyObject;
    public GameObject enemytest;
    Transform parentTransform;


    void Awake()
    {
        targetPos1 = targetPos3.transform.position;
        targetPos2 = targetPos4.transform.position;
        target = targetPos1;
         
        
        animator = GetComponent<Animator>();
        enemyClose = GetComponentInChildren<enemyCloseBehavior>();
        swordBehav = FindObjectOfType<swordPlayerBehavior>();
        

        enemyIdentifier = gameObject.name;
        

        isEnemyDead = PlayerPrefs.GetInt(enemyIdentifier, 0);


        //1 is dead, 0 is alive
        //if (PlayerPrefs.GetInt(enemyIdentifier, 1);)
        //{

        //    gameObject.SetActive(false);
        //}



    }

    //Update is called once per frame
    void Update()
    {
        Debug.Log(enemyIdentifier + " " + PlayerPrefs.GetInt(enemyIdentifier, 0));
        offsetDirection = (transform.position - playerMotion.transform.position).normalized;
        targetPosition = playerMotion.transform.position + offsetDirection * offsetDistance;
        playerclose = enemyClose.playerClose;
        
        //enemy should be pacing back and forth
        if (start == 0)
        {
            MoveTargetToPosition(targetPos2);
            StartCoroutine(atPosition(start));
        }
        else if (start == 1)
        {
            MoveTargetToPosition(targetPos1);
            StartCoroutine(atPosition(start));
        }

        // Check if the enemy can see the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0f, .2f, 0f), transform.forward, out hit, detectionRange))
        {
            Debug.DrawRay(transform.position + new Vector3(0f, 1f, .2f), transform.forward * detectionRange, Color.green);
            //Debug.Log(hit.collider.gameObject);
            if (hit.collider.gameObject == bodyTransform.gameObject || hit.collider.gameObject == playerMotion.gameObject)
            {
                Debug.Log(gameObject.name);
                Debug.Log("Player seen!");
                playerSeen = true;
                //stop going back and forth
                start = 2;

            }
            
        }

        //lots of checks - did we hurt the enemy, did the enemy die, was the player seen or too close to the enemy, is the enemy right next to the player,...
        if (PlayerPrefs.GetInt(enemyIdentifier, 0) == 2)
        {
            StartCoroutine(enemyHurtWait());
            
        }
        if (PlayerPrefs.GetInt(enemyIdentifier, 0) == 3)
        {

            StartCoroutine(enemyDies());
        }
                       
        if(playerclose == true || playerSeen == true)
        {
            start = 2;
            chasePlayer();
        }
        if(nextToPlayer == true && PlayerPrefs.GetInt(enemyIdentifier, 0) != 3)
        {
            attack();
        }
        
        if (Vector3.Distance(enemy.transform.position, targetPosition) <= 1.0f)
        {
            nextToPlayer = true;
        }
        if (Vector3.Distance(enemy.transform.position, targetPosition) > 1.1f)
        {
            nextToPlayer = false;
            animator.SetInteger("state", 1);
            
        }
        

    }

    void chasePlayer()
    {
       
        enemy.SetDestination(targetPosition);
        //enemy  looks at player
        transform.LookAt(playerMotion.transform);  
    }
    void attack()
    {   
        animator.SetInteger("state", 3);
    }
   
    
IEnumerator atPosition(int startp)
{
        enemy.angularSpeed = 250f; 
        enemy.SetDestination(target);
        // Wait until the NPC has arrived at the target
        while (enemy.pathPending || enemy.remainingDistance > enemy.stoppingDistance)
        {
            yield return null;
        }
        
        if(startp == 0)
            start = 1;
        else if (startp == 1)
            start = 0;
        else start = 2;

}
   
    void MoveTargetToPosition(Vector3 position)
    {
    
        target = position;
      
    }
    
    IEnumerator enemyHurtWait()
    {

        PlayerPrefs.SetInt("waiting", 0);
        PlayerPrefs.Save();
        Debug.Log("enemy hurt");
        animator.SetInteger("state", 4);
        yield return new WaitForSeconds(1.233f);
       


    }
    IEnumerator enemyDies()
    {

        sphere.SetActive(false);
        Debug.Log("enemy dies");
        animator.SetInteger("state", 5);
        yield return new WaitForSeconds(2f);
        
        enemytest.SetActive(false);
        
        
    }

}
