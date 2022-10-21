using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class Tile : MonoBehaviour, IPointerMoveHandler {
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _holdingPiece;
    [SerializeField] private string _holding;

    // Checkerboard pattern init
    public void Init(bool isOffset) {
        _image.color = isOffset ? _offsetColor : _baseColor;
    }

    public void Start() {
        _holding = LegacySaveSystem.Empty;
        _button.onClick.AddListener(TaskOnClick);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            _holding = LegacySaveSystem.Empty;
        }

        _holdingPiece.SetActive(_holding != LegacySaveSystem.Empty);
        if (_holding != LegacySaveSystem.Empty) {
            _holdingPiece.GetComponentInChildren<TextMeshProUGUI>().text = _holding;
        }
    }

    public void ClearHolding() {
        _holding = LegacySaveSystem.Empty;
    }

    public void TaskOnClick() {
        if (_holding != LegacySaveSystem.Empty && LegacySaveSystem.Selected != LegacySaveSystem.Empty) {
            string _switch = _holding;
            _holding = LegacySaveSystem.Selected;
            LegacySaveSystem.Selected = _switch;
        } else if (_holding == LegacySaveSystem.Empty) {
            _holding = LegacySaveSystem.Selected;
            LegacySaveSystem.ClearSelected();
        } else {
            LegacySaveSystem.Selected = _holding;
            ClearHolding();
        }
    }

    public void OnPointerMove(PointerEventData eventData) {
        if (Input.GetMouseButton(1)) {
            _image.color = LegacySaveSystem.Color;
        }
    }
}
