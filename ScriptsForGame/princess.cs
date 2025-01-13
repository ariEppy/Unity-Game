using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princess : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("princess", 0) == 1)
        {
            animator.SetInteger("state", 1);
        }
    }
}
