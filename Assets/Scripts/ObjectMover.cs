using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {
    List<Transform> pathObjects = new List<Transform>();

    public List<GameObject> pathSegments;
    public List<GameObject> trees;
    float pathLength = 10f;
    float objectMaxXOffset = 22f;

    GameController gameController;

    private void OnEnable() {
        gameController = GetComponent<GameController>();
        gameController.OnGameOver += OnGameOver;
    }

    private void OnGameOver() {
        Destroy(this);
    }

    void Start() {
        Init();
    }

    void Update() {
        Move();
    }

    private void Init() {
        /* ToDo: 
        Erster Tile soll etwas schoener / anders sein
        */
        for (int i = 0; i <= 6; i++) {
            Vector3 postion = new Vector3(0, 0, -pathLength + (pathLength * i));
            AddSegment(postion);
        }
    }
    private void AddSegment(Vector3 position) {
        GameObject _path = Instantiate(pathSegments[UnityEngine.Random.Range(0, pathSegments.Count)], position, Quaternion.identity);
        pathObjects.Add(_path.transform);
        AddObjects(_path.transform);
    }

    private void AddObjects(Transform parent) {
        int max = 3;
        for (int i = 0; i <= max; i++) {
            float offset_x = UnityEngine.Random.Range(2, objectMaxXOffset + 2);
            Vector3 offset = new Vector3(
                offset_x * RandomSign(), 0, 
                UnityEngine.Random.Range(-pathLength, 0)
                );
            Instantiate(trees[UnityEngine.Random.Range(0, trees.Count)], parent.position + offset, Quaternion.identity, parent);
        }
    }

    private float RandomSign() {
        return UnityEngine.Random.Range(0,2)*2-1;
    }

    private void Move() {
        bool wasDestroyed = false;
        for (var i = pathObjects.Count - 1; i > -1; i--) {
            if (moveObject(pathObjects[i])) {
                wasDestroyed = true;
                pathObjects.RemoveAt(i);
            }
        }
        if (wasDestroyed) {
            AddSegment(pathObjects[pathObjects.Count - 1].position + new Vector3(0, 0, pathLength));
            gameController.AddScore();
        }
    }

    private bool moveObject(Transform element) {
        element.Translate(gameController.downDirection * gameController.gameSpeed * Time.deltaTime);
        if (element.position.z <= -12f) {
            Destroy(element.gameObject);
            return true;
        }
        return false;
    }
}
