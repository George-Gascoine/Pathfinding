using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Location : MonoBehaviour
{
    public string locationName;
    public List<Transition> transitions;
    public List<Location> connectedLocations;
    public Grid2D locationGrid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GenerateTransitions()
    {
        locationGrid.gridWidth = 30;
        locationGrid.gridHeight = 30;
        foreach (Location loc in connectedLocations)
        {
            Transition newTran = new()
            {
                location = this,
                destination = loc,
                destinationSpawn = new Vector2(0, 0),
                locationTile = new Vector2(5, 0)
            };
            transitions.Add(newTran);
        }
    }
}
