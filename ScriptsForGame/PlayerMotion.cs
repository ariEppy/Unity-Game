using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMotion : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 7;
    public GameObject camera;
    private AudioSource steps;
   
    public GameObject book_in_hand;
    public GameObject book_in_boat;
    public GameObject flower_in_hand;
    public GameObject flower_in_forest;
    public GameObject wine_in_hand;
    public GameObject wine_in_tavern;
    public GameObject basket_in_hand;
    public GameObject basket_in_market;
    private bool canMove = true;
   

    Animator animator;
    Animator animator2;
   
 
    GameObject key;
    public GameObject quest2;
    public GameObject questGlow2;
    public GameObject quest3;
    public GameObject questGlow5;
    public GameObject quest4;
    public GameObject questGlow6;
    public GameObject questGlow7;
    float proximityThreshold = 1.5f;
    public Text friend_text;
    public GameObject fatherChallenge;
    public GameObject fatherStandIn;
    public GameObject quest1;
    public GameObject questglow1;
    public GameObject quest6;
    public GameObject questGlow9;

    void Awake()
    {
      
        key = transform.GetChild(3).gameObject;
        int prevScene = PlayerPrefs.GetInt("prevScene", 0);

        if (prevScene == 2 )
        {
            transform.position = new Vector3(41, .17f, 1);
            Debug.Log("Back from Scene 2");
        }
        if (prevScene == 3 )
        {
            transform.position = new Vector3(48.6f, .05f, -70f);
            Debug.Log("Back from Scene 3");
        }
        if (prevScene == 4 ) 
        {
            transform.position = new Vector3(58.29f, .11f, -2.57f);
            Debug.Log("back from Scene 4");
        }
        
        if (PlayerPrefs.GetInt("prevScene", 0) == 4)
            StartCoroutine(showFriendText());
       
    }

    // Start is called before the first frame update
    void Start()
    {
        steps = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        if (PlayerPrefs.GetInt("keyFromChest", 0) == 1)
        {
            key.gameObject.SetActive(true);

        }
        else key.gameObject.SetActive(false);

        
    }

    IEnumerator showFriendText()
    {
        yield return new WaitForSeconds(2.0f);
        friend_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        friend_text.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
        float dx, dz;
        float rotation_around_Y;
        float rotation_around_X;

        if (PlayerPrefs.GetInt("quest3", 0) == 1)
        {
            quest3.SetActive(true);
        }        
        if (PlayerPrefs.GetInt("questglow5", 0) == 1)
        {
            questGlow5.SetActive(true);
        }
        if (PlayerPrefs.GetInt("quest3", 0) == 0)
        {
            quest3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("questglow5", 0) == 0)
        {
            questGlow5.SetActive(false);
        }
        if (PlayerPrefs.GetInt("quest4", 0) == 1)
        {
            quest4.SetActive(true);
        }
        if (PlayerPrefs.GetInt("questglow6", 0) == 1)
        {
            questGlow6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("quest4", 0) == 0)
        {
            quest4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("questglow6", 0) == 0)
        {
            questGlow6.SetActive(false);
        }
        if (PlayerPrefs.GetInt("quest6", 0) == 1)
        {
            quest6.SetActive(true);
        }
        if (PlayerPrefs.GetInt("questglow9", 0) == 1)
        {
            questGlow9.SetActive(true);
        }
        if (PlayerPrefs.GetInt("quest6", 0) == 0)
        {
            quest6.SetActive(false);
        }
        if (PlayerPrefs.GetInt("questglow9", 0) == 0)
        {
            questGlow9.SetActive(false);
        }


        if (PlayerPrefs.GetInt("cookEnd", 0) == 1 && PlayerPrefs.GetInt("fatherEnd", 0) == 1)
        {
            //then end game
            SceneManager.LoadScene(0);
        }
            //cook mission
            //if we finished the cook challenge and we havent yet done the father quest then turn on father quest
            if (PlayerPrefs.GetInt("cookEnd", 0) == 1 && PlayerPrefs.GetInt("fatherEnd", 0) == 0)
        {
            fatherChallenge.SetActive(true);
            fatherStandIn.SetActive(false);
            quest1.SetActive(true);
            questglow1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("cookChallenge", 0) == 1 || PlayerPrefs.GetInt("fatherEnd", 0) == 1)
        {
            //if we're doing the cook challenge then disable the father challenge
            fatherChallenge.SetActive(false);
            fatherStandIn.SetActive(true);
            quest1.SetActive(false);
            questglow1.SetActive(false);
        }
            if (PlayerPrefs.GetInt("currentCookTask", 0) == 0 && Vector3.Distance(transform.position, book_in_boat.transform.position) <= proximityThreshold)
            {        
                book_in_boat.SetActive(false);
                book_in_hand.SetActive(true);
                PlayerPrefs.SetInt("hasIngredient", 0);
                PlayerPrefs.Save();
             }


            if (PlayerPrefs.GetInt("currentCookTask", 0) == 1 && Vector3.Distance(transform.position, flower_in_forest.transform.position) <= proximityThreshold)
            {
                flower_in_forest.SetActive(false);
                flower_in_hand.SetActive(true);
                PlayerPrefs.SetInt("hasIngredient", 1);
                PlayerPrefs.Save();
               
            }
            if (PlayerPrefs.GetInt("currentCookTask", 0) == 2 && Vector3.Distance(transform.position, wine_in_tavern.transform.position) <= proximityThreshold)
            {
                wine_in_tavern.SetActive(false);
                wine_in_hand.SetActive(true);
                PlayerPrefs.SetInt("hasIngredient", 2);
                PlayerPrefs.Save();

            }
            if (PlayerPrefs.GetInt("currentCookTask", 0) == 3 && Vector3.Distance(transform.position, basket_in_market.transform.position) <= proximityThreshold)
            {
                basket_in_market.SetActive(false);
                basket_in_hand.SetActive(true);
                PlayerPrefs.SetInt("hasIngredient", 3);
                PlayerPrefs.Save();

            }

        

        //player's motion
        rotation_around_Y = Input.GetAxis("Mouse X"); // horizontal mouse motion
        transform.Rotate(new Vector3(0, rotation_around_Y, 0));

        rotation_around_X = -Input.GetAxis("Mouse Y");// vertical mouse motion
        camera.transform.Rotate(new Vector3(rotation_around_X, 0, 0));

        dz = Input.GetAxis("Vertical");// can be -1 , 0 , 1
        dx = Input.GetAxis("Horizontal");// can be -1 , 0 , 1

        if (canMove == true)
        {
            Vector3 motion = new Vector3(dx * speed * Time.deltaTime, -0.1f,
                                    dz * speed * Time.deltaTime);
            motion = transform.TransformDirection(motion); // transformation from local to global coordinates
            controller.Move(motion); // motion is vector in global coordinates

            Debug.Log(transform.position);
            if (Mathf.Abs(dx) > 0.01 || Mathf.Abs(dz) > 0.01)
                if (!steps.isPlaying)
                    steps.Play();
        }
    }
                    
    public void SetPlayerMovement(bool canMovePlayer)
    {
        canMove = canMovePlayer;
    }
    
}
