using UnityEngine;
using System.Collections;

public class SnowballThrower : MonoBehaviour {

    public GameObject Snowball;
    public Transform snowballSpawn;
    public Rigidbody2D snowballRigidBody;
    private float lastShot = 0.0f;
    private float fireRate = 0.5f;
    public int snowballForcex;
    public int snowballForcey;

    // Use this for initialization
    void Start ()
    {
       
}
	
	// Update is called once per frame
	void Update ()
    {
        snowballForcex = Random.Range(-300, 300);
        snowballForcey = Random.Range(100, 400);
       
        ThrowSnowball();
	}

    void ThrowSnowball()
    {
        if (Time.time > fireRate + lastShot)
        {
            //isShooting = true;


            //Instantiate a new Clone of a snowball GameObject
            GameObject snowballObject = (GameObject)Instantiate(Snowball, snowballSpawn.position, snowballSpawn.rotation);
            snowballRigidBody = snowballObject.GetComponent<Rigidbody2D>();
            snowballObject.layer = 12;
            snowballObject.tag = "snowballTag";

            //Add velocity to snowball
            snowballRigidBody.AddForce(new Vector2(snowballForcex, snowballForcey));

            //Reset last shot timer
            lastShot = Time.time;

            //Destroy snowballs to prevent world from filling with them
            Destroy(snowballObject, 15.0f);
        }
        else
        {
            return;
        }
    }
}
