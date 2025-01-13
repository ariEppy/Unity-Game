using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombThrow : MonoBehaviour
{
    public float throwStrength;
    public GameObject bombPrefab;
    public Transform cam;
    public Transform throwPoint;
    public float throwUpwardForce;
    BombBehavior bombBehavior;
    private int hasBombs = 0;
    

    void Start()
    {
        bombBehavior = FindObjectOfType<BombBehavior>();
        Debug.Log(hasBombs);
    }
    
    void Update()
    {
        //if the gamer pressed G and has bombs to throw
        hasBombs = BombBehavior.num_bombs;
        if (Input.GetKeyDown(KeyCode.G) && hasBombs > 0)
        {
            Debug.Log("in bomb throw");
            ThrowBomb();
          
        }
    }
    void ThrowBomb()
    {
        //make an instance of the bomb prefab 
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, cam.rotation);
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        Vector3 throwDirection = cam.transform.forward;

        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            throwDirection = (hit.point - throwPoint.position).normalized;
        }
        Vector3 forcesToAdd = (throwDirection * throwStrength) + (transform.up * throwUpwardForce);
        bombRb.AddForce(forcesToAdd, ForceMode.Impulse);

        //update the bomb count
        hasBombs--;
        bombBehavior.SetBombAmount(hasBombs);
    }
 
    



}
