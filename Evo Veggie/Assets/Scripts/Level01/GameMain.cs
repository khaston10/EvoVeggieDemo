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
    public bool creaturesAwake = true;
    public bool gamePaused = false;
    public float plantEaterSpeed = .5f; // Set to .5 in normal speed and 2 for Fast Forward mode.
    public Light star1;
    public Text GameSpeedDisplayText;
    public Text gamePointsText;
    public Text worldSizeText;
    public Text foodSpawnedText;
    public Text PlantEatersText;
    public Text dayCountText;
    public Transform planet1;
    public Transform star1Body;
    public Transform food;
    public Transform plantEater;
    public List<Vector3> foodPositions;
    public List<Vector3> plantEaterStartPositions;
    public List<Transform> foodList;
    public List<Transform> plantEaterList;

    public RawImage landOwnerImage;
    public Texture landOwnerTexture;
    


    //------------------------------------This code is used for debugging, remove before release.--------------------
    public bool foodOn = true;
    public bool movePlanetOn = true;
    public bool moveStarOn = true;
    public bool plantEatersOn = true;

    private int day = 1;
    private float timer = 0.0f;
    private float plantEaterTimer = 0.0f;
    private float lengthOfDay = 25.12f;
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


    // Start is called before the first frame update
    void Start()
    {
        worldSize = GlobalControl.Instance.worldSize;
        foodSpawned = GlobalControl.Instance.foodSpawned;
        plantEaters = GlobalControl.Instance.plantEaters;
        gamePoints = GlobalControl.Instance.gamePoints;


        // Populate the positions list with all possible positions for grids.
        for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                Vector3 foodPos = new Vector3(i, 1f, j);
                Vector3 plantEaterPos = new Vector3(i, 1.4f, j);
                foodPositions.Add(foodPos);
                plantEaterStartPositions.Add(plantEaterPos);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Start timer for day, when the timer reaches length_of_day the timer reasets, if game is paused then do not update time.
        if (gamePaused != true)
        {
            timer += Time.deltaTime;
            plantEaterTimer += Time.deltaTime;
            
        }

        // Restock food at the beginning of each day.
        if (foodList.Count < foodSpawned && foodOn && creaturesAwake)
        {
            // Pick a random position.
            int randPos = Random.Range(0, foodPositions.Count);

            // Place food at position and remove its position from the available list, then place the transform in the foodList. 
            Transform f = Instantiate(food);
            f.localPosition = foodPositions[randPos];
            foodPositions.RemoveAt(randPos);
            foodList.Add(f);
        }

        //------------------------------------This code is used for debugging, remove before release.--------------------
        if (foodOn == false)
        {
            for (int i = 0; i < foodList.Count; i++)
            {
                foodPositions.Add(foodList[i].localPosition);
                Destroy(foodList[i].gameObject);
            }
            foodList.Clear();
        }

        // Restock plant eaters at the beginning of each day.
        if (plantEaterList.Count < plantEaters && plantEatersOn && creaturesAwake)
        {
            // Pick a random position.
            int randPos = Random.Range(0, plantEaterStartPositions.Count);

            // Place plant eater at position, then place the transform in the plantEaterList. 
            Transform p = Instantiate(plantEater);
            p.localPosition = plantEaterStartPositions[randPos];
            plantEaterList.Add(p);

        }

        //------------------------------------This code is used for debugging, remove before release.--------------------
        if (plantEatersOn == false)
        {
            for (int i = 0; i < plantEaterList.Count; i++)
            {
                plantEaterStartPositions.Add(plantEaterList[i].localPosition);
                Destroy(plantEaterList[i].gameObject);
            }
            plantEaterList.Clear();
        }


        // Update panels.
        GameSpeedDisplayText.text = gameSpeed.ToString();
        gamePointsText.text = gamePoints.ToString();
        worldSizeText.text = worldSize.ToString();
        foodSpawnedText.text = foodSpawned.ToString();
        PlantEatersText.text = plantEaters.ToString();
        dayCountText.text = day.ToString();

        // Check to see if creatures should be awake or asleep.
        if (timer >= (lengthOfDay / 2) && creaturesAwake == true)
        {
            creaturesAwake = false;
        }

        else if (timer < (lengthOfDay / 2) && creaturesAwake == false)
        {
            creaturesAwake = true;
        }

        // Update planet positions.
        //------------------------------------This code is used for debugging, remove before release.--------------------
        if (moveStarOn)
        {
            star1YPos = worldSize * Mathf.Sin(timerSpeedCoefficient * timer);
            star1XPos = worldSize * Mathf.Cos(timerSpeedCoefficient * timer) + worldSize / 2;
            star1Body.position = new Vector3(xPos, yPos, worldSize / 2);
        }

        //------------------------------------This code is used for debugging, remove before release.--------------------
        if (movePlanetOn)
        {
            planetZPos = worldSize * -3 * Mathf.Cos(timerSpeedCoefficient * timer);
            planetYPos = worldSize * Mathf.Cos(timerSpeedCoefficient * timer);
            planetXPos = worldSize * Mathf.Sin(timerSpeedCoefficient * timer) + worldSize / 2;
            planet1.position = new Vector3(planetXPos, planetYPos, planetZPos);
        }
        

        // Move the source of light, star1.
        star1.intensity = worldSize / 5;
        yPos = worldSize * Mathf.Sin(timerSpeedCoefficient * timer);
        xPos = worldSize * Mathf.Cos(timerSpeedCoefficient * timer) + worldSize / 2;
        star1.transform.position = new Vector3(xPos, yPos, worldSize / 2);


        if (timer >= lengthOfDay)
        {

            timer = 0;
            day += 1;
            Debug.Log("Day: " + day);

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
        if (timerSpeedCoefficient == 1)
        {
            lengthOfDay = 25.12f;
            timerSpeedCoefficient = .25f;
            timer *= 4;
            gameSpeed = 1;
        }

        // only makes changes when this button is pushed while game is paused.
        if (gamePaused == true)
        {
            gamePaused = false;
        }

        // Update the plant eater's speed to match fast forward.
        plantEaterSpeed = .5f;
    }

    public void ClickFastForward()
    {
        // Only make changes if the lengthOFDay = 1440, meaning fast forward was occuring. 
        if (timerSpeedCoefficient == .25)
        {
            lengthOfDay = 6.28f;
            timerSpeedCoefficient = 1f;
            timer /= 4;
            gameSpeed = 4;
        }

        // only makes changes when this button is pushed while game is paused.
        if (gamePaused == true)
        {
            gamePaused = false;
        }

        // Update the plant eater's speed to match fast forward.
        plantEaterSpeed = 2f;

    }

    public void ClickFoodSpawned()
    {
        if (gamePoints > 0 && foodPositions.Count > 0 && creaturesAwake)
        {
            gamePoints -= 1;
            foodSpawned += 1;
        }
    }

    public void ClickWorldSize()
    {
        if (gamePoints > 0)
        {
            gamePoints -= 1;
            worldSize += 1;
            GameObject.Find("Grid").GetComponent<CreateGrid>().UpdateGrid();
            GameObject.Find("Grid").GetComponent<CreateGrid>().UpdateCameraPos();
        }

        // Check to see if the Land Owner achievement is unlocked.
        if (worldSize >= 20)
        {
            landOwnerImage.color = Color.white;
            landOwnerImage.texture = landOwnerTexture;
        }
            

    }

    public void ClickPlantEaters()
    {
        if (gamePoints > 0 && creaturesAwake)
        {
            gamePoints -= 1;
            plantEaters += 1;
        }
    }

}
