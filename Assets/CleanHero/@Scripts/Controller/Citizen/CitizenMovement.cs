using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public TilemapGrid grid; // walkable[,] 보유한 클래스
    public Vector2Int targetTilePos;

    private Coroutine moveRoutine;

    void Start()
    {
        // 예시: 도착 목표 설정
        SetDestination(targetTilePos);  
    }

    public void SetDestination(Vector2Int target)
    {
        Vector2Int start = WorldToTilePos(transform.position);
        List<Vector2Int> path = AStarPathfinder.FindPath(start, target, grid.walkable);
        if (path != null && path.Count > 1)
        {
            if (moveRoutine != null)
                StopCoroutine(moveRoutine);
            moveRoutine = StartCoroutine(FollowPath(path));
        }
    }

    IEnumerator FollowPath(List<Vector2Int> path)
    {
        foreach (Vector2Int tilePos in path)
        {
            Vector3 worldPos = grid.groundMap.CellToWorld((Vector3Int)tilePos) + new Vector3(0.5f, 0.5f);
            while (Vector3.Distance(transform.position, worldPos) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, worldPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

    private Vector2Int WorldToTilePos(Vector3 worldPos)
    {
        Vector3Int cell = grid.groundMap.WorldToCell(worldPos);
        return new Vector2Int(cell.x - (int)grid.origin.x, cell.y - (int)grid.origin.y);
    }
}
