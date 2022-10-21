using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;

public class CreatePiece : MonoBehaviour {
    [SerializeField] private TMP_InputField _nameInput, _typeInput;
    [SerializeField] private TMP_InputField[] _statInputs;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private CheckButton _checkButtonPrefab;
    private List<TMP_InputField> _allInputs = new List<TMP_InputField>();
    private int[] _pieceStats = new int[3] { 0, 0, 0 };

    public void Start() {
        _allInputs = _statInputs.ToList();
        _allInputs.AddRange(new List<TMP_InputField> { _nameInput, _typeInput });

        // ! Broken and unused for now. Do not uncomment !
        // foreach (Piece piece in LegacySaveSystem.players.pieces) {
        //     if (piece.name != "enemies") return;
        //     foreach (Character character in piece.characters) {
        //         var _currentCharacter = Instantiate(_checkButtonPrefab, Vector3.zero, Quaternion.identity, _selectPanel);
        //         _currentCharacter.name = character.name;
        //     }
        // }
    }

    public void InvokeCreatePiece() {
        bool flag = false;
        foreach (TMP_InputField txtInput in _allInputs)
            flag = txtInput.text == "";
        if (flag) {
            ResetAndHide();
            return;
        }

        for (int i = 0; i < _pieceStats.Length; i++)
            _pieceStats[i] = UtilsClass.Parse_Int(_statInputs[i].text, 0);

        // Create new piece & character
        Stats newStats = new Stats(_pieceStats[0], _pieceStats[1], _pieceStats[2]);
        Character newChar = new Character($"{_playerManager._pieceCount + 1}", _nameInput.text, newStats);
        _playerManager.InitializePieceCard(newChar, _typeInput.text);

        ResetAndHide();
    }

    public void ResetAndHide() {
        foreach (TMP_InputField txtInput in _allInputs) {
            txtInput.text = "";
        }
        gameObject.SetActive(false);
    }
}
