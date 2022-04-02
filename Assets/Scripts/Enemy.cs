using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    GameController gameController;
    public List<Transform> foods;

    Animator animator;

    float eatDistance = 2f;

    private void OnEnable() {
        gameController = transform.parent.GetComponent<GameController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {
        CheckDistance();
        transform.Translate(Vector3.forward * Time.deltaTime * (float)(gameController.gameSpeed * 0.05));
    }

    private void CheckDistance() {
        float distance = 9999999; 
        foreach (Transform food in foods) {
            distance = Math.Min((transform.position - food.position).sqrMagnitude, distance);
        }

        if (distance < eatDistance) {
            animator.SetTrigger("GameOver");
        } else if (distance < eatDistance * 4) {
            animator.SetBool("Close", true);
        } else {
            animator.SetBool("Close", false);
        }

    }
}
