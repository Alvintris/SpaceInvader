using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private Player player;
    private Invaders invader;


    [Header("Audio Settings")]
    private AudioSource m_AudioSource;
    [SerializeField] AudioClip[] m_clip;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
        invader = FindObjectOfType<Invaders>();
    }

    private void Start()
    {
        player.shootingSound += PlayerShootingSound;
        invader.killed += InvaderKilledSound;
    }

    private void PlayerShootingSound()
    {
        m_AudioSource.PlayOneShot(m_clip[0]);
    }

    private void InvaderKilledSound(Invader invader)
    {
        m_AudioSource.PlayOneShot(m_clip[1]);
    }
}
