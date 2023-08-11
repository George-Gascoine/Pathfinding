using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class GameManager : MonoBehaviour
{
    public LoadScene sceneLoader;
    public List<Location> gameLocations;
    public List<BoxCollider2D> sceneColliders;
    public Dictionary<string, Grid2D> sceneGrids = new();
    public NPCMove npc;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (Location location in gameLocations)
        {
            sceneLoader.SceneLoader(location.locationName, location);
        }
        StartCoroutine(NPCStart());
        
    }

    public void GenerateGridWithCollisions(Location location)
    {
        location.transitions.Clear();
        //location.locationGrid.locationColliders = sceneColliders;
        //location.locationGrid.GenerateGrid();
        Grid2D grid = new();
        grid.locationColliders = sceneColliders;
        grid.GenerateGrid();
        sceneGrids.Add(location.locationName, grid);
        location.GenerateTransitions();
    }

    IEnumerator NPCStart()
    {
        yield return new WaitForSeconds(3);
        npc.StartPath();
    }
}
