using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// следим за передвижением курсора 
/// подписываемся на место положения курсора  [ OnEnable ]
/// отписуемся [ OnDisable ]
/// применяем координаты на эфект
/// </summary>
public class CoordinatCursor : MonoBehaviour
{
    private void OnEnable()
    {
        ColliderForCursor.CoordinatPositionCursorEvent += CurentCoordinatCursor;
    }
    private void OnDisable()
    {
        ColliderForCursor.CoordinatPositionCursorEvent -= CurentCoordinatCursor;
    }
    void CurentCoordinatCursor(Vector3 newCoordinats)
    {
        transform.position = newCoordinats;

    }

}
