using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreatePiece : MonoBehaviour {
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Transform _selectPanel;
    [SerializeField] private CheckButton _checkButtonPrefab;

    public void Start() {
        foreach (Piece piece in SaveSystem.players.pieces) {
            if (piece.name != "enemies") return;
            foreach (Character character in piece.characters) {
                var _currentCharacter = Instantiate(_checkButtonPrefab, Vector3.zero, Quaternion.identity, _selectPanel);
                _currentCharacter.name = character.name;
            }
        }
    }

    public void SelectObject() {
        if (_inputField.text != "") SaveSystem.Selected = _inputField.text;
        gameObject.SetActive(false);
        _inputField.text = "";
    }
}
