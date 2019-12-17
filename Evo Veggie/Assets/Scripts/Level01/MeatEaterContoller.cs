using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatEaterContoller : MonoBehaviour
{
    public int timeBetweenDirectionChange = 1;
    public int daysSinceLastEaten = 0;

    private int direction = 0; // 0: Move y+, 1: Move y-, 2: Move x+, 3: Move x-
    private float timer = 0.0f;
    private Color FedMeatEater = new Color(.55f, .33f, .04f, 1f);
    public AudioClip EatSound;

    // Start is called before the first frame update
    void Start()
    {

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
            MeatEaterChangeDirection();
            timer = 0;
        }

        // Move plant eater if creatures are awake.
        if (GameObject.Find("Game").GetComponent<GameMain>().creaturesAwake && GameObject.Find("Game").GetComponent<GameMain>().gamePaused != true 
            && GameObject.Find("Game").GetComponent<GameMain>().meatEatersFrozen == false)
        {
            MeatEaterMove();
        }

    }
    public void MeatEaterChangeDirection()
    {
        direction = Random.Range(0, 4);

        if (direction == 0) transform.localRotation = Quaternion.Euler(0, 90, 0);
        else if (direction == 1) transform.localRotation = Quaternion.Euler(0, -90, 0);
        else if (direction == 2) transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (direction == 3) transform.localRotation = Quaternion.Euler(0, 0, 0);


    }

    public void MeatEaterMove()
    {
        transform.Translate(-Vector3.right * GameObject.Find("Game").GetComponent<GameMain>().meatEaterSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "meatEater")
        {
            Physics.IgnoreCollision(col.collider, GetComponent<Collider>());
        }

        else if (col.gameObject.tag == "plantEater")
        {
            AudioSource.PlayClipAtPoint(EatSound, transform.position);
            GameObject.Find("Game").GetComponent<GameMain>().plantEaters -= 1;
            GameObject.Find("Game").GetComponent<GameMain>().plantEaterList.Remove(col.transform);
            Destroy(col.transform.gameObject);
            daysSinceLastEaten = 0;
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = FedMeatEater;
            transform.GetChild(0).GetChild(2).GetComponent<Renderer>().material.color = FedMeatEater;
            transform.GetChild(0).GetChild(3).GetComponent<Renderer>().material.color = FedMeatEater;
        }
    }
}


