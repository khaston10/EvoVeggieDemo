using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEaters : MonoBehaviour
{
    public Transform plantEaterPrefab;
    public List<Vector3> positions = new List<Vector3>();
    public List<Transform> plantEaterList = new List<Transform>();

    // Start is called before the first frame update
    public void PlacePlantEaters()
    {
        // Populate the positions list with all possible positions for grids
        for (int i = 0; i < GetComponent<GameMain>().worldSize; i++)
        {
            for (int j = 0; j < GetComponent<GameMain>().worldSize; j++)
            {
                Vector3 pos = new Vector3(i, 1.5f, j);
                positions.Add(pos);
            }
        }

        // Create plant eaters based upon number plant eaters.
        for (int i = 0; i < GetComponent<GameMain>().plantEaters; i++)
        {
            Transform t = Instantiate(plantEaterPrefab);
            plantEaterList.Add(t);

            // Pick random location.
            int pos = Random.Range(0, positions.Count);
            t.localPosition = positions[pos];
            positions.RemoveAt(pos);
        }
    }

    public void MovePlantEaters()
    {
        for (int i = 0; i < plantEaterList.Count; i++)
        {
            // Pick a random direction. 0: x+, 1: x-, 2: z+, 3: z-
            int dir = Random.Range(0, 4);
            
            // Move plant eater in the selected direction.
            if (dir == 0)
            {
                plantEaterList[i].Translate(Vector3.forward * Time.deltaTime);
            }
            else if (dir == 1)
            {
                plantEaterList[i].Translate(-Vector3.forward * Time.deltaTime);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
