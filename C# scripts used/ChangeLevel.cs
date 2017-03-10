using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {    
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && gameObject.tag == "End")
        {
            print("Next Level Reached!");                        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else if(other.tag == "Player" && gameObject.tag == "deathArea")
        {
            print("Failed Current Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            return;
        }
    }
}
