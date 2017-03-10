using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject character;
    private Vector3 offset;
   // private Vector3 update_pos;
 
	// Use this for initialization
	void Start ()
    {
        offset = transform.position - character.transform.position;            
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = character.transform.position + offset;       
        transform.position = new Vector3(character.transform.position.x + offset.x, 0.0f, character.transform.position.z + offset.z);
    } 
    
    void LateUpdate()
    {
        
    }   
}
