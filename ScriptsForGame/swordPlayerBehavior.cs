using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordPlayerBehavior : MonoBehaviour
{
    private Animator animator;
    public int enemyLife = 2;
    public bool playerSwordTouched = false;
  
    public bool struck = false;
    public bool enemyHurt = false;
    public bool enemyDead = false;
    string enemyName;
    int i;
  
    int k;
    //public GameObject enemy1;
    //public GameObject enemy2;



    void Awake()
    {

        //enemy = PersistentObject.enemy;
    }
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

        

    }
     
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.H) )
        {
            
            PlayerPrefs.SetInt("struck", i);
            PlayerPrefs.Save();
            StartCoroutine(strike());
            
        }
        
            //checks that player pressed the h button and that his sword actually touched the enemy
            if (PlayerPrefs.GetInt(enemyName,0) == 1 && PlayerPrefs.GetInt("struck", 0) == int.Parse(enemyName.Substring(5)))  
            {
                playerSwordTouched = false;
                struck = false;
                //lower life
                 enemyLife--;
            if (enemyLife == 0)

            {
                PlayerPrefs.SetInt("waiting", 1);
                PlayerPrefs.Save();
            }   
                PlayerPrefs.SetInt(enemyName, 2);
                PlayerPrefs.Save();
                Debug.Log(enemyName + " " + PlayerPrefs.GetInt(enemyName, 0));
            
            

        }
            if (enemyLife <= 0 && PlayerPrefs.GetInt(enemyName, 0) == 2 && 
            PlayerPrefs.GetInt("struck", 0) == int.Parse(enemyName.Substring(5)) && PlayerPrefs.GetInt("waiting", 0) == 1)
        { 
                //enemyDead = true;
            PlayerPrefs.SetInt(enemyName, 3);
            PlayerPrefs.Save();

        }
        }

    
     void OnTriggerExit(Collider other)
    {

        playerSwordTouched = false;
       

    }
     void OnTriggerEnter(Collider other)
    {

        // Checks if the collider belongs to the enemy
        if (other.name == "enemy0" || other.name == "enemy1" || other.name == "enemy2" || other.name == "enemy3" ||
            other.name == "enemy4" || other.name == "enemy5" || other.name == "enemy6" || other.name == "enemy7" ||
            other.name == "enemy8" || other.name == "enemy9" || other.name == "enemy10" || other.name == "enemy11" ||
            other.name == "enemy12" || other.name == "enemy13" || other.name == "enemy14" || other.name == "enemy15" ||
            other.name == "enemy16" || other.name == "enemy17" || other.name == "enemy18" || other.name == "enemy19" )
        {
            enemyName = other.name;
            i = int.Parse(enemyName[5].ToString());
            if (enemyName.Length == 7)
            {
                k = int.Parse(enemyName.Substring(5));
                
                i = k;
            }

            PlayerPrefs.SetInt(enemyName, 1);
            PlayerPrefs.Save();

        }
        

    }
    IEnumerator strike()
    {
       
        animator.SetInteger("strike", 1);
        yield return new WaitForSeconds(.5f);
        animator.SetInteger("strike", 2);
        yield return new WaitForSeconds(.5f);
        animator.SetInteger("strike", 3);
        yield return new WaitForSeconds(.5f);
        animator.SetInteger("strike", 4);
        yield return new WaitForSeconds(.5f);
        PlayerPrefs.SetInt("struck", -1);
        PlayerPrefs.Save();


    }
    public void setEnemyHurtFalse ()
    {
        enemyHurt = false;
    }
    
}
