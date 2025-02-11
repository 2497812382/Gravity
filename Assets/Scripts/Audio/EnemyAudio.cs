using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audioPlayer;
    [SerializeField] private AudioClip shootAudio;
    [SerializeField] private AudioClip death;




    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void playeShooting()
    {
        audioPlayer.loop = false;
        audioPlayer.clip = shootAudio;
        audioPlayer.Play();
    }

    public void playeDeath()
    {
        audioPlayer.loop = false;
        audioPlayer.clip = death;
        audioPlayer.Play();
    }
}
