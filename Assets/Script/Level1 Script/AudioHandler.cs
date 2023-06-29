using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private Player player;
    private Invaders invader;
    private RandomInvader randomInvader;


    [Header("Audio Settings")]
    private AudioSource m_AudioSource;
    [SerializeField] AudioClip[] m_clip;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
        invader = FindObjectOfType<Invaders>();
        randomInvader = FindObjectOfType<RandomInvader>();
    }

    private void Start()
    {
        player.shootingSound += PlayerShootingSound;
        invader.killed += InvaderKilledSound;
        randomInvader.killed += RandomInvaderKilledSound;
    }

    private void PlayerShootingSound()
    {
        m_AudioSource.PlayOneShot(m_clip[0]);
    }

    private void InvaderKilledSound(Invader invader)
    {
        m_AudioSource.PlayOneShot(m_clip[1]);
    }

    private void RandomInvaderKilledSound()
    {
        m_AudioSource.PlayOneShot(m_clip[1]);
    }
}
