using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//electrical system manager
//to set up the electrical system, create x amount of switches with the ES_BreakerSwitch.cs scriptp, make all switches children of the breaker box
//drag all the energy indicators into the energyIndicator array in the inspector, and select what their materials for being powered/unpowered should be
//implement the Powerable interface in a script and make it the component of an object that can be powered, then connect that object to one of the breaker switches
public class ES_BreakerBox : MonoBehaviour
{
    [Header("Energy Management")]
    public int energyLeft;                                       //set to how much energy is left, prob have to calculate this by hand and input it in unity
    [HideInInspector]public int totalEnergy;                     //this will be set at the start of the game
    
    
    [Header("Indicator Stuff")]
    public GameObject[] energyIndicators;                       //set energy indicators to the energy cell things in the breaker box
    public Material indicatorPowered;
    public Material indicatorUnpowered;
    
    // Start is called before the first frame update
    void Start()
    {
        totalEnergy = energyIndicators.Length;
        
        //set the number of indicators for how much energy is left
        for(int i = 0; i < energyLeft; i++){
            energyIndicators[i].GetComponent<MeshRenderer>().material = indicatorPowered;
        }
    }

    //uses x amount of power, returns true or false depending on whether or not the player can spend that much energy
    public bool UsePower(int cost){
        if(energyLeft-cost < 0){ //no energy left/too expensive
            return false;
        }
        else{
            //energyLeft gives the index + 1
            for(int i = 0; i < cost; i ++){
                energyIndicators[energyLeft-1].GetComponent<MeshRenderer>().material = indicatorUnpowered;
                energyLeft -= 1;
            }
            return true;
        }
    }

    //returns x amount of power to the breaker box and changes teh material
    public void ReturnPower(int numPowerToReturn){
        for(int i = 0; i < numPowerToReturn; i++){
            energyLeft += 1;
            energyIndicators[energyLeft-1].GetComponent<MeshRenderer>().material = indicatorPowered;
        }
    }
}
