using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float rotationSpeed = 7f;
    GameController gameController;
    Rigidbody m_Rigidbody;
    Animator animator;
    float BoundX = 18f;
    float MinBoundZ = -5f;
    float MaxBoundZ = 25f;

    private void OnEnable() {
        gameController = transform.parent.GetComponent<GameController>();
        gameController.OnGameOver += OnGameOver;
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnGameOver() {
        Destroy(this);
    }

    void FixedUpdate() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();

        if (direction != Vector3.zero) {
            animator.SetBool("Running", true);
            MoveInBounds(direction * 2);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotationSpeed
            );
        } else {
            animator.SetBool("Running", false);
            MoveInBounds(gameController.downDirection);
        }

    }


    void MoveInBounds(Vector3 direction){
        direction = direction * Time.deltaTime *  gameController.gameSpeed;
        float _BoundX = BoundX + transform.position.z * 0.5f;
        direction = new Vector3(
            Mathf.Clamp(transform.position.x + direction.x, -_BoundX, _BoundX),
            0f,
            Mathf.Clamp(transform.position.z + direction.z, MinBoundZ, MaxBoundZ)
        );

        m_Rigidbody.MovePosition(direction);
    }
}
