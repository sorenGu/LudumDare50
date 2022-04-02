using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {
    List<Transform> pathObjects = new List<Transform>();

    public List<GameObject> pathSegments;
    public List<GameObject> trees;
    float pathLength = 10f;

    GameController gameController;

    private void OnEnable() {
        gameController = GetComponent<GameController>();
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
    private void AddSegment(Vector3 postion) {
        GameObject _path = Instantiate(pathSegments[UnityEngine.Random.Range(0, pathSegments.Count)], postion, Quaternion.identity);
        pathObjects.Add(_path.transform);
        AddObjects(_path.transform);
    }

    private void AddObjects(Transform parent) {
        // _object = 
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
