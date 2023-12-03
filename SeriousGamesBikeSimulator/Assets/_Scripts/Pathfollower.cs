using System;
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
    public Camera cam;


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
                        


                        if (PathNode[CurrentNode].GetComponent<Node>().ThrowNewspaper)
                        {
                            PathNode[CurrentNode].transform.GetChild(1).gameObject.SetActive(true);
                            cam.transform.LookAt(PathNode[CurrentNode].transform.GetChild(1));

                            if (Input.GetMouseButtonDown(0))
                            {
                                PathNode[CurrentNode].transform.GetChild(1).GetComponent<Rigidbody>().velocity = PathNode[CurrentNode].transform.GetChild(1).transform.up * 25;

                                Coroutine coroutine = StartCoroutine(WaitForNewspaper());
                                PathNode[CurrentNode].ThrowNewspaper = false;
                                cam.transform.LookAt(PathNode[CurrentNode + 1].transform);
                            }


                        }

                        if (!PathNode[CurrentNode].GetComponent<Node>().ThrowNewspaper)
                        {
                            PathNode[CurrentNode].GetComponent<Node>().hasQuiz = false;
                            CurrentNode++;
                            CheckNode();
                        }

                    }







                    
                }
                else
                {
                    if (PathNode[CurrentNode].GetComponent<Node>().ThrowNewspaper)
                    {
                        PathNode[CurrentNode].transform.GetChild(0).gameObject.SetActive(true);
                        cam.transform.LookAt(PathNode[CurrentNode].transform.GetChild(0));

                        if (Input.GetMouseButtonDown(0))
                        {
                            PathNode[CurrentNode].transform.GetChild(0).GetComponent<Rigidbody>().velocity = PathNode[CurrentNode].transform.GetChild(0).transform.forward * 50;

                            Coroutine coroutine = StartCoroutine(WaitForNewspaper());
                            PathNode[CurrentNode].ThrowNewspaper = false;
                            cam.transform.LookAt(PathNode[CurrentNode+1].transform);
                        }


                    }

                    if (!PathNode[CurrentNode].GetComponent<Node>().ThrowNewspaper && !PathNode[CurrentNode].GetComponent<Node>().hasQuiz)
                    {
                        CurrentNode++;
                        CheckNode();
                    }
                }


            }

        }
    }

    IEnumerator WaitForNewspaper()
    {

        yield return new WaitForSeconds(15f);
    }
}
