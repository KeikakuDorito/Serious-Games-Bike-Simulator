using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Node : MonoBehaviour
{

    

    //public static Node Instance;


    public bool hasQuiz;
    public bool GoesRight = true;
    public bool GoesLeft;
    public int CorrectAnswer;
    public int ChoiceMade;
    private void Awake()
    {
        //if (!Instance)
        //{
        //    Instance = this;
            
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Option1()
    {
        ChoiceMade = 1;

        if(ChoiceMade != CorrectAnswer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }


    public void Option2()
    {
        ChoiceMade = 2;

        if(ChoiceMade != CorrectAnswer)
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (hasQuiz)
        {

        }
    }
}
