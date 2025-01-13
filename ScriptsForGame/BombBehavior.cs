using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombBehavior : MonoBehaviour
{
    public static int num_bombs = 0;
    Text bomb_text;
    public GameObject bombs;
    int bombPickedUp;
    string bombIdentifier;

    //checks to make sure if we already picked up this bomb in a previous scene, if so then dont show in the scene
    void Start()
    {
        bomb_text = GameObject.Find("bombsNum").GetComponent<Text>();

        bombIdentifier = gameObject.name;

        bombPickedUp = PlayerPrefs.GetInt(bombIdentifier, 0);
        

        if (bombPickedUp == 1)
        {

            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
           
            num_bombs++;
            SetBombAmount(num_bombs);
            gameObject.SetActive(false);
            AudioSource sound = bombs.GetComponent<AudioSource>();
            sound.Play();
            bombPickedUp = 1;
            PlayerPrefs.SetInt(bombIdentifier, 1);
            PlayerPrefs.Save();
      

    }
    public void SetBombAmount(int amount)
    {
        num_bombs = amount;
        bomb_text.text = "Bombs: " + num_bombs;
        PlayerPrefs.SetInt("SetBombAmount", amount);
        PlayerPrefs.Save();
    }
   
}
