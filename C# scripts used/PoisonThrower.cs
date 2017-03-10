using UnityEngine;
using System.Collections;

public class PoisonThrower : MonoBehaviour {

    public GameObject Poison;
    public Transform poisonSpawn;
    public Rigidbody2D poisonRigidBody;
    private float lastShot = 0.0f;
    private float fireRate = 1.5f;
    public int poisonForcex;
    public int poisonForcey;

    // Use this for initialization
    void Start ()
    {
       
}
	
	// Update is called once per frame
	void Update ()
    {
        poisonForcex = -200;
        poisonForcey = 0;
       
        ThrowPoison();
	}

    void ThrowPoison()
    {
        if (Time.time > fireRate + lastShot)
        {
            //isShooting = true;


            //Instantiate a new Clone of a poison GameObject
            GameObject poisonObject = (GameObject)Instantiate(Poison, poisonSpawn.position, poisonSpawn.rotation);
            poisonRigidBody = poisonObject.GetComponent<Rigidbody2D>();
            poisonObject.layer = 12;
            poisonObject.tag = "snowballTag";

            //Add velocity to snowball
            poisonRigidBody.AddForce(new Vector2(poisonForcex, poisonForcey));

            //Reset last shot timer
            lastShot = Time.time;

            //Destroy poisons to prevent world from filling with them
            Destroy(poisonObject, 4.0f);
        }
        else
        {
            return;
        }
    }
}
