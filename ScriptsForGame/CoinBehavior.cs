using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinBehavior : MonoBehaviour
{
    public static int num_coins = 0;
    Text gold_text;
    public GameObject coins;
    int isPickedUp;
    string coinIdentifier;

    //checks to make sure if we already picked up this coin in a previous scene, if so then dont show in the scene
    void Awake()
    {
        gold_text = GameObject.Find("coinsNum").GetComponent<Text>();

        coinIdentifier = gameObject.name;
       
        isPickedUp = PlayerPrefs.GetInt(coinIdentifier, 0);

        if (isPickedUp == 1)
        {
           
            gameObject.SetActive(false);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        
            num_coins++;
            SetCoinAmount(num_coins);
            gameObject.SetActive(false);
            AudioSource sound = coins.GetComponent<AudioSource>();
            sound.Play();
            isPickedUp = 1;
            //PersistentObject.CoinPickedUp(coinIdentifier);
             PlayerPrefs.SetInt(coinIdentifier, 1);
              PlayerPrefs.Save();

    }
    public void SetCoinAmount(int amount)
    {
        num_coins = amount;
        gold_text.text = "Gold: " + num_coins;
        PlayerPrefs.SetInt("SetCoinAmount", amount);
        PlayerPrefs.Save();
    }
}
