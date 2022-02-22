using System.Threading;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 40f;

    [SerializeField]
    private float headshot = 4f;

    public Camera playerCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
            Thread.Sleep(100);
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            
        }

    }
}
