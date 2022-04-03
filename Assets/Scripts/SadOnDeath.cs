using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadOnDeath : MonoBehaviour
{
    public SadOnDeath friend;
    Animator animator;

    public Action DeathOcurred;

    private void OnEnable() {
        animator = GetComponentInChildren<Animator>();
        friend.DeathOcurred += OnFriendDeathOcurred;
    }

    public void Die(){
        transform.LookAt(new Vector3(1,0,1));
        animator.SetTrigger("Death");
        DeathOcurred?.Invoke();
    }

    private void OnFriendDeathOcurred() {
        animator.SetTrigger("Sad");
    }
}
