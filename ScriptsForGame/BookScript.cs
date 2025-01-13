//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class BookScript : MonoBehaviour
//{
//    public GameObject player;
//    public GameObject book_in_hand;
//    public GameObject book_in_boat;
//    public Text take_text;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject == player)
//        {
//            if (CookBehavior.itemCount == 0)
//            {
//                take_text.gameObject.SetActive(true);
//                if (Input.GetKey(KeyCode.Space))
//                {
//                    book_in_boat.SetActive(false);
//                    book_in_hand.SetActive(true);
//                }
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject == player)
//        {
//            take_text.gameObject.SetActive(false);
//        }
//    }
//}
