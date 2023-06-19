using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GameObject _currentSelected;
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
    public void PickupItem(RaycastHit hit){
        for(int i = 0; i < _inventory.Length; i++){
            if(_inventory[i] == null){
                _inventory[i] = hit.collider.gameObject;
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
}
