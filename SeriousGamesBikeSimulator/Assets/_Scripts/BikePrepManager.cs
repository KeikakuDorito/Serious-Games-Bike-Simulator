using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BikePrepManager : MonoBehaviour
{

    public static BikePrepManager instance;

    public bool helmetWorn = false;
    public bool tiresPumped = false;
    public bool brakesChecked = false;
    public bool chainReplaced = false;

    [SerializeField]
    GameObject helmetUI;
    [SerializeField]
    GameObject tireUI;
    [SerializeField]
    GameObject brakeUI;
    [SerializeField]
    GameObject chainUI;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (helmetWorn)
        {
            helmetUI.GetComponent<TextMeshProUGUI>().text = "<s>" + helmetUI.GetComponent<TextMeshProUGUI>().text + "</s>";
        }

        if (tiresPumped)
        {
            tireUI.GetComponent<TextMeshProUGUI>().text = "<s>" + tireUI.GetComponent<TextMeshProUGUI>().text + "</s>";
        }

        if (brakesChecked)
        {
            brakeUI.GetComponent<TextMeshProUGUI>().text = "<s>" + brakeUI.GetComponent<TextMeshProUGUI>().text + "</s>";
        }

        if (chainReplaced)
        {
            chainUI.GetComponent<TextMeshProUGUI>().text = "<s>" + chainUI.GetComponent<TextMeshProUGUI>().text + "</s>";
        }


        if (helmetWorn && tiresPumped && brakesChecked && chainReplaced)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }
    }
}
