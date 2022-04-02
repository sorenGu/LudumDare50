using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {
    List<Transform> randomObjects = new List<Transform>();
    List<Transform> pathObjects = new List<Transform>();

    public Transform playerTransform;

    public List<GameObject> pathSegments;
    public List<GameObject> trees;
    float pathLength = 10f;

    GameController gameController;

    private void OnEnable() {
        gameController = GetComponent<GameController>();
    }

    void Start() {
        InitPath();
        InitRandomObjects();
    }

    void Update() {
        MovePath();
        MoveRandomObjects();
    }

    private void InitPath() {
        /* ToDo: 
        Erster Tile soll etwas schoener / anders sein
        */
        for (int i = 0; i <= 6; i++) {
            Vector3 postion = new Vector3(0, 0, -pathLength + (pathLength * i));
            AddPathSegment(postion);
        }
    }
    private void AddPathSegment(Vector3 postion) {
        GameObject _path = Instantiate(pathSegments[UnityEngine.Random.Range(0, pathSegments.Count)], postion, Quaternion.identity);
        pathObjects.Add(_path.transform);
    }

    private void MovePath() {
        bool wasDestroyed = false;
        for (var i = pathObjects.Count - 1; i > -1; i--) {
            if (moveObject(pathObjects[i])) {
                wasDestroyed = true;
                pathObjects.RemoveAt(i);
            }
        }
        if (wasDestroyed) {
            AddPathSegment(pathObjects[pathObjects.Count - 1].position + new Vector3(0, 0, pathLength));
        }
    }

    private void InitRandomObjects() {
        for (int i = 0; i <= 6; i++) {
            AddRandomObjectSegment(-pathLength + (pathLength * i));
        }
    }

    private void AddRandomObjectSegment(float end_postion_z) {
        
    }

    private void MoveRandomObjects() {
        bool wasDestroyed = false;
        for (var i = pathObjects.Count - 1; i > -1; i--) {
            if (moveObject(pathObjects[i])) {
                wasDestroyed = true;
                pathObjects.RemoveAt(i);
            }
        }
        if (wasDestroyed) {
            AddPathSegment(pathObjects[pathObjects.Count - 1].position + new Vector3(0, 0, pathLength));
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
