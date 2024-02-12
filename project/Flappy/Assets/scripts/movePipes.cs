using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePipes : MonoBehaviour
{
    public float lifeTime = 2F;
    public float speed;
    void Update()
    {
        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
        Destroy(gameObject, lifeTime);
    }

}
