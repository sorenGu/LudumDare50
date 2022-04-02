using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float gameSpeed { get; private set; } = 5f;
    public Vector3 downDirection { get; private set; } = new Vector3(0, 0, -1);
}
