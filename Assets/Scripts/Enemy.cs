using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    GameController gameController;
    public List<Transform> foods;

    Animator animator;

    float eatDistance = 2f;

    Action CurrentAction;

    private void OnEnable() {
        gameController = transform.parent.GetComponent<GameController>();
        animator = GetComponentInChildren<Animator>();
        CurrentAction = CheckDistance;
    }

    void Update() {
        CurrentAction();
    }

    public void CheckDistance() {
        transform.Translate(Vector3.forward * Time.deltaTime * (float)(gameController.gameSpeed * 0.05));
        float distance = 9999999; 
        foreach (Transform food in foods) {
            distance = Math.Min((transform.position - food.position).sqrMagnitude, distance);
        }

        if (distance < eatDistance) {
            animator.SetTrigger("GameOver");
            gameController.GameOver();
            CurrentAction = AfterGameAction;
        } else if (distance < eatDistance * 4) {
            animator.SetBool("Close", true);
            // TODO rotate to closest Food
        } else {
            animator.SetBool("Close", false);
            // TODO rotate face straight
        }

    }

    private void AfterGameAction() {
        // TODO rotate
    }
}
