using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour {

    public void RetryLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueAfterIntro()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ControlsScreen()
    {
        SceneManager.LoadScene(9);
    }

    public void CreditsScreen()
    {
        SceneManager.LoadScene(10);
    }

    public void ExitProgram()
    {
        Application.Quit();
    }


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
