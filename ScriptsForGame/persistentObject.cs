using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class PersistentObject : MonoBehaviour
{
    
   // public static PersistentObject instance;
   // CoinBehavior coin;
    //BombBehavior bomb;
    
    //static List<string> pickedUpCoins = new List<string>();
    //static List<string> pickedUpBombs = new List<string>();
    //static List<string> deadEnemies = new List<string>();
    //public static int acceptedFatherChallenge;
    //public static int lives;
    //public static int talkedToBarOwner;
    //public static int talkedToBarMaid1;
    //public static int talkedToBarMaid2;
    //public string enemyName;
    //public string bombName;
    //public string coinName;

    //public static GameObject enemy;
    //empty all persistentobjects
    public static void emptyVariables()
    {
        Debug.Log("in emptying");
        for (int i = 1; i <= 12; i++)
        {
            string coinName = "coin" + i;
            PlayerPrefs.SetInt(coinName, 0);
            PlayerPrefs.Save();
        }
        for (int i = 1; i <= 23; i++)
        {
            string bombName = "bomb" + i;
            PlayerPrefs.SetInt(bombName, 0);
            PlayerPrefs.Save();
        }
        for (int i = 0; i <20; i++)
        {
            string enemyName = "enemy" + i;
            PlayerPrefs.SetInt(enemyName, 0);
            PlayerPrefs.Save();
            Debug.Log(enemyName);
            Debug.Log(PlayerPrefs.GetInt(enemyName, 0));
        }
        PlayerPrefs.SetInt("acceptedFatherChallenge", 0);
        PlayerPrefs.Save();
        //PlayerPrefs.SetInt("lives", 10);
       // PlayerPrefs.Save();
        PlayerPrefs.SetInt("talkedToBarOwner", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("talkedToBarMaid1", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("talkedToBarMaid2", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("SetCoinAmount", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("SetBombAmount", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("SetLifeAmount", 10);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("prevScene", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("keyFromChest", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("quest3", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow5", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("quest4", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow6", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("currentCookTask", -2);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("cookFinish", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("nearCook", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("cookChallenge", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("hasIngredient", -1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("fatherEnd", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("cookEnd", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("struck", -1);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("waiting", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("quest6", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("questglow9", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("princess", 0);
        PlayerPrefs.Save();
    }
    
  
}
