using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    

    public static Node Instance;


    public bool hasQuiz;
    public bool GoesRight;
    public bool GoesLeft;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
