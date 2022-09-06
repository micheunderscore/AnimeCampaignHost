using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour {
    [SerializeField] private int _perimeter, _canvasSize;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private GridLayoutGroup _grid;
    private Dictionary<float, Tile> _tiles;

    public void Start() {
        GenerateGrid();
    }

    public void GenerateGrid() {
        // Dims
        float dimensions = _perimeter * 2f;
        float tileXY = (_canvasSize / _perimeter) - 1f;

        // Tile Array
        _tiles = new Dictionary<float, Tile>();

        // Gen Grid
        for (int x = 0; x < _perimeter; x++) {
            for (int y = 0; y < _perimeter; y++) {
                int i = (x * _perimeter) + y;
                _grid.cellSize = new Vector2(tileXY, tileXY);
                var spawnedTile = Instantiate(_tilePrefab, Vector3.zero, Quaternion.identity, transform);
                spawnedTile.name = $"({x},{y})";

                var isOffset = (i % 2 == 0);
                spawnedTile.Init(isOffset);

                _tiles[i] = spawnedTile;
            }
        }
    }

    public void ClearGrid() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

    public void RegenerateGrid(TMP_InputField input) {
        _perimeter = int.Parse(input.text); // TODO: Fix this buggy shit before it breaks or smth
        GenerateGrid();
    }

    public Tile GetTileByNum(float num) {
        if (_tiles.TryGetValue(num, out var tile)) {
            return tile;
        }
        return null;
    }
}
