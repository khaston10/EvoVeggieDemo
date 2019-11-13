using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
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
            Destroy(transform.gameObject);
            other.GetComponent<PlantEaterContoller>().foodEaten += 1;
        }
        else
        {
            Debug.Log("No Worries");
        }
        
     
       
    }
}
