using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //placing object on floor places it half in ground, this code fixes that
    public void Ground(){
        RaycastHit hit;
        float dist = 0.0f;
        if(Physics.Raycast(transform.position, Vector3.down, out hit)) {
            dist = hit.distance;
            transform.position = new Vector3(transform.position.x, transform.position.y + dist/2, transform.position.z);
        }
    }
}
