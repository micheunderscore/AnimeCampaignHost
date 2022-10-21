using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour {
    [SerializeField] private PlayerCard _playerCard;
    [SerializeField] private Color _playerColor, _npcColor, _enemyColor;
    public int _pieceCount = 0;
    private JsonReader jsonReader = new JsonReader();
    private GridLayoutGroup _playerCards;

    public void Start() {
        string jsonString = jsonReader.Read("players.json");
        LegacySaveSystem.players = JsonUtility.FromJson<GameData>(jsonString);

        LoadChars();
    }

    public void LoadChars() {
        GameData players = LegacySaveSystem.players;

        foreach (Piece piece in players.pieces) {
            for (int i = 0; i < piece.characters.Length; i++) {
                InitializePieceCard(piece.characters[i], piece.name);
            }
        }
    }

    public void RecountAllCards() {
        _pieceCount = transform.childCount;
    }

    public void InitializePieceCard(Character characterProfile, string pieceType) {
        var characterCard = Instantiate(_playerCard, Vector3.zero, Quaternion.identity, transform);

        switch (pieceType) {
            case "enemy":
                characterCard.GetComponent<Image>().color = _enemyColor;
                break;
            case "npc":
                characterCard.GetComponent<Image>().color = _npcColor;
                break;
            default:
                characterCard.GetComponent<Image>().color = _playerColor;
                break;
        }

        characterCard.name = characterProfile.id;

        foreach (Transform t in characterCard.transform) {
            if (t.name == "PName") t.GetComponent<TextMeshProUGUI>().text = characterProfile.name;
            if (t.name == "MOV") t.GetComponent<TextMeshProUGUI>().text = $"{characterProfile.stats.mov}";
            if (t.name == "PRO") {
                t.GetComponent<StatBar>().amt = characterProfile.stats.pro;
            }
            if (t.name == "STA") {
                t.GetComponent<StatBar>().amt = characterProfile.stats.sta;
                t.GetComponent<StatBar>().max = characterProfile.stats.sta;
            }
            if (t.name == "pSTA") {
                t.GetComponent<StatBar>().amt = 0;
                t.GetComponent<StatBar>().max = characterProfile.stats.sta;
            }
        }

        RecountAllCards();
    }
}
