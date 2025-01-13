using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class swordBehavior : MonoBehaviour
{
    GameObject ourPlayer;
    //GameObject ourPlayerBody;
    //Transform bodyTransform;
    public bool swordTouched = false;
    public static int life = 10;
    Text life_text;

    CoinBehavior coins;
    BombBehavior bombs;
    swordPlayerBehavior playerPerspective;
    PlayerMotion playerMotion;
   


    // Start is called before the first frame update
    void Awake()
    {
        life_text = GameObject.Find("lifeNum").GetComponent<Text>();
        life = PlayerPrefs.GetInt("SetLifeAmount", 0);
        coins = FindObjectOfType<CoinBehavior>();
        bombs = FindObjectOfType<BombBehavior>();
        playerPerspective = FindObjectOfType<swordPlayerBehavior>();
        ourPlayer = GameObject.Find("mainPlayer");
        //ourPlayerBody = GameObject.Find("mainPlayer/Body");
        playerMotion = FindObjectOfType<PlayerMotion>();
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (swordTouched == true && playerPerspective.struck == false)
        {
            swordTouched = false;
            //Debug.Log("enemy has hit the player " + life);
            //lower life
            life--;
            SetLifeAmount(life);


        }
        if (life <= 0)
        {
            playerDies();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
            swordTouched = false;
            
         
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the collider belongs to the player
        if (other.gameObject == ourPlayer)
        {

            //Debug.Log("Players been hit!");
            swordTouched = true;

        }

    }
    void playerDies()
    {

        PersistentObject.emptyVariables();
        SceneManager.LoadScene(0);

    }
    public void SetLifeAmount(int amount)
    {
        life = amount;
        life_text.text = "Lives: " + life;
     
        PlayerPrefs.SetInt("SetLifeAmount", amount);
        PlayerPrefs.Save();
    }



}
