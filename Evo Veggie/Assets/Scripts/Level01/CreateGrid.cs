using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public Transform gridPreFab;
    public Camera cam;
    public List<Vector3> positions = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        // Populate the positions list with all possible positions for grids
        for (int i = 0; i < GameObject.Find("Game").GetComponent<GameMain>().worldSize; i++)
        {
            for (int j = 0; j < GameObject.Find("Game").GetComponent<GameMain>().worldSize; j++)
            {
                Vector3 pos = new Vector3(i, 1.0f, j);
                positions.Add(pos);
            }
        }

        // Place grid prefabs at positions from grid.
        for (int i = 0; i < positions.Count; i++)
        {
            Transform t = Instantiate(gridPreFab);
            t.localPosition = positions[i];
        }

        // Move camera into correct location based on the world size.
        UpdateCameraPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update Grid when user presses the world size button.
    public void UpdateGrid()
    {
       Debug.Log("Add Grids");
        // Populate the news positions when player pushed the world size button.
        for (int i = 0; i < GameObject.Find("Game").GetComponent<GameMain>().worldSize; i++)
        {
            for (int j = GameObject.Find("Game").GetComponent<GameMain>().worldSize - 1; j < GameObject.Find("Game").GetComponent<GameMain>().worldSize; j++)
            {
                Vector3 foodPos = new Vector3(i, 1.0f, j);
                Vector3 plantEaterPos = new Vector3(i, 1.4f, j);
                positions.Add(foodPos);
                GameObject.Find("Game").GetComponent<GameMain>().foodPositions.Add(foodPos);
                GameObject.Find("Game").GetComponent<GameMain>().plantEaterStartPositions.Add(plantEaterPos);
            }
        }
        for (int i = GameObject.Find("Game").GetComponent<GameMain>().worldSize - 1; i < GameObject.Find("Game").GetComponent<GameMain>().worldSize; i++)
        {
            for (int j = 0; j < GameObject.Find("Game").GetComponent<GameMain>().worldSize; j++)
            {
                Vector3 foodPos = new Vector3(i, 1.0f, j);
                Vector3 plantEaterPos = new Vector3(i, 1.4f, j);
                positions.Add(foodPos);
                GameObject.Find("Game").GetComponent<GameMain>().foodPositions.Add(foodPos);
                GameObject.Find("Game").GetComponent<GameMain>().plantEaterStartPositions.Add(plantEaterPos);
            }
        }

        // Place grid prefabs at positions from grid.
        for (int i = 2 * (GameObject.Find("Game").GetComponent<GameMain>().worldSize - 1); i < positions.Count; i++)
        {
            Transform t = Instantiate(gridPreFab);
            t.localPosition = positions[i];
        }

    }

    // Update camera position
    public void UpdateCameraPos()
    {
        Vector3 camPos = new Vector3(GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2, GameObject.Find("Game").GetComponent<GameMain>().worldSize, -GameObject.Find("Game").GetComponent<GameMain>().worldSize / 2);
        cam.transform.localPosition = camPos;
        //cam.transform.Rotate(45f, 0f, 0f);
    }
}
