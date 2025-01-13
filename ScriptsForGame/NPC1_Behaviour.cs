using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC1_Behaviour : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject npc;
    private int currentState = 0;
    private Vector3 targetPos1 = new Vector3(43.269001f, 0.372000009f, 14.96f);//cemetery pos
    private Vector3 targetPos2 = new Vector3(24f, 0f, 18.5f);//market pos
    private Vector3 targetPos3 = new Vector3(15.65f, 0.45f, 4.77f);//statue pos
    private Vector3 targetPos4 = new Vector3(38.1399994f, 0.479999989f, -2.5f);//tavern pos
    private bool isCoroutineRunning = false; // Flag to track if a coroutine is running
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCoroutineRunning)
        {
            if (currentState == 0)
            {
                MoveTargetToPosition(targetPos1);
                StartCoroutine(goToCemetery());
            }
            else if (currentState == 1)
            {
                MoveTargetToPosition(targetPos2);
                StartCoroutine(goToMarket());
            }
            else if (currentState == 2)
            {
                MoveTargetToPosition(targetPos3);
                StartCoroutine(goToStatue());
            }
            else
            {
                MoveTargetToPosition(targetPos4);
                StartCoroutine(goToTavern());
            }
        }
    }

    void MoveTargetToPosition(Vector3 position)
    {
        target.transform.position = position;
    }

    IEnumerator goToCemetery()
    {
        isCoroutineRunning = true; // Set the flag to indicate the coroutine is running
        yield return new WaitForSeconds(5);
        animator.SetInteger("state", 1);
        agent.SetDestination(target.transform.position);
        // Wait until the NPC has arrived at the target
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 3);
        yield return new WaitForSeconds(30);
        animator.SetInteger("state", 4);
        yield return new WaitForSeconds(2);
        isCoroutineRunning = false; // Reset the flag when the coroutine is done
        currentState = 1; // Update currentState after the coroutine finishes
    }

    IEnumerator goToMarket()
    {
        isCoroutineRunning = true; // Set the flag to indicate the coroutine is running
        animator.SetInteger("state", 1);
        agent.SetDestination(target.transform.position);
        // Wait until the NPC has arrived at the target
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 7);
        yield return new WaitForSeconds(30);
        animator.SetInteger("state", 8);
        yield return new WaitForSeconds(2);
        isCoroutineRunning = false; // Reset the flag when the coroutine is done
        currentState = 2; // Update currentState after the coroutine finishes
    }
    
    IEnumerator goToStatue()
    {
        isCoroutineRunning = true; // Set the flag to indicate the coroutine is running
        animator.SetInteger("state", 1);
        agent.SetDestination(target.transform.position);
        // Wait until the NPC has arrived at the target
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 5);
        yield return new WaitForSeconds(30);
        animator.SetInteger("state", 6);
        yield return new WaitForSeconds(2);
        isCoroutineRunning = false; // Reset the flag when the coroutine is done
        currentState = 3; // Update currentState after the coroutine finishes
    }

    IEnumerator goToTavern()
    {
        isCoroutineRunning = true; // Set the flag to indicate the coroutine is running
        animator.SetInteger("state", 1);
        agent.SetDestination(target.transform.position);
        // Wait until the NPC has arrived at the target
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }
        animator.SetInteger("state", 2);
        yield return new WaitForSeconds(2);
        npc.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        yield return new WaitForSeconds(2);
        animator.SetInteger("state", 9);
        yield return new WaitForSeconds(30);
        animator.SetInteger("state", 10);
        yield return new WaitForSeconds(2);
        isCoroutineRunning = false; // Reset the flag when the coroutine is done
        currentState = 0; // Update currentState after the coroutine finishes
    }
}
