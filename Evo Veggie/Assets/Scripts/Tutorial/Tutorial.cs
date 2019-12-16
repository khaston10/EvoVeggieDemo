using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public RectTransform tutorialPanel;
    public RectTransform gameSpeedPanel;
    public Text tutorialText;
    private Vector3 panelPos;
    public bool task1 = false; // Press Mouse 2 button.
    public bool task2 = false; // Press the Play button.
    public bool task3 = false; // Add 3 plant Eaters to the game.
    public bool task4 = false; // Wait for plant Eaters to die.
    public bool task5 = false; // Add 10 plants to the game.
    public bool task6 = false;
    public bool task7 = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set settings in Game Main script to start tutorial.
        GetComponent<TutGameMain>().gamePaused = true;

        // Delete all food on start;
        for (int i = GetComponent<TutGameMain>().foodList.Count - 1; i >= 0; i--)
        {
            Destroy(GetComponent<TutGameMain>().foodList[i].gameObject);
        }
        GetComponent<TutGameMain>().foodList.Clear();
        GetComponent<TutGameMain>().foodSpawned = 0;

        // Destroy all plant eaters.
        for (int i = GetComponent<TutGameMain>().plantEaterList.Count - 1; i >= 0; i--)
        {
            Destroy(GetComponent<TutGameMain>().plantEaterList[i].gameObject);
        }
        GetComponent<TutGameMain>().plantEaterList.Clear();
        GetComponent<TutGameMain>().plantEaters = 0;

        GetComponent<TutGameMain>().movePlanetOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (task1 == false)
        {
            if (Input.GetMouseButton(2))
            {
                task1 = true;
                Task2();
            }
        }

        else if(task2 && task3 == false)
        {
            if (GetComponent<TutGameMain>().plantEaters >= 3)
            {
                task3 = true;
                Task4();
            }
        }

        else if(task4 && task5 == false)
        {

            if (GetComponent<TutGameMain>().plantEaters == 0) task5 = true;
          
        }

        else if(task5 && task6 == false)
        {
            if (GetComponent<TutGameMain>().plantEaters == 0) Task5();
        }


        else if (task6 && task7 == false)
        {
            if (GetComponent<TutGameMain>().worldSize >= 10)
            {
                task7 = true;
                Task7();
            }
        }

    }

    public void Task2()
    {
        tutorialPanel.sizeDelta = new Vector2(200, 30);
        panelPos = gameSpeedPanel.localPosition;
        panelPos.x = 200f;
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(180, 20);
        tutorialText.text= "Try pressing the play button.";
    }

    public void Task3()
    {
        if (task1 == true && task2 == false)
        {
            task2 = true;

            // Place the next set of instructions.
            tutorialPanel.sizeDelta = new Vector2(300, 150);
            panelPos = new Vector2(0f, 0f);
            tutorialPanel.localPosition = panelPos;
            tutorialText.rectTransform.sizeDelta = new Vector2(280, 130);
            tutorialText.text = "The inhabitants of Flat World are called Plant-Eaters. \n You can add Plant-Eaters by pressing the ‘Plant Eater’ button. " +
                " \n \n Let’s add three plant eaters now.";
        }
    }

    public void Task4()
    {
        if (task1 && task2 && task3 && task4 ==false)
        {
            task4 = true;

            // Place the next set of instructions.
            tutorialPanel.sizeDelta = new Vector2(500, 150);
            panelPos = new Vector2(0f, -200f);
            tutorialPanel.localPosition = panelPos;
            tutorialText.rectTransform.sizeDelta = new Vector2(380, 130);
            tutorialText.text = "During the day Plant-Eaters move randomly in search of food. \n At night they stop moving to sleep. \n \n Warning: Plant-Eaters need plants to live." +
                "If a Plant-Eater does not eat, they will die. \n \n Wait for these Plant-Eaters to die.";
        }
    }

    public void Task5()
    {

        // Place the next set of instructions.
        tutorialPanel.sizeDelta = new Vector2(300, 150);
        panelPos = new Vector2(0f, 0f);
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(280, 130);
        tutorialText.text = "Plant-Eaters need plants to survive. Try adding 10 plants to FlatWorld now. \n \n NOTICE: Plants only grow at sunrise.";

    }

    public void Task6()
    {
        task6 = true;

        // Place the next set of instructions.
        tutorialPanel.sizeDelta = new Vector2(300, 90);
        panelPos = new Vector2(0f, 0f);
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(280, 85);
        tutorialText.text = "FlatWorld is feeling a little cramped now. \n Try increasing the world size.";

    }

    public void Task7()
    {
        // Place the next set of instructions.
        tutorialPanel.sizeDelta = new Vector2(300, 300);
        panelPos = new Vector2(0f, 0f);
        tutorialPanel.localPosition = panelPos;
        tutorialText.rectTransform.sizeDelta = new Vector2(280, 280);
        tutorialText.text = "Now that you know the basics, help the Plant-Eaters to survive. \n \n But be careful, if all the Plant-Eaters die, the game is over!" +
            "\n \n During the struggle for survival you will encounter an alien race that likes to snack on Plant-Eaters. Use the Upgrade Panel to survive. \n \n" +
            "To complete the game earn all of the Achievements!";

    }


}
