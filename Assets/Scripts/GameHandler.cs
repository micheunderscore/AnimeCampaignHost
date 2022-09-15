using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {
    [SerializeField]
    private CameraFollow cameraFollow;
    public Transform zoomCursor;
    private bool edgeScrolling = false;
    [SerializeField]
    private float zoom = 40f, zoomAmount = 10f, moveAmount = 10f, minZoom = 40f, maxZoom = 200f, edgeSize = 10f;
    private void Start() {
        cameraFollow.Setup(() => zoomCursor.position, () => zoom);
        // CMDebug.ButtonUI(new Vector2(-100, 10), "Player", () => {
        //     cameraFollow.SetGetCameraFollowPositionFunc(() => zoomCursor.position);
        // });
    }

    private void Update() {
        // Movement
        zoomCursor.position = HandleManualMovement(zoomCursor.position);
        // Zooming
        ZoomWithPosition(Input.mouseScrollDelta.y, UtilsClass.GetMouseWorldPosition());
        if (Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Equals)) Zoom(+1f, .25f);
        if (Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus)) Zoom(-1f, .25f);
        // Configs
        // Edge Scrolling Toggle
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                edgeScrolling = !edgeScrolling;
                CMDebug.TextPopupMouse("Edge Scrolling " + (edgeScrolling ? "En" : "Dis") + "abled");
            }
        }
    }

    private Vector3 HandleManualMovement(Vector3 newZoomCursorPos) {
        // Moving with Keys
        if (Input.GetKey(KeyCode.W) || (Input.mousePosition.y > Screen.height - edgeSize && edgeScrolling))
            newZoomCursorPos.y += moveAmount * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) || (Input.mousePosition.y < edgeSize && edgeScrolling))
            newZoomCursorPos.y -= moveAmount * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) || (Input.mousePosition.x > Screen.width - edgeSize && edgeScrolling))
            newZoomCursorPos.x += moveAmount * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || (Input.mousePosition.x < edgeSize && edgeScrolling))
            newZoomCursorPos.x -= moveAmount * Time.deltaTime;

        return newZoomCursorPos;
    }

    private void Zoom(float zoomChange, float zoomMultiplier = 1f) {
        if (zoomChange == 0) return;
        // Determine zoom direction
        float zoomDirection = zoomChange > 0 ? -1f : +1f;
        // Change zoom
        zoom += zoomAmount * zoomDirection * zoomMultiplier;
        // Keep zoom within min and max zoom limits
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
    }

    private void ZoomWithPosition(float zoomChange, Vector3 zoomPosition) {
        Zoom(zoomChange);
        float zoomDirection = zoomChange > 0 ? -1f : +1f;
        // Move zoom cursor to position
        if (zoomDirection < 0 && zoom != minZoom)
            zoomCursor.position = zoomPosition;
    }
}
