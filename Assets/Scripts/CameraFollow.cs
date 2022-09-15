using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Camera myCamera;
    private Func<Vector3> GetCameraFollowPositionFunc;
    private Func<float> GetCameraZoomFunc;
    [SerializeField]
    private float cameraZoomSpeed = 1f, cameraMoveSpeed = 1f;

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc) {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }
    private void Start() {
        myCamera = transform.GetComponent<Camera>();
    }
    public void SetCameraFollowPosition(Vector3 cameraFollowPosition) {
        SetGetCameraFollowPositionFunc(() => cameraFollowPosition);
    }
    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc) {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }
    public void SetCameraZoom(float cameraZoom) {
        SetGetCameraZoomFunc(() => cameraZoom);
    }
    public void SetGetCameraZoomFunc(Func<float> GetCameraZoomFunc) {
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }
    public void Update() {
        HandleMovement();
        HandleZoom();
    }
    private void HandleMovement() {
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);

        if (distance > 0) {
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if (distanceAfterMoving > distance) {
                newCameraPosition = cameraFollowPosition;
            }

            transform.position = newCameraPosition;
        }
    }

    private void HandleZoom() {
        float cameraZoom = GetCameraZoomFunc();
        float cameraZoomDifference = cameraZoom - myCamera.orthographicSize;

        myCamera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;

        if ((cameraZoomDifference > 0 && myCamera.orthographicSize > cameraZoom) || (cameraZoomDifference < 0 && myCamera.orthographicSize < cameraZoom))
            myCamera.orthographicSize = cameraZoom;

    }
}
