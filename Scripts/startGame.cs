using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void begin()
    {
        //Debug.Log("See you again soon, GAME OVER");
        //Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
