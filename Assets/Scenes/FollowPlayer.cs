using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject userCapsule;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = userCapsule.transform.position;
        transform.position = userCapsule.transform.position + new Vector3(0, 2, -15); // change from 1st person to 3rd person
    }
}