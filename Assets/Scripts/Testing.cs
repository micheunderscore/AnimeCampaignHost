using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour {
    [SerializeField] private HeatMapGenericVisual heatMapVisual;
    private Grid<HeatMapGridObject> grid;
    private void Start() {
        grid = new Grid<HeatMapGridObject>(10, 10, 10f, new Vector3(50, 25), (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));
        heatMapVisual.SetGrid(grid);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 pos = UtilsClass.GetMouseWorldPosition();
            HeatMapGridObject heatMapGridObject = grid.GetGridObject(pos);
            if (heatMapGridObject != null) {
                heatMapGridObject.AddValue(5);
            }
        }
    }
}

public class HeatMapGridObject {
    private const int MIN = 0;
    private const int MAX = 100;
    private Grid<HeatMapGridObject> grid;
    private int x, y;
    public int value;
    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue) {
        this.value += addValue;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }
    public float GetValueNormalized() {
        return (float)value / MAX;
    }

    public override string ToString() {
        return value.ToString();
    }
}
