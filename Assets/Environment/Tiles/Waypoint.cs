using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            var isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = isPlaced;
        }
    }
}
