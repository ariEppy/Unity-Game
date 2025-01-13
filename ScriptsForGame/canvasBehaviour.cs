using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvasBehaviour : MonoBehaviour
{
    //public static canvasBehaviour instance;
    Text gold_text;
    Text bomb_text;
    Text life_text;
    // we want the canvas to be persistent in both scenes
    void Start()
    {
        gold_text = GameObject.Find("coinsNum").GetComponent<Text>();
        bomb_text = GameObject.Find("bombsNum").GetComponent<Text>();
        life_text = GameObject.Find("lifeNum").GetComponent<Text>();
        gold_text.text = "Gold: " + (PlayerPrefs.GetInt("SetCoinAmount", 0));
        bomb_text.text = "Bombs: " + (PlayerPrefs.GetInt("SetBombAmount", 0));
        life_text.text = "Lives: " + (PlayerPrefs.GetInt("SetLifeAmount", 0));
        //if (instance != null)
        //{
        //    Destroy(this.gameObject);
        //    return;
        //}

        //instance = this;
        //GameObject.DontDestroyOnLoad(transform.root.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
