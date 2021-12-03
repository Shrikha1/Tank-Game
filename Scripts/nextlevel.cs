using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    public TextMeshProUGUI whoWon;
    public TextMeshProUGUI winnerDisplay;
    public TextMeshProUGUI highscoreDisplay;

    public void changelevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Debug.Log("See you again soon, GAME OVER");
        //Application.Quit();
    }

    public void quit()
    {
        //Debug.Log("See you again soon, GAME OVER");
        //Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    
    public void textUpdate_winner(string text1, string text2, string text3)
    {
        whoWon.text = text1;
        winnerDisplay.text = text2;
        highscoreDisplay.text = text3;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        whoWon = GameObject.Find("whoWon").GetComponent<TextMeshProUGUI>();
        winnerDisplay = GameObject.Find("winnerScore").GetComponent<TextMeshProUGUI>();
        highscoreDisplay = GameObject.Find("display_hs").GetComponent<TextMeshProUGUI>();
    }
    

    /* Update is called once per frame
    void Update()
    {
        textUpdate_winner();
    }
    */
    
}
