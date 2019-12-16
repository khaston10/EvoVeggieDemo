using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private Color FedPlantEater = new Color(.1f, 1f, .1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        // add isTrigger
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plantEater"))
        {
            GameObject.Find("Game").GetComponent<GameMain>().foodPositions.Add(transform.localPosition);
            GameObject.Find("Game").GetComponent<GameMain>().foodList.Remove(transform);
            GameObject.Find("Game").GetComponent<GameMain>().gamePoints += 1;
            GameObject.Find("Game").GetComponent<GameMain>().gamePointsText.text = GameObject.Find("Game").GetComponent<GameMain>().gamePoints.ToString();
            Destroy(transform.gameObject);
            other.GetComponent<PlantEaterContoller>().foodEaten += 1;
            other.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = FedPlantEater;
        }
        else
        {
            Debug.Log("No Worries");
        }
        
     
       
    }
}
