using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject player;
    public string activeRoom = "Scene 1";
    //Log last time the player was in a scene
    //If the player is not in the same room as the NPC then the routine doesnt matter
    //If the player is in the same room the animation/pathfinding will play
    //

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Scene 1", LoadSceneMode.Additive);
        SceneManager.LoadScene("Scene 2", LoadSceneMode.Additive);
            StartCoroutine(ActivateScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == activeRoom)
        { 
            player.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().name != activeRoom) 
        {
            player.SetActive(false);
        }
        //player.transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
    }

    public void UnloadScene()
    {
        SceneManager.LoadScene("Scene 2", LoadSceneMode.Additive);
        StartCoroutine(ActivateScene());
        //SceneManager.UnloadSceneAsync("Scene 1");

    }

    IEnumerator ActivateScene()
    {
        yield return 0;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene 1"));
        //SceneManager.MoveGameObjectToScene(player,SceneManager.GetSceneByName("Persistent Scene"));
    }
}
