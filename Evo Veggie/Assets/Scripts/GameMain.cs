using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public int worldSize;
    public int foodSpawned;
    public int plantEaters;
    public int gamePoints;
    public Light star1;
    public Text GameSpeedDisplayText;
    public Transform planet1;
    public Transform star1Body;

    private int day = 1;
    private float step = 0;
    private float timer = 0.0f;
    private int lengthOfDay = 1440;
    private float timerSpeedCoefficient = .25f; // This value depends on the lengthOfDay. If Day is 360 the coefficient should be 1.
    // If lengthOfDay is 2 *360, or 720 the coefficient should be 1/2 or .5, and so on. 
    private int gameSpeed = 1;
    private float yPos;
    private float xPos;
    private float star1YPos;
    private float star1XPos;
    private float planetYPos;
    private float planetZPos;
    private float planetXPos;
    private bool gamePaused = false;


    // Start is called before the first frame update
    void Start()
    {
        worldSize = GlobalControl.Instance.worldSize;
        foodSpawned = GlobalControl.Instance.foodSpawned;
        plantEaters = GlobalControl.Instance.plantEaters;
        gamePoints = GlobalControl.Instance.gamePoints;

        GetComponent<PlantEaters>().PlacePlantEaters();

    }

    // Update is called once per frame
    void Update()
    {
        // Start timer for day, when the timer reaches length_of_day the timer reasets, if game is paused then do not update time.
        if (gamePaused != true)
        {
            timer += Time.deltaTime;
        }
        Debug.Log(timer);


        // Update panels.
        GameSpeedDisplayText.text = gameSpeed.ToString();

        // Update planet positions.
        star1YPos = worldSize * Mathf.Sin(timerSpeedCoefficient * timer);
        star1XPos = worldSize * Mathf.Cos(timerSpeedCoefficient * timer) + worldSize / 2;
        star1Body.position = new Vector3(xPos, yPos, worldSize / 2);

        planetZPos = worldSize * -3 * Mathf.Cos(timerSpeedCoefficient * timer);
        planetYPos = worldSize * Mathf.Cos(timerSpeedCoefficient * timer);
        planetXPos = worldSize * Mathf.Sin(timerSpeedCoefficient * timer) + worldSize / 2;
        planet1.position = new Vector3(planetXPos, planetYPos, planetZPos);

        // Move the source of light, star1.
        star1.intensity = worldSize / 5;
        yPos = worldSize * Mathf.Sin(timerSpeedCoefficient * timer);
        xPos = worldSize * Mathf.Cos(timerSpeedCoefficient * timer) + worldSize / 2;

        star1.transform.position = new Vector3(xPos, yPos, worldSize / 2);

        if (timer >= lengthOfDay)
        {
            timer = 0;
            day += 1;
        }
    }

    // Save data to Global Control
    public void SaveData()
    {
        GlobalControl.Instance.worldSize = worldSize;
        GlobalControl.Instance.foodSpawned = foodSpawned;
        GlobalControl.Instance.plantEaters = plantEaters;
        GlobalControl.Instance.gamePoints = gamePoints;
    }

    // This section handles buttons on screen.
    public void ClickPause()
    {
        if (gamePaused == false)
        {
            gamePaused = true;
            gameSpeed = 0;
        }
    }

    public void ClickForward()
    {
        // Only makes changes if the lengthOfDay = 360, meaning forward mode was occuring. 
        if (lengthOfDay == 360)
        {
            lengthOfDay = 1440;
            timerSpeedCoefficient = .25f;
            timer *= 4;
            gameSpeed = 1;
        }

        // only makes changes when this button is pushed while game is paused.
        if (gamePaused == true)
        {
            gamePaused = false;
        }
    }

    public void ClickFastForward()
    {
        // Only make changes if the lengthOFDay = 1440, meaning fast forward was occuring. 
        if (lengthOfDay == 1440)
        {
            lengthOfDay = 360;
            timerSpeedCoefficient = 1f;
            timer /= 4;
            gameSpeed = 4;
        }

        // only makes changes when this button is pushed while game is paused.
        if (gamePaused == true)
        {
            gamePaused = false;
        }

    }


    

}
