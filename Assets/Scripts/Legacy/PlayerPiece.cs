using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPiece : MonoBehaviour {
    [SerializeField] private Vector3 offset;
    [SerializeField] private TextMeshProUGUI _number;
    public Camera cam;
    public bool followsMouse = false;

    public void Update() {
        if (followsMouse && cam != null) MoveObject();
        transform.GetComponent<Image>().color = LegacySaveSystem.ColorBank[int.Parse(_number.text) - 1];
    }

    public void MoveObject() {
        Vector3 pos = Input.mousePosition + offset;
        transform.position = cam.ScreenToWorldPoint(pos);
    }

}
