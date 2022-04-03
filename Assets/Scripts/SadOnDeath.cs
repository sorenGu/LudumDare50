using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadOnDeath : MonoBehaviour
{
    public SadOnDeath friend;
    Animator animator;

    public Action DeathOcurred;

    AudioSource audioSource;

    public AudioClip dieSound;

    private void OnEnable() {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        friend.DeathOcurred += OnFriendDeathOcurred;
    }

    public void Die(){
        transform.LookAt(new Vector3(1,0,1));
        animator.SetTrigger("Death");
        DeathOcurred?.Invoke();
        audioSource.clip = dieSound;
        audioSource.Play();
    }

    private void OnFriendDeathOcurred() {
        animator.SetTrigger("Sad");
    }
}
