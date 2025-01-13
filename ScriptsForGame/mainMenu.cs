using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public static mainMenu instance;

    public void Start()
    {
        PersistentObject.emptyVariables();
    }

    public void Update()
    {
       
    }
    public void playGame()
    {
        PlayerPrefs.SetInt("prevScene", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);

    }
    public void quitGame()
    {

#if UNITY_STANDALONE
                Application.Quit();
#endif

        // In the Unity Editor, stop play mode
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
