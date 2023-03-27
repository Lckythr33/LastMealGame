using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance; 
    public GameObject gamePlayUI;
    public GameObject menuUI;
    public GameObject lockOverlay;
    public Text highScoreText;
    public GameObject platformSpawner;
    public Text scoreText;
    int score = 0;
    int highScore;
    public bool gameStarted;
    AudioSource audioSource;
    public AudioClip[] gameAudio; 
    public GameObject skinPanel;
    public GameObject[] locks;
    int adCounter = 0;

public GameObject RenderMesh;
private Renderer ren;
private Material[] mat;

public GameObject rlw;
private Renderer ren2;
private Material[] mat2;

public GameObject rrw;
private Renderer ren3;
private Material[] mat3;

public GameObject rw;
private Renderer ren4;
private Material[] mat4;

public GameObject lw;
private Renderer ren5;
private Material[] mat5;



    private void Awake()
    {
        gamePlayUI.SetActive(false);

        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CheckAdCount();


        skinPanel.SetActive(false);

ren = RenderMesh.GetComponent<Renderer>();
mat = ren.materials;

ren2 = rlw.GetComponent<Renderer>();
mat2 = ren2.materials;

ren3 = rrw.GetComponent<Renderer>();
mat3 = ren3.materials;

ren4 = rw.GetComponent<Renderer>();
mat4 = ren4.materials;

ren5 = lw.GetComponent<Renderer>();
mat5 = ren5.materials;

//mat[0].color = Color.red;

  
if(PlayerPrefs.GetInt("BodyColor") == 1)
    {
        mat[1].color = Color.grey; 
    }
if(PlayerPrefs.GetInt("BodyColor") == 2)
    {
        mat[1].color = Color.yellow; 
    }
if(PlayerPrefs.GetInt("BodyColor") == 3)
    {
        mat[1].color = Color.green; 
    }
if(PlayerPrefs.GetInt("BodyColor") == 4)
    {
        mat[1].color = Color.red; 
    }
if(PlayerPrefs.GetInt("BodyColor") == 5)
    {
        mat[1].color = Color.blue; 
    }
if(PlayerPrefs.GetInt("BodyColor") == 6)
    {
        mat[1].color = Color.black; 
    }

if(PlayerPrefs.GetInt("TrimColor") == 1)
    {
        mat[0].color = Color.grey; 
    }
if(PlayerPrefs.GetInt("TrimColor") == 2)
    {
        mat[0].color = Color.yellow; 
    }
if(PlayerPrefs.GetInt("TrimColor") == 3)
    {
        mat[0].color = Color.green; 
    }
if(PlayerPrefs.GetInt("TrimColor") == 4)
    {
        mat[0].color = Color.red; 
    }
if(PlayerPrefs.GetInt("TrimColor") == 5)
    {
        mat[0].color = Color.blue; 
    }
if(PlayerPrefs.GetInt("TrimColor") == 6)
    {
        mat[0].color = Color.black; 
    }

if(PlayerPrefs.GetInt("RimColor") == 1)
    {
        mat2[1].color = Color.white;  
        mat3[1].color = Color.white;  
        mat4[1].color = Color.white;  
        mat5[1].color = Color.white;  
    }
if(PlayerPrefs.GetInt("RimColor") == 2)
    {
        mat2[1].color = Color.yellow;  
        mat3[1].color = Color.yellow;  
        mat4[1].color = Color.yellow;  
        mat5[1].color = Color.yellow;  
    }
if(PlayerPrefs.GetInt("RimColor") == 3)
    {
        mat2[1].color = Color.green;  
        mat3[1].color = Color.green;  
        mat4[1].color = Color.green;  
        mat5[1].color = Color.green;  
    }
if(PlayerPrefs.GetInt("RimColor") == 4)
    {
        mat2[1].color = Color.red;  
        mat3[1].color = Color.red;  
        mat4[1].color = Color.red;  
        mat5[1].color = Color.red;  
    }
if(PlayerPrefs.GetInt("RimColor") == 5)
    {
        mat2[1].color = Color.blue;  
        mat3[1].color = Color.blue;  
        mat4[1].color = Color.blue;  
        mat5[1].color = Color.blue;  
    }
if(PlayerPrefs.GetInt("RimColor") == 6)
    {
        mat2[1].color = Color.black;  
        mat3[1].color = Color.black;  
        mat4[1].color = Color.black;  
        mat5[1].color = Color.black; 
    }


if(PlayerPrefs.GetInt("TintColor") == 1)
    {
        mat[4].color = Color.white; 
    }
if(PlayerPrefs.GetInt("TintColor") == 2)
    {
        mat[4].color = Color.grey; 
    }
if(PlayerPrefs.GetInt("TintColor") == 3)
    {
        mat[4].color = Color.black;
    }


        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score : " + highScore;

        if(highScore > 50){
                locks[0].SetActive(false);
                locks[1].SetActive(false);
                locks[2].SetActive(false);
                locks[3].SetActive(false);
        }
        
        if(highScore > 100){
                locks[4].SetActive(false);
                locks[5].SetActive(false);
                locks[6].SetActive(false);
                locks[7].SetActive(false);
        }
        
        if(highScore > 200){
                locks[8].SetActive(false);
                locks[9].SetActive(false);
                locks[10].SetActive(false);
                locks[11].SetActive(false);
        }
        if(highScore > 300){
                locks[12].SetActive(false);
                locks[13].SetActive(false);
                locks[14].SetActive(false);
                locks[15].SetActive(false);
        }
        if(highScore > 400){
                locks[16].SetActive(false);
                locks[17].SetActive(false);
                locks[18].SetActive(false);
                locks[19].SetActive(false);
        }
        
        // if(highScore > 100){
        //     mat[1].color = Color.blue;
        // }
        // if(highScore > 150){
        //     mat[0].color = Color.black;
        // }


    }

    // Update is called once per frame
    void Update()
    {
        // if(!gameStarted)
        // {
        //     if(Input.GetMouseButtonDown(0))
        //     {
        //         gameStart();
        //     }
        // }
    }

    public void gameStart()
    {

        gameStarted=true;
        platformSpawner.SetActive(true);
        gamePlayUI.SetActive(true);
        menuUI.SetActive(false);
        audioSource.clip = gameAudio[1];
        audioSource.Play();

        StartCoroutine("updateScore");
    }

    public void gameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("updateScore");
        saveHighScore();
        // AdsManager.instance.ShowAd();

    

        //AdsManager.instance.ShowRewardedAd();


        if(adCounter >= 6)
        {
            adCounter = 0;
            PlayerPrefs.SetInt("AdCount",0);

            AdsManager.instance.ShowRewardedAd();
        }
        else
        {
            Invoke("reloadLevel",1f);
        }

    }

    public void reloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator updateScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            
            score--;

            scoreText.text = score.ToString(); 
    
            //print(score);

            //      if(score>10)
            // {
            //     mat[0].color = Color.cyan;
            // }
        }

    }

    public void collectFood()
    {
        audioSource.PlayOneShot(gameAudio[2], 0.8f); //(which audio, 20% volume)
        score += 10;
    }
   
    public void giveFood()
    {
        audioSource.PlayOneShot(gameAudio[3], 0.5f); //(which audio, 20% volume)
        score += 50;

    }
   
    public void deductScore()
    {
        audioSource.PlayOneShot(gameAudio[4], 0.3f); //(which audio, 20% volume)
        score -= 20;
    }
    public void bonusScore()
    {
        audioSource.PlayOneShot(gameAudio[3], 0.5f); //(which audio, 20% volume)
        score += 100;
    }

void saveHighScore()
{
    if(PlayerPrefs.HasKey("HighScore"))
    {
        //We have a high score
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",score);
            PlayerPrefs.Save();
        }
    }
    else
    {
        //Playing for the first time
        PlayerPrefs.SetInt("HighScore",score);
        PlayerPrefs.Save();
    }
}


public void openSkinPanel()
{
    skinPanel.SetActive(true);
}
public void closeSkinPanel()
{
    skinPanel.SetActive(false);
}


public void changeBodyColorGrey()
{
   mat[1].color = Color.grey;  
   PlayerPrefs.SetInt("BodyColor",1);
}
public void changeBodyColorYellow()
{
   mat[1].color = Color.yellow;  
   PlayerPrefs.SetInt("BodyColor",2);
}
public void changeBodyColorGreen()
{
   mat[1].color = Color.green;  
   PlayerPrefs.SetInt("BodyColor",3);
}
public void changeBodyColorRed()
{
    mat[1].color = Color.red;  
    PlayerPrefs.SetInt("BodyColor",4);
}
public void changeBodyColorBlue()
{
   mat[1].color = Color.blue;  
   PlayerPrefs.SetInt("BodyColor",5);
}
public void changeBodyColorBlack()
{
   mat[1].color = Color.black;  
   PlayerPrefs.SetInt("BodyColor",6);
}


public void changeTrimColorGrey()
{
   mat[0].color = Color.grey;  
   PlayerPrefs.SetInt("TrimColor",1);
}
public void changeTrimColorYellow()
{
   mat[0].color = Color.yellow;  
   PlayerPrefs.SetInt("TrimColor",2);
}
public void changeTrimColorGreen()
{
   mat[0].color = Color.green;  
   PlayerPrefs.SetInt("TrimColor",3);
}
public void changeTrimColorRed()
{
   mat[0].color = Color.red;  
   PlayerPrefs.SetInt("TrimColor",4);
}
public void changeTrimColorBlue()
{
   mat[0].color = Color.blue;  
   PlayerPrefs.SetInt("TrimColor",5);
}
public void changeTrimColorBlack()
{
   mat[0].color = Color.black;  
   PlayerPrefs.SetInt("TrimColor",6);
}


public void changeRimColorGrey()
{
   mat2[1].color = Color.white;  
   mat3[1].color = Color.white;  
   mat4[1].color = Color.white;  
   mat5[1].color = Color.white;  
   PlayerPrefs.SetInt("RimColor",1);
}
public void changeRimColorYellow()
{
   mat2[1].color = Color.yellow;  
   mat3[1].color = Color.yellow;  
   mat4[1].color = Color.yellow;  
   mat5[1].color = Color.yellow;  
    PlayerPrefs.SetInt("RimColor",2);   
}
public void changeRimColorGreen()
{
   mat2[1].color = Color.green;  
   mat3[1].color = Color.green;  
   mat4[1].color = Color.green;  
   mat5[1].color = Color.green;  
     PlayerPrefs.SetInt("RimColor",3);
}
public void changeRimColorRed()
{
   mat2[1].color = Color.red;  
   mat3[1].color = Color.red;  
   mat4[1].color = Color.red;  
   mat5[1].color = Color.red;  
     PlayerPrefs.SetInt("RimColor",4);

}
public void changeRimColorBlue()
{
   mat2[1].color = Color.blue;  
   mat3[1].color = Color.blue;  
   mat4[1].color = Color.blue;  
   mat5[1].color = Color.blue;  
     PlayerPrefs.SetInt("RimColor",5);
}
public void changeRimColorBlack()
{
   mat2[1].color = Color.black;  
   mat3[1].color = Color.black;  
   mat4[1].color = Color.black;  
   mat5[1].color = Color.black;  
     PlayerPrefs.SetInt("RimColor",6);
}


public void changeTintShade1()
{
   mat[4].color = Color.white;  
      PlayerPrefs.SetInt("TintColor",1);
}
public void changeTintShade2()
{
   mat[4].color = Color.grey;  
      PlayerPrefs.SetInt("TintColor",2);
}
public void changeTintShade3()
{
   mat[4].color = Color.black;  
      PlayerPrefs.SetInt("TintColor",3);
}

void CheckAdCount()
{
    if(PlayerPrefs.HasKey("AdCount"))
    {
        adCounter = PlayerPrefs.GetInt("AdCount");
        adCounter++;

        PlayerPrefs.SetInt("AdCount",adCounter);
    }
    else
    {
        PlayerPrefs.SetInt("AdCount",0);
    }
}

// public void unlockSkinOnClick()
// {
//     if(highScore > 50){
//         lockOverlay.SetActive(false);
// }
// }


}