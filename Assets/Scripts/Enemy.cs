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

    float currentMoveBackTimer;

    private void OnEnable() {
        gameController = transform.parent.GetComponent<GameController>();
        animator = GetComponentInChildren<Animator>();
        CurrentAction = CheckDistance;
        foreach (Transform food in foods) {
            ItemReceiver itemReceiver;
            if (food.TryGetComponent<ItemReceiver>(out itemReceiver)) {
                itemReceiver.OnReceiveItem += OnFoodReceiveItem;
            }
        }
    }
    void Update() {
        CurrentAction();
    }

    private void OnFoodReceiveItem() {
        animator.SetTrigger("Scare");
        currentMoveBackTimer = 15 / gameController.gameSpeed;
        CurrentAction = MoveBack;
    }

    private void MoveBack() {
        currentMoveBackTimer -= Time.deltaTime;
        if (currentMoveBackTimer < 0) {
            CurrentAction = CheckDistance;
            animator.SetTrigger("Scare");
        } else {
            if (transform.position.z > -5) {
                transform.Translate(Vector3.back * Time.deltaTime * (float)(gameController.gameSpeed * 0.2), Space.World);
            }
        }
    }

    public void CheckDistance() {
        transform.Translate(Vector3.forward * Time.deltaTime * (float)(gameController.gameSpeed * 0.07), Space.World);
        float distance = 9999999;
        Transform closestFood = transform;
        foreach (Transform food in foods) {
            float tmpDistance = (transform.position - food.position).sqrMagnitude;
            if (tmpDistance < distance) {
                distance = tmpDistance;
                closestFood = food;
            }        
        }

        if (distance < eatDistance) {
            animator.SetTrigger("GameOver");
            gameController.GameOver();
            closestFood.GetComponent<SadOnDeath>().Die();
            CurrentAction = AfterGameAction;
        } else if (distance < eatDistance * 4) {
            animator.SetBool("Close", true);
        } else {
            animator.SetBool("Close", false);
        }
        transform.LookAt(closestFood.position);
    }

    private void AfterGameAction() {
        transform.Rotate(0f, 0.05f, 0.0f, Space.Self);
    }
}
