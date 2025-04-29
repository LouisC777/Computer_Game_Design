using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleManager : MonoBehaviour
{
    public Tilemap doorTilemap;                // 拖入你的门所在的 Tilemap
    public Vector3Int doorTilePosition;        // 指定门的位置（格子坐标）

    public void OnPuzzleSolved()
    {
        // 移除门的 tile
        doorTilemap.SetTile(doorTilePosition, null);
        doorTilemap.RefreshTile(doorTilePosition);
        Debug.Log("Door opened");
    }
}
