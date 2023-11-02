using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public List<Vector3> calculatedPositions = new List<Vector3>();
    public List<Vector3> CalculatePositions(Vector3 touchPosition)
    {
        // Thêm các vị trí vào danh sách
        Vector3 startPosition = transform.parent.position;
        var position0 = new Vector3(touchPosition.x, startPosition.y, 0);
        var position1 = touchPosition;
        var position2 = new Vector3(touchPosition.x, startPosition.y, 0);
        var position3 = new Vector3(touchPosition.x, -4f, 0);
        var position4 = startPosition;
        calculatedPositions.Add(position0);
        calculatedPositions.Add(position1);
        calculatedPositions.Add(position2);
        calculatedPositions.Add(position3);
        calculatedPositions.Add(position4);
        // Trả về danh sách vị trí sau khi tính toán
        return calculatedPositions;
    }
}
