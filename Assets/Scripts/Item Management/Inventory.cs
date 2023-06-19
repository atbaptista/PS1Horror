using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform[] slotLocations;
    public GameObject[] inventory;
    public GameObject[] stands;
    public int inventorySize = 3;
    public Material selectedMaterial;
    public Material deselectedMaterial;

    private GameObject _currentSelected;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new GameObject[inventorySize];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //places item in inventory
    public void PickupItem(RaycastHit hit){
        for(int i = 0; i < inventory.Length; i++){
            if(inventory[i] == null){
                inventory[i] = hit.collider.gameObject;
                inventory[i].transform.position = slotLocations[i].position;

                //set current selected to item just picked up
                SelectItem(i + 1);
                break;
            }
        }
    }

    //takes in input 1-3, sets current selected item to index of stands array
    public void SelectItem(int num){
        if(_currentSelected){
            _currentSelected.GetComponent<MeshRenderer>().material = deselectedMaterial;
        }
        _currentSelected = stands[num-1];
        _currentSelected.GetComponent<MeshRenderer>().material = selectedMaterial;
    }
}
