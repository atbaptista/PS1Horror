using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keeps track of player's items and handles inventory UI
//also handles certain actions that players can do with items (picking up, dropping)
public class Inventory : MonoBehaviour
{
    [Header("UI")]
    public Transform[] slotLocations;
    public GameObject[] stands;

    [Header("Stand Materials")]
    public Material selectedMaterial;
    public Material deselectedMaterial;

    [Header("Inventory")]
    public int inventorySize = 3;

    [Header("Dropping Item")]
    public LayerMask groundMask;

    private GameObject[] _inventory;
    private int _currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = new GameObject[inventorySize];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //places item in inventory, this function is called from playercontroller script
    public void PickupItem(GameObject item){
        for(int i = 0; i < _inventory.Length; i++){
            if(_inventory[i] == null){
                _inventory[i] = item;
                _inventory[i].transform.position = slotLocations[i].position;

                //set current selected to item just picked up
                SelectItem(i + 1);
                break;
            }
        }
    }

    //takes in 1-3 as input, sets current selected item, and switches materials of objects in stands array
    //this function is called from playercontroller script
    public void SelectItem(int num){
        for(int i = 0; i < _inventory.Length; i++){
            if(i != num-1){
                stands[i].GetComponent<MeshRenderer>().material = deselectedMaterial;
            }
        }
        _currentIndex = num - 1;
        stands[_currentIndex].GetComponent<MeshRenderer>().material = selectedMaterial;
    }

    //this function is called from playercontroller script
    public void DropItem(){
        if(_inventory[_currentIndex] == null){
            Debug.Log("slot empty, cant drop null");
            return;
        }

        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, 50f, groundMask))
        {
            Debug.Log("dropping item ray didnt hit anything");
            return;
        }
        // our Ray intersected a collider

        //move item to floor, deselect current stand, put item on ground and call it's grounding function
        _inventory[_currentIndex].transform.position = hit.point;
        stands[_currentIndex].GetComponent<MeshRenderer>().material = deselectedMaterial;
        _inventory[_currentIndex].GetComponent<Item>().Ground();

        //set inventory item to null
        _inventory[_currentIndex] = null;
    }

    //removes current item from inventory and returns it
    public GameObject RemoveCurrentSelected(){
        if(_inventory[_currentIndex] == null){
            Debug.Log("slot empty, cant remove null");
            return null;
        }
        //deselect current stand
        stands[_currentIndex].GetComponent<MeshRenderer>().material = deselectedMaterial;
        GameObject temp = _inventory[_currentIndex];
        //set inventory item to null
        _inventory[_currentIndex] = null;

        return temp;
    }

    public bool Contains(GameObject item){
        foreach(GameObject i in _inventory){
            if (item.Equals(i)){
                return true;
            }
        }
        return false;
    }
}
