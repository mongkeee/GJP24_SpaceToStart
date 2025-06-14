using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip sfxBall;
    [SerializeField] private AudioClip sfxEnemyExplode;
    [SerializeField] private AudioClip sfxLaserGun;
    [SerializeField] private AudioClip sfxLose;
    [SerializeField] private AudioClip sfxWin;
    [SerializeField] private AudioClip sfxPickup;
    [SerializeField] private AudioClip sfxPlayerLaser;
    [SerializeField] private AudioClip sfxUI;

    [SerializeField] private AudioSource auS;
    // Start is called before the first frame update
    void Start()
    {
        auS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBall(){
        auS.PlayOneShot(sfxBall);
    }

    public void PlayExplode(){
        auS.PlayOneShot(sfxEnemyExplode);
    }

    public void PlayLaserEnemy(){
        auS.PlayOneShot(sfxLaserGun);
    }

    public void PlayLose(){
        auS.PlayOneShot(sfxLose);
    }

    public void PlayPickup(){
        auS.PlayOneShot(sfxPickup);
    }

    public void PlayUI(){
        auS.PlayOneShot(sfxUI);
    }

    public void PlayPlayerLaser(){
        auS.PlayOneShot(sfxPlayerLaser);
    }

    public void PlayWin(){
        auS.PlayOneShot(sfxWin);
    }
}
