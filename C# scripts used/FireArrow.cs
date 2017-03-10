using UnityEngine;
using System.Collections;

public class FireArrow : MonoBehaviour {

    
    bool justLaunched;
    //Rigidbody2D archerArrow;
    Rigidbody2D archerArrowBody;
    Object archerArrow;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        FireNewArrow();
        
	}

    void FireNewArrow()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.LeftControl))
        {
            archerArrow = Instantiate(archerArrow, transform.position, transform.rotation);
        }
    }
}
