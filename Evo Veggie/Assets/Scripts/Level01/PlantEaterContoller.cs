using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEaterContoller : MonoBehaviour
{
    public float speed = .5f;
    public int timeBetweenDirectionChange = 1;

    private int direction = 0; // 0: Move y+, 1: Move y-, 2: Move x+, 3: Move x-
    private float timer = 0.0f;
    public Transform plantEaterBody;

    // Start is called before the first frame update
    void Start()
    {
        plantEaterBody = transform.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        

        // Start timer for the plant eater's movement.
        if (GameObject.Find("Game").GetComponent<GameMain>().gamePaused != true)
        {
            timer += Time.deltaTime;
        }

        // Check to see if it is time to update plant eater's direction.
        if (timeBetweenDirectionChange < timer)
        {
            PlantEaterChangeDirection();
            timer = 0;
        }

        // Move plant eater if creatures are awake.
        if (GameObject.Find("Game").GetComponent<GameMain>().creaturesAwake && GameObject.Find("Game").GetComponent<GameMain>().gamePaused != true)
        {
            PlantEaterMove();
        }

        
    }

    public void PlantEaterChangeDirection()
    {
        direction = Random.Range(0, 4);

        if (direction == 0) plantEaterBody.Rotate(Vector3.up);
        else if (direction == 1) plantEaterBody.Rotate(-Vector3.up);
        else if (direction == 2) plantEaterBody.Rotate(Vector3.right);


    }

    public void PlantEaterMove()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
