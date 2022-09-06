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
        _holding = SaveSystem.Clear;
        _button.onClick.AddListener(TaskOnClick);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            _holding = SaveSystem.Clear;
        }

        _holdingPiece.SetActive(_holding != SaveSystem.Clear);
        if (_holding != SaveSystem.Clear) {
            _holdingPiece.GetComponentInChildren<TextMeshProUGUI>().text = _holding;
        }
    }

    public void ClearHolding() {
        _holding = SaveSystem.Clear;
    }

    public void TaskOnClick() {
        if (_holding != SaveSystem.Clear && SaveSystem.Selected != SaveSystem.Clear) {
            string _switch = _holding;
            _holding = SaveSystem.Selected;
            SaveSystem.Selected = _switch;
        } else if (_holding == SaveSystem.Clear) {
            _holding = SaveSystem.Selected;
            SaveSystem.ClearSelected();
        } else {
            SaveSystem.Selected = _holding;
            ClearHolding();
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (SaveSystem.Color != SaveSystem.Clear && Input.GetMouseButton(1)) {
            if (ColorUtility.TryParseHtmlString(SaveSystem.Color, out Color color)) { _image.color = color; }
        }
    }
}
