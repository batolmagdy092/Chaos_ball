using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GoalScript blueGoal, greenGoal, redGoal, orangeGoal;
    public bool isWinner;

    public float timer = 120f;
    public bool isLoser = false ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            isLoser = true;
            timer = 0f;
        }
        //true, false

        isWinner = blueGoal.isSolved && redGoal.isSolved && orangeGoal.isSolved && greenGoal.isSolved;
         if(isWinner )
        {
            timer = 120f;
        }

    }
    private void OnGUI()
    {
        Rect rect = new Rect(15, 15, 100, 65);

        GUI.Box(rect,  "Timer :" + (int)timer);


        if (isWinner)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0 )
            {
                Rect rectWinner = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 85);
                GUI.Box(rectWinner, "You Winner");

                Rect rect2 = new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 140, 30);
                GUI.Box(rect2, "Go to next level");
                Invoke(nameof(GoToNextLevel), 1f);

            }
            else if (SceneManager.GetActiveScene().buildIndex ==1 )
            {
                Rect rectEnd = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 85);
                GUI.Box(rectEnd, "You End The Game");

                Rect rectEnd2 = new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 140, 30);
                GUI.Box(rectEnd2, "You Winner");
            }


        }
        else if (isLoser)
        {
            Rect rectLoser = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 85);
            GUI.Box(rectLoser, "You Loser");

            Rect rect2 = new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 140, 30);
            GUI.Box(rect2, "Restart");
            Invoke(nameof(RestartTheLevel), 1f);
        }
    }
    void GoToNextLevel()
    {     
        if(SceneManager.GetActiveScene().buildIndex==0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
      
    }

    void RestartTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

