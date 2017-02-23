using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public Light light;
    public bool isPaused = false;
    Rect pauseMenu = new Rect(275,100,150,150);

    private AudioSource[] _audioSources;
    public AudioSource grocerySong;
    public AudioSource shoppingaCart;
	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(this);
        light.intensity = 1.75f;
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this.grocerySong = this._audioSources[0];
        this.shoppingaCart = this._audioSources[1];

	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if(isPaused)
            {
                this.shoppingaCart.Stop();
                Time.timeScale = 0;
                //DoMyWindow(0);
            }
            else
            {
                this.shoppingaCart.Play();
                Time.timeScale = 1;
            }
        }
    }

    void OnGUI()
    {
        if(isPaused)
        {
            pauseMenu = GUI.Window(0, pauseMenu, DoMyWindow, "Pause Menu");
            if (Screen.width == 640 && Screen.height == 480)
            {
                pauseMenu.center = new Vector2(320, 240);
            }
            else if (Screen.width == 800 && Screen.height == 600)
            {
                pauseMenu.center = new Vector2(400, 300);
            }
            else if (Screen.width == 1024 && Screen.height == 768)
            {
                pauseMenu.center = new Vector2(512, 384);
            }
            else if (Screen.width == 1152 && Screen.height == 864)
            {
                pauseMenu.center = new Vector2(576, 432);
            }
            else if (Screen.width == 1280 && Screen.height == 720)
            {
                pauseMenu.center = new Vector2(640, 360);
            }
            else if (Screen.width == 1280 && Screen.height == 800)
            {
                pauseMenu.center = new Vector2(640, 400);
            }
            else if (Screen.width == 1366 && Screen.height == 768)
            {
                pauseMenu.center = new Vector2(683, 384);
            }
            else if (Screen.width == 1600 && Screen.height == 900)
            {
                pauseMenu.center = new Vector2(800, 450);
            }
            else
            {
                pauseMenu.center = new Vector2(100, 100);
            }
        }
    }
    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(25, 40, 100, 20), "Main Menu"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        if (GUI.Button(new Rect(25, 70, 100, 20), "Restart"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
            
        }
        if (GUI.Button(new Rect(25, 100, 100, 20), "Exit"))
        {
            Application.Quit();
        }
    }
}
