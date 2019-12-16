using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutPlantEaterContoller : MonoBehaviour
{
    public int timeBetweenDirectionChange = 1;
    public int foodEaten = 1;
    public bool isStarving = false;

    private int direction = 0; // 0: Move y+, 1: Move y-, 2: Move x+, 3: Move x-
    private float timer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Start timer for the plant eater's movement.
        if (GameObject.Find("Game").GetComponent<TutGameMain>().gamePaused != true)
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
        if (GameObject.Find("Game").GetComponent<TutGameMain>().creaturesAwake && GameObject.Find("Game").GetComponent<TutGameMain>().gamePaused != true)
        {
            PlantEaterMove();
        }
    }

    public void PlantEaterChangeDirection()
    {
        direction = Random.Range(0, 4);

        if (direction == 0) transform.localRotation = Quaternion.Euler(0, 90, 0);
        else if (direction == 1) transform.localRotation = Quaternion.Euler(0, -90, 0);
        else if (direction == 2) transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (direction == 3) transform.localRotation = Quaternion.Euler(0, 0, 0);


    }

    public void PlantEaterMove()
    {
        if (GameObject.Find("Game").GetComponent<TutGameMain>().caffeineSpeedOn)
        {
            transform.Translate(-Vector3.right * GameObject.Find("Game").GetComponent<TutGameMain>().caffeinePlantEaterSpeed * Time.deltaTime);
        }
        else transform.Translate(-Vector3.right * GameObject.Find("Game").GetComponent<TutGameMain>().plantEaterSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Food")
        {
            //GameObject.Find("Game").GetComponent<TutGameMain>().gamePoints += 1;
        }

        else if (col.gameObject.tag == "plantEater")
        {
            Physics.IgnoreCollision(col.collider, GetComponent<Collider>());
        }
    }
}
