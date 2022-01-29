using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class carController : MonoBehaviour
{

    public float moveSpeed;
    bool movingLeft = true;
    bool firstInput=true;
    public int haveFood = 0;
    public Text burgerText;
    public GameObject pickupEffect;
    public GameObject giveEffect;
    public GameObject nogiveEffect;

public GameObject RenderMesh;
private Renderer ren;
private Material[] mat;

    // Start is called before the first frame update
    void Start()
    {
    ren = RenderMesh.GetComponent<Renderer>();
    mat = ren.materials;
   //mat[0].color = Color.red;


if(!PlayerPrefs.HasKey("Speed"))
{
    changeMoveSpeed0();
}


if(PlayerPrefs.GetInt("Speed") == 1)
{
      changeMoveSpeed0();
}
if(PlayerPrefs.GetInt("Speed") == 2)
{
      changeMoveSpeed1();
}
if(PlayerPrefs.GetInt("Speed") == 3)
{
      changeMoveSpeed2();
}
if(PlayerPrefs.GetInt("Speed") == 4)
{
      changeMoveSpeed3();
}
if(PlayerPrefs.GetInt("Speed") == 0)
{
      changeMoveSpeedEasy();
}





    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager.instance.gameStarted)
        {
        move();
        checkInput();
        }

        if(transform.position.y <= -.3)
        {
            gameManager.instance.gameOver();
            Destroy(gameObject);
        }
    }

    void move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime ;

    }
    
    void checkInput()
    {
        // if first input then ignore
        if(firstInput)
        {
            firstInput=false;
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            changeDirection();
        }
    }


    void changeDirection()
    {
        if(movingLeft)
        {
            movingLeft=false;
            transform.rotation = Quaternion.Euler(0,90,0);
        }
        else
        {
            movingLeft=true;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
             if(PlayerPrefs.GetInt("Speed") == 0)
            {}
            else{
            gameManager.instance.collectFood();
            haveFood++;
            burgerText.text = "Burgers: " + haveFood;
            Instantiate(pickupEffect,other.transform.position,pickupEffect.transform.rotation);
            other.gameObject.SetActive(false);
            }
         
        }

        if(other.gameObject.tag == "Guy")
        {
            if(PlayerPrefs.GetInt("Speed") != 0)
            {

            if(haveFood > 0)
            {
            gameManager.instance.giveFood();
             Instantiate(giveEffect,other.transform.position,giveEffect.transform.rotation);
            haveFood--;
            burgerText.text = "Burgers: " + haveFood;
            }       
            else
            {
             Instantiate(nogiveEffect,other.transform.position,nogiveEffect.transform.rotation);
            gameManager.instance.deductScore();
            }
        }

        }
    }


public void changeMoveSpeedEasy()
{
   moveSpeed = 6;
      PlayerPrefs.SetInt("Speed",0);
}
public void changeMoveSpeed0()
{
   moveSpeed = 8;
      PlayerPrefs.SetInt("Speed",1);
}
public void changeMoveSpeed1()
{
   moveSpeed = 9;
     PlayerPrefs.SetInt("Speed",2);
}
public void changeMoveSpeed2()
{
   moveSpeed = 10;
     PlayerPrefs.SetInt("Speed",3);
}
public void changeMoveSpeed3()
{
   moveSpeed = 11; 
     PlayerPrefs.SetInt("Speed",4);
}

}
