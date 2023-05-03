using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject obstacle;
    public Quaternion rotationYuh;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 3f, 3f);
        rotationYuh = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90, transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        GameObject projectile = Instantiate(obstacle, gameObject.transform.position, rotationYuh);
        projectile.transform.Rotate(Vector3.forward, 90);
    }
}
