using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollower : MonoBehaviour
{
    public Node[] PathNode;
    public GameObject Player;
    public float MoveSpeed = 0.3f;
    float Timer;
    Vector3 CurrentPositionHolder;
    public int CurrentNode;



    // Start is called before the first frame update
    void Start()
    {

        CurrentNode = 0;
        CheckNode();
        Debug.Log("Current Node: " + CurrentNode);
    }

    void CheckNode()
    {
        if (PathNode[CurrentNode].GetComponent<Node>() == null)
        {
            Debug.LogError("Node is null");
        }



        Debug.Log("IT runs");
        if (PathNode[CurrentNode].GetComponent<Node>().GoesRight)
        {
            Player.transform.eulerAngles = new Vector3(0, 90, 0);
            Debug.Log("Rotated");
            Debug.Log("Current Node: " + CurrentNode);
            PathNode[CurrentNode].GetComponent<Node>().GoesRight = false;
        }

        if (PathNode[CurrentNode].GetComponent<Node>().GoesLeft)
        {
            Player.transform.Rotate(0, -90, 0);
            Debug.Log("Rotated");
            PathNode[CurrentNode].GetComponent<Node>().GoesLeft = false;
        }
        Timer = 0;

        if (CurrentNode < PathNode.Length)
        {
            CurrentPositionHolder = PathNode[CurrentNode].transform.position;
        }
        else
        {
            CurrentNode = PathNode.Length - 1;
        }


    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime * MoveSpeed;

        if (CurrentNode < PathNode.Length && Player.transform.position != CurrentPositionHolder)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, CurrentPositionHolder, Timer);
        }
        else
        {
            if (CurrentNode < PathNode.Length - 1)
            {


                if (PathNode[CurrentNode].GetComponent<Node>().hasQuiz)
                {
                    if(Player.transform.position == PathNode[CurrentNode].transform.position)
                    {
                        PathNode[CurrentNode].transform.GetChild(0).gameObject.SetActive(true);
                    }

                    if (PathNode[CurrentNode].GetComponent<Node>().ChoiceMade == PathNode[CurrentNode].GetComponent<Node>().CorrectAnswer)
                    {
                        PathNode[CurrentNode].transform.GetChild(0).gameObject.SetActive(false);
                        PathNode[CurrentNode].GetComponent<Node>().hasQuiz = false;
                        CurrentNode++;
                        CheckNode();

                    }







                    
                }
                else
                {
                    CurrentNode++;
                    CheckNode();
                }


            }

        }
    }

}
