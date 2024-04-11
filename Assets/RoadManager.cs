using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 25.000094f;

    public void MoveRoad()
    {
        GameObject movedRoad = roads[0];
        float roadCount = roads.Count;
        roads.Remove(movedRoad);
        movedRoad.transform.position = new Vector3(movedRoad.transform.position.x,movedRoad.transform.position.y,movedRoad.transform.position.z + offset*roadCount);
        roads.Add(movedRoad);
    }

}
