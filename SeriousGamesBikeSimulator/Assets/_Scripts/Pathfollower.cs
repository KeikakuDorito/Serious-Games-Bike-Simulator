using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollower : MonoBehaviour
{
    public Node [] PathNode;
    public GameObject Player;
    public float MoveSpeed = 0.3f;
    float Timer;
    Vector3 CurrentPositionHolder;
    public  int CurrentNode;
  

    // Start is called before the first frame update
    void Start()
    {
        
        CurrentNode = 0;
        CheckNode();
        Debug.Log("Current Node: " + CurrentNode);
    }

    void CheckNode()
    {
        if(Node.Instance == null)
        {
            Debug.LogError("Node is null");
        }
        if (Node.Instance.hasQuiz)
        {

        }
        else
        {

            Debug.Log("IT runs");
            if (Node.Instance.GoesRight == true)
            {
                Player.transform.eulerAngles = new Vector3(0, 90, 0);
                Debug.Log("Rotated");
                Debug.Log("Current Node: " + CurrentNode);
                Node.Instance.GoesRight = false;
            }
            
            if (Node.Instance.GoesLeft)
            {
                Player.transform.Rotate(0, -90, 0);
                Debug.Log("Rotated");
                Node.Instance.GoesLeft = false;
            }
            Timer = 0;

            if(CurrentNode < PathNode.Length)
            {
                CurrentPositionHolder = PathNode[CurrentNode].transform.position;
            }
            else
            {
                CurrentNode = PathNode.Length - 1;
            }
         
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime * MoveSpeed;
        
        if(CurrentNode < PathNode.Length && Player.transform.position != CurrentPositionHolder)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, CurrentPositionHolder, Timer);
        }
        else
        {
            if (CurrentNode < PathNode.Length - 1 && !Node.Instance.hasQuiz)
            {
               
                CurrentNode++;
                CheckNode();
            }

           
        }
    }

}
