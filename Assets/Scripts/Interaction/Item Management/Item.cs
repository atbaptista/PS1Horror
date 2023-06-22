using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//implements the interactable interface so that item can be picked up
//to make a gameobject an item, add a collider to it and change its layer to the interactable layer
public class Item : MonoBehaviour, Interactable
{
    //placing object on floor places it half in ground, this code fixes that
    public void Ground(){
        RaycastHit hit;
        float dist = 0.0f;
        if(Physics.Raycast(transform.position, Vector3.down, out hit)) {
            dist = hit.distance;
            transform.position = new Vector3(transform.position.x, transform.position.y + dist/2, transform.position.z);
        }
    }

    public void Interact(GameObject Player)
    {
        Player.GetComponent<Inventory>().PickupItem(this.gameObject);
    }
}
