using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class Tile : MonoBehaviour, IPointerEnterHandler {
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _holdingPiece;
    [SerializeField] private string _holding;

    public void Init(bool isOffset) {
        _image.color = isOffset ? _offsetColor : _baseColor;
    }

    public void Start() {
        _holding = LegacySaveSystem.Clear;
        _button.onClick.AddListener(TaskOnClick);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            _holding = LegacySaveSystem.Clear;
        }

        _holdingPiece.SetActive(_holding != LegacySaveSystem.Clear);
        if (_holding != LegacySaveSystem.Clear) {
            _holdingPiece.GetComponentInChildren<TextMeshProUGUI>().text = _holding;
        }
    }

    public void ClearHolding() {
        _holding = LegacySaveSystem.Clear;
    }

    public void TaskOnClick() {
        if (_holding != LegacySaveSystem.Clear && LegacySaveSystem.Selected != LegacySaveSystem.Clear) {
            string _switch = _holding;
            _holding = LegacySaveSystem.Selected;
            LegacySaveSystem.Selected = _switch;
        } else if (_holding == LegacySaveSystem.Clear) {
            _holding = LegacySaveSystem.Selected;
            LegacySaveSystem.ClearSelected();
        } else {
            LegacySaveSystem.Selected = _holding;
            ClearHolding();
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (LegacySaveSystem.Color != LegacySaveSystem.Clear && Input.GetMouseButton(1)) {
            if (ColorUtility.TryParseHtmlString(LegacySaveSystem.Color, out Color color)) { _image.color = color; }
        }
    }
}
