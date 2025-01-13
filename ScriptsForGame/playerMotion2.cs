using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMotion2 : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 7;
    public GameObject camera;
    private AudioSource steps;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        steps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float dx, dz;
        float rotation_around_Y;
        float rotation_around_X;
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
