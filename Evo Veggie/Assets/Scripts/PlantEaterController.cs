using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEaterController : MonoBehaviour
{
    public int direction = 0; // 0: Forward. 1: Backwards, 2: Right, 3: Left 
    public bool enter = true;

    private Vector3 dirVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            dirVector = new Vector3(0f, 0f, 1f);
            
        }
        else if (direction == 1)
        {
            dirVector = new Vector3(0f, 0f, -1f);
        }
        else if (direction == 2)
        {
            dirVector = new Vector3(1f, 0f, 0f);
        }
        else if (direction == 3)
        {
            dirVector = new Vector3(-1f, 0f, 0f);
        }

        if (GameObject.Find("Game").GetComponent<GameMain>().creaturesAwake == true && transform.position.z < GameObject.Find("Game").GetComponent<GameMain>().worldSize)
        {
            transform.Translate(dirVector * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("entered");

        }
            
    }

}
