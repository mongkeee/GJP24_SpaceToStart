using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private AudioManager aud;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Animator canvasAnim;
    [SerializeField] private TextMeshProUGUI txtAmmo;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtHealth;
    public int score = 0;

    [SerializeField] private int uiState = 0;
    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("Music").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(uiState == 0){
            if(Input.GetButtonDown("Jump")){
                aud.PlayUI();
                uiState = 1;
            }
        } else if(uiState == 1){ //
            if(Input.GetKeyDown(KeyCode.Escape)){
                aud.PlayUI();
                uiState = 2;
                Time.timeScale = 0;
            }
        } else if(uiState == 2){ //
            if(Input.GetKeyDown(KeyCode.Escape)){
                aud.PlayUI();
                Application.Quit();
            }else if(Input.GetButtonDown("Jump")){
                aud.PlayUI();
                uiState = 1;
                Time.timeScale = 1;
            }
        } else if(uiState == 3){ //win
            Time.timeScale = 0;
            if(Input.GetButtonDown("Jump")){
                aud.PlayUI();
                Time.timeScale = 1;
                SceneManager.LoadScene("TheGame");
            }
        } else if(uiState == 4){ //lose
            Time.timeScale = 0;
            if(Input.GetButtonDown("Jump")){
                aud.PlayUI();
                Time.timeScale = 1;
                SceneManager.LoadScene("TheGame");
            }
        }
        canvasAnim.SetInteger("state", uiState);

        txtAmmo.text = "AMMO: " + player.ammo;
        txtScore.text = score + " :SCORE";
        txtHealth.text = "LIFE: " + player.health;
    }

    public void addScore(int value){
        score += value;
    }

    public void win(){
        uiState = 3;
    }

    public void lose(){
        uiState = 4;
    }
}
