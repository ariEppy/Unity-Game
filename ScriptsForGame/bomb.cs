using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject explosion;
    float radius = 1f;
    GameObject ourPlayer;
    GameObject ourPlayerSword;

    void Start()
    {
        ourPlayer = GameObject.Find("mainPlayer");
        ourPlayerSword = GameObject.Find("mainPlayer/SM_Wep_Sword_01");
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the bomb hits a moving or still body
        
        StartCoroutine(BombThrown(2f, collision.transform));
    }

    IEnumerator BombThrown(float delay, Transform target)
    {
        // The bomb sticks to the body it hit and make it a child of the body
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = target;
        Debug.Log("in bomb script");
        // Show the explosion
        explosion.gameObject.SetActive(true);
        AudioSource sound = GetComponent<AudioSource>();
        sound.Play();

        // Wait for 2 seconds
        yield return new WaitForSeconds(delay);

        // Hide the NPCs/rigidbodies hit (except for our player! in case he was close to the explosion)
        Collider[] colliders = Physics.OverlapSphere(target.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && rb.gameObject != ourPlayer && rb.gameObject != ourPlayerSword)
            {
                Debug.Log(nearbyObject.gameObject);
                nearbyObject.gameObject.SetActive(false);
            }
        }

        
        //restore the bomb to its own object
        transform.parent = null;

        // Destroy the bomb
        explosion.gameObject.SetActive(false);
        gameObject.SetActive(false);
       
        
    }
}
