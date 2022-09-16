using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour {
    [SerializeField] private PlayerGridVisual playerGridObject;
    [SerializeField] private int height = 10, width = 10;
    [SerializeField] private float cellSize = 10f;
    private Grid<PlayerGridObject> grid;
    private void Start() {
        Vector2 gridOriginPosition = new Vector2(-height * cellSize, -width * cellSize) * 0.5f;

        grid = new Grid<PlayerGridObject>(
            height,
            width,
            cellSize,
            gridOriginPosition,
            (Grid<PlayerGridObject> g, int x, int y) => new PlayerGridObject(g, x, y)
        );
        playerGridObject.SetGrid(grid);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 pos = UtilsClass.GetMouseWorldPosition();
            PlayerGridObject playerGridObject = grid.GetGridObject(pos);
            if (playerGridObject != null) {
                playerGridObject.SetValue(Random.Range(1, 100));
            }
        }
    }
}
