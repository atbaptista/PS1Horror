using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this version of RequireItem moves the key item to a set position when the puzzle is solved
//can give player hint in the puzzle failed function if they dont have item?
public class RequireItemMove : RequireItem
{
    //isFilled is a field in the RequireItem class
    //itemRequired is a field in the RequireItem class
    public Transform solvedItemLocation;
    protected GameObject _currentItemInPuzzle;

    public override void PuzzleSolved(GameObject Player)
    {
        Debug.Log("Solved puzzle!");
        PlaceItem(Player);

        //do thing that shows that player solved puzzle
        PuzzleSolvedAction();
    }

    public override void PuzzleFailed(GameObject Player)
    {
        Debug.Log("player doesnt have required item!");
        PlaceItem(Player);
        
        //do thing that shows player didnt solve puzzle
        PuzzleFailedAction();
    }

    //places players current selected item into the puzzle, swaps items when the player 
    public void PlaceItem(GameObject Player){
        //place item that player currently has selected into the slot

        //get current selected item from player, this function also removes it from player inventory
        GameObject currentSelected = Player.GetComponent<Inventory>().RemoveCurrentSelected();
        if(currentSelected == null){ //player not selecting anything
            if(_currentItemInPuzzle != null){ //puzzle filled, pick up item inside puzzle
                Player.GetComponent<Inventory>().PickupItem(_currentItemInPuzzle);
                _currentItemInPuzzle = null;
            }
        }
        else{ //player currently selecting item
            if(_currentItemInPuzzle != null){ //puzzle filled
                //swap items
                Player.GetComponent<Inventory>().PickupItem(_currentItemInPuzzle);
                _currentItemInPuzzle = currentSelected;
                currentSelected.transform.position = solvedItemLocation.position;
            }
            else{ //puzzle empty
                //place currently selected item inside puzzle
                _currentItemInPuzzle = currentSelected;
                currentSelected.transform.position = solvedItemLocation.position;
            }
        }
        
    }

    //can inherit this class and override this method to do different things
    public void PuzzleSolvedAction(){

    }
    //can inherit this class and override this method to do different things
    public void PuzzleFailedAction(){

    }
}
