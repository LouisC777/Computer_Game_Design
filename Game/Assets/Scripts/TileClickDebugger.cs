using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClickDebugger : MonoBehaviour
{
    public Tilemap targetTilemap;  // 拖你要检查的 Tilemap，比如 ToiletDoorMap

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = targetTilemap.WorldToCell(mouseWorldPos);
            Debug.Log("你点到了格子坐标: " + cellPos);
        }
    }
}
