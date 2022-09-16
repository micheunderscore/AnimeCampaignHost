using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridVisual : MonoBehaviour {

    private Grid<PlayerGridObject> grid;
    private Mesh mesh;
    private bool updateMesh;

    private void Awake() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetGrid(Grid<PlayerGridObject> grid) {
        this.grid = grid;
        UpdateHeatMapVisual();

        grid.OnGridObjectChanged += Grid_OnGridObjectChanged;
    }

    private void Grid_OnGridObjectChanged(
        object sender,
         Grid<PlayerGridObject>.OnGridObjectChangedEventArgs e
    ) {
        updateMesh = true;
    }

    private void LateUpdate() {
        if (updateMesh) {
            updateMesh = false;
            UpdateHeatMapVisual();
        }
    }

    private void UpdateHeatMapVisual() {
        MeshUtils.CreateEmptyMeshArrays(
            grid.GetWidth() * grid.GetHeight(),
            out Vector3[] vertices,
            out Vector2[] uv,
            out int[] triangles
        );

        for (int x = 0; x < grid.GetWidth(); x++) {
            for (int y = 0; y < grid.GetHeight(); y++) {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();
                Vector3 gridObjectWorldPosition = grid.GetWorldPosition(x, y) + quadSize * .5f;

                PlayerGridObject gridObject = grid.GetGridObject(x, y);
                float gridValueNormalized = gridObject.GetValueNormalized();
                Vector2 gridValueUV = new Vector2(gridValueNormalized, 0f);
                MeshUtils.AddToMeshArrays(
                    vertices,
                    uv,
                    triangles,
                    index,
                    gridObjectWorldPosition,
                    0f,
                    quadSize,
                    gridValueUV,
                    gridValueUV
                );
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

}

public class PlayerGridObject {
    private const int MIN = 0, MAX = 100;
    private Grid<PlayerGridObject> grid;
    private int x, y;
    public int value;
    public PlayerGridObject(Grid<PlayerGridObject> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void SetValue(int setValue) {
        this.value = setValue;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }
    public float GetValueNormalized() {
        return (float)value / MAX;
    }

    public override string ToString() {
        return value > 0 ? value.ToString() : "";
    }
}
