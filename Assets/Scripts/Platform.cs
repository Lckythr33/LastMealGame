using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject food; 
    public GameObject guy; 
  
    // Start is called before the first frame update
    void Start()
    {

        Vector3 foodPos = transform.position;
        foodPos.y += 0.7f;
        foodPos.x +=1f;
       
        Vector3 guyPos = transform.position;
        guyPos.y += 0.5f;
        guyPos.x +=0.8f;

        int randFood = Random.Range(0,20);
            if(randFood < 1)
            {
            //spawn food
                GameObject foodInstance = Instantiate(food,foodPos,food.transform.rotation);
            
                foodInstance.transform.SetParent(gameObject.transform);

            }

           int randGuy = Random.Range(0,30);
            if(randGuy < 1)
            {
            //spawn food
                GameObject guyInstance = Instantiate(guy,guyPos,guy.transform.rotation);
            
                guyInstance.transform.SetParent(gameObject.transform);
                
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            Invoke("fall",0.2f);
    }

    void fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 0.2f);
    }
}
