using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public Vector2 currentPosition;
    public Location location;
    public Location destination;
    public PathFinding pathFinding;
    // Start is called before the first frame update
    void Start()
    {
        Tile start = location.locationGrid.tiles[currentPosition];
        Tile target = destination.locationGrid.tiles[new Vector2(10, 0)];
        pathFinding.currentLocation = location;
        pathFinding.currentPos = currentPosition;
        pathFinding.finalDestination = destination.locationGrid.tiles[new Vector2(10, 0)];
        pathFinding.FindPath(start,target);
        pathFinding.StartCoroutine("FollowPath", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
