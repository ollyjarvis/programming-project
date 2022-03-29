using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 40f; //float that stores amount of damage for weapon to do

    [SerializeField]
    private float headshot = 4f; //float that stores multiplier for headshots

    public Camera playerCam; //takes player camera reference 
    public GameObject target; //takes prefab of the target

    public Canvas paused;

    //Start is called once at the start
    void Start()
    {
        for(int i = 0; i < 5; i++) //for loop that spawns 3 targets when the game starts
        {
        spawnTarget(); //runs spawn target function
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //When shoot button is pressed
        {
            Shoot(); //runs shoot function
        }
    }
    void Shoot()
    {
        RaycastHit hit; //defines a Raycast called hit
        if(!paused.gameObject.activeInHierarchy)
        {
            if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit)) //Shoots a raycast in the direction the player 
            //is looking from the players location and returns what the raycast first intersects.
            {
                Target target = hit.transform.GetComponentInParent<Target>(); //stores the "Target.cs" script of the target in a Target variable called target
                Transform targetPart = hit.transform; //stores the part of the part of the target hit in a Transform variable
                if (target != null) //if target is not null then the player hit a target.
                {
                    if (targetPart.name == "Head") //if the name of the target part is "Head"
                    {
                        target.TakeDamage(damage * headshot); //target is dealt damage multiplied by headshot damage
                    }
                    else if (targetPart.name == "Body") //if the name of the target part is "Body"
                    {
                        target.TakeDamage(damage); //target is dealt damage
                    }
                }
            }
        }

    }
        public void spawnTarget()
    {
        GameObject newTarget = Instantiate(target, new Vector3 (Random.Range(-70f, 70f), Random.Range(1f, 10f), Random.Range(-70f, 70f)), Quaternion.identity); //instantiate new target at random point 
        newTarget.SetActive(!newTarget.activeInHierarchy); //set target active
    }
}
