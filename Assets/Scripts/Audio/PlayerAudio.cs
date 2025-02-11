using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip getKeyAudio;
    private AudioSource audioPlayer;



    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void playHurt()
    {
        audioPlayer.loop = false;
        audioPlayer.clip = hurt;
        audioPlayer.Play();
    }

    public void playGameOver()
    {
        audioPlayer.loop = false;
        audioPlayer.clip = gameOver;
        audioPlayer.Play();
    }

    public void playKeyAudio()
    {
        audioPlayer.loop = false;
        audioPlayer.clip = getKeyAudio;
        audioPlayer.Play();
    }
   
}
