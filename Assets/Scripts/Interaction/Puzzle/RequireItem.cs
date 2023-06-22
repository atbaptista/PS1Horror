using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//implement interactable so player can activate puzzle
//different puzzles will inherit this class and have different reactions to solving and failing the puzzle
public abstract class RequireItem : MonoBehaviour, Interactable
{
    public GameObject itemRequired;
    //protected bool _isFilled = false; //bool for if the puzzle currently has an item in it

    //check if player inventory contains certain gameobject
    public void Interact(GameObject Player)
    {
        Debug.Log("Interact with puzzle");
        
        //check if the item was the correct item
        if(Player.GetComponent<Inventory>().Contains(itemRequired)){
            PuzzleSolved(Player);
        }
        else{
            PuzzleFailed(Player);
        }
    }

    public abstract void PuzzleSolved(GameObject Player);
    public abstract void PuzzleFailed(GameObject Player);
}
