using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button start, instruct;
    public Text instructions, instructions2;
    public bool show = false;
 
	void Start () {
        //instructions.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(show)
        {
            instructions.gameObject.SetActive(true);
        }
        else
        {
            instructions.gameObject.SetActive(false);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void InstructButton()
    {
        show = !show;
    }
}
