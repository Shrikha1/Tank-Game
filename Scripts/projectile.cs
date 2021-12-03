using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class projectile : MonoBehaviour
{
    public Rigidbody2D bomb;
    public GameObject t1,t2,exp,turret1,turret2;
    int state = 1;
    Rigidbody2D b = null;
    GameObject e1,e2;
    float tm1,tm2;

    bool gameOver = false;

    public int tank1_maxHealth = 10;
    public int tank1_currentHealth;
    public int tank2_maxHealth = 10;
    public int tank2_currentHealth;

    public healthBar tank1_hb, tank2_hb;

    public TextMeshProUGUI tank1_score;
    public TextMeshProUGUI tank2_score;
    public TextMeshProUGUI  highscore;
    public int score1= 0;
    public int score2= 0;
    public int highScore= 0;

    //public nextlevel completeLevel;

 
    // Start is called before the first frame update
    void Start()
    {
        t1 = GameObject.Find("t1");
        t2 = GameObject.Find("t2");
        t1 = GameObject.Find("turret1");
        t2 = GameObject.Find("turret2");
        exp = GameObject.Find("explosion");
        tm1 = 0f;
        tm2 = 0f;

        tank1_hb = GameObject.Find("tank1_healthBar").GetComponent<healthBar>();
        tank1_currentHealth = tank1_maxHealth;
        tank1_hb.SetMaxHealth(tank1_maxHealth);

        tank2_hb = GameObject.Find("tank2_healthBar").GetComponent<healthBar>();
        tank2_currentHealth = tank2_maxHealth;
        tank2_hb.SetMaxHealth(tank2_maxHealth);

        highscore = GameObject.Find("highScore").GetComponent<TextMeshProUGUI>();
        tank1_score = GameObject.Find("score_tank1").GetComponent<TextMeshProUGUI >();
        tank1_score.text = "SCORE: "+score1.ToString();

        tank2_score = GameObject.Find("score_tank2").GetComponent<TextMeshProUGUI >();
        tank2_score.text = "SCORE: "+score2.ToString();

        highScore = PlayerPrefs.GetInt("highScore", 0);
        highscore.text = "HIGH SCORE: "+highScore.ToString();

        //completeLevel = GameObject.Find("Panel").GetComponent<>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            // Rigidbody2D bb = null;

            if(state%4==1){
                b = Instantiate(bomb, t1.transform.position, t1.transform.rotation);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 turretPos = turret1.transform.position;
                Vector2 v =  new Vector2(mousePos.x,mousePos.y) - new Vector2(turretPos.x,turretPos.y);
                v = v/(v.magnitude*1.0f);
                b.velocity = new Vector2(30f*v.x, 30f*v.y);
                b.transform.localScale = new Vector3(1f,1f,0);
            }
            if(state%4==2){
                e1 = Instantiate(exp, b.transform.position, b.transform.rotation);
                Vector3 dist2 = t2.transform.position - b.transform.position;
                //Debug.Log(dist1.sqrMagnitude);

                // score : distance and time inversely propositional
                if(dist2.sqrMagnitude<=20.0f){
                    score1 += 20;
                }else if(dist2.sqrMagnitude>=20.0f && dist2.sqrMagnitude<=40.0f){
                    score1 += 15;
                }else if(dist2.sqrMagnitude<=40.0f && dist2.sqrMagnitude<=60.0f){
                    score1 += 10;
                }
                tank1_score.text = "SCORE: "+score1.ToString();

                // reduce health of the opponent
                if(dist2.sqrMagnitude<=60.0f){
                    tank2_currentHealth -= 2; 
                    tank2_hb.SetHealth(tank2_currentHealth);
                    if(tank2_currentHealth<0 && gameOver == false)
                    {
                        gameOver = true;
                        Debug.Log("Player 1 Won!!");
                        if(highScore <score1)
                            PlayerPrefs.SetInt("highScore", score1);
                        Restart();
                        /*
                        if(highScore < score1)
                            completeLevel.textUpdate_winner("Congratulation, Player 1 Won!!", "Winner Score: "+score1.ToString(), "HIGH SCORE: "+score1.ToString());
                        else
                            completeLevel.textUpdate_winner("Congratulation, Player 1 Won!!", "Winner Score: "+score1.ToString(), "HIGH SCORE: "+highScore.ToString());
                        */
                        
                        //DestroyImmediate(t2.gameObject);
                    }
                }
                
                DestroyImmediate(b.gameObject);
                tm1 = Time.time;

                //Debug.Log(score1);

                //Debug.Log("start");
                // Debug.Log(t);
            }
            else if(state%4==3){
                b = Instantiate(bomb, t2.transform.position, t2.transform.rotation);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 turretPos = turret2.transform.position;
                Vector2 v =  new Vector2(mousePos.x,mousePos.y) - new Vector2(turretPos.x,turretPos.y);
                v = v/(v.magnitude*1.0f);
                b.velocity = new Vector2(30f*v.x, 30f*v.y);
                b.transform.localScale = new Vector3(1f,1f,0);
            }
            if(state%4==0){
                e2 = Instantiate(exp, b.transform.position, b.transform.rotation);
                Vector3 dist1 = t1.transform.position - b.transform.position;
                //Debug.Log(dist1.sqrMagnitude);

                if(dist1.sqrMagnitude<=20.0f){
                    score2 += 20;
                }else if(dist1.sqrMagnitude>=20.0f && dist1.sqrMagnitude<=40.0f){
                    score2 += 15;
                }else if(dist1.sqrMagnitude<=40.0f && dist1.sqrMagnitude<=60.0f){
                    score2 += 10;
                }
                tank2_score.text = "SCORE: "+score2.ToString();

                if(dist1.sqrMagnitude<=60.0f){
                    tank1_currentHealth -= 2; 
                    tank1_hb.SetHealth(tank1_currentHealth);
                    if(tank2_currentHealth<0 && gameOver == false)
                    {
                    
                        gameOver = true;
                        Debug.Log("Player 2 Won!!");
                        if(highScore <score1)
                            PlayerPrefs.SetInt("highScore", score2);
                        Restart();
                        /*
                        if(highScore < score2)
                            completeLevel.textUpdate_winner("Congratulation, Player 1 Won!!", "Winner Score: "+score2.ToString(), "HIGH SCORE: "+score2.ToString());
                        else
                            completeLevel.textUpdate_winner("Congratulation, Player 1 Won!!", "Winner Score: "+score2.ToString(), "HIGH SCORE: "+highScore.ToString());
                        */
                        //DestroyImmediate(t2.gameObject);
                    }

                }
                
                DestroyImmediate(b.gameObject);
                tm2 = Time.time;
            }

            state +=1;
        }

        if(tm1!=0f){
            // Debug.Log(Time.time);
            if(Time.time-tm1>3.8f){
                // Debug.Log("stop");
                tm1 = 0;
                DestroyImmediate(e1);
            }
        }
        if(tm2!=0f){
            // Debug.Log(Time.time);
            if(Time.time-tm2>3.8f){
                // Debug.Log("stop");
                tm2 = 0;
                DestroyImmediate(e2);
            }
        }
    }

    /*
    public void levelComplete ()
    {
        completeLevel.SetActive(true);
    }
    */
    
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}



