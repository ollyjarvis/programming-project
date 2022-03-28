using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 40f;

    [SerializeField]
    private float headshot = 4f;

    public Camera playerCam;
    public GameObject target;

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
        spawnTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            Target target = hit.transform.GetComponentInParent<Target>();
            Transform targetPart = hit.transform;
            if (target != null)
            {
                if (targetPart.name == "Head")
                {
                    target.TakeDamage(damage * headshot);
                }
                else if (targetPart.name == "Body")
                {
                    target.TakeDamage(damage);
                }
            }
        }

    }
        public void spawnTarget()
    {
        GameObject newTarget = Instantiate(target, new Vector3 (Random.Range(-10.0f, 10.0f), 1 ,Random.Range(-10.0f, 10.0f)), Quaternion.identity);
        newTarget.SetActive(!newTarget.activeInHierarchy);
    }
}
