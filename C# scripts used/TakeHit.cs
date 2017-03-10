using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class TakeHit : MonoBehaviour {

    public int lifeTotal;

    public GUIText playerHearts;

	// Use this for initialization
	void Start () {
        lifeTotal = 3;
        Update();
	}
	
    void OnTriggerCollider2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            lifeTotal -= 1;
            Update();
            if(lifeTotal <= 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        playerHearts.text = "Health: " + lifeTotal.ToString();
	}
}
