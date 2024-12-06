using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class RuntimeNavMesh : MonoBehaviour
{
    [SerializeField] GameObject levelSection;
    NavMeshSurface surface;
    // Start is called before the first frame update
    //Generate our level, 5x5 grid using planes
    void Start()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                Instantiate(levelSection, new Vector3(x*10, 0, z*10), Quaternion.identity, this.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
