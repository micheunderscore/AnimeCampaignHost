using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public void Start() {
        GenerateBg();
    }

    public void Update() {
        if (Input.GetKeyDown("g")) GenerateBg();
    }

    private void GenerateBg() {
        transform.GetComponent<Camera>().backgroundColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
    }
}