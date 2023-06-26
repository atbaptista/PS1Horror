using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES_BreakerBox : MonoBehaviour
{
    [Header("Energy Management")]
    public int totalEnergy;                
    public int energyLeft;                      //set to how much energy is left
    
    [Header("Indicator Stuff")]
    public GameObject[] energyIndicators;       //set energy indicators to the energy cell things in the breaker box
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

    public bool UsePower(int cost){
        if(energyLeft-cost < 0){ //no energy left
            return false;
        }
        else{
            //energyLeft gives the index 
            for(int i = 0; i < cost; i ++){
                energyIndicators[energyLeft-1].GetComponent<MeshRenderer>().material = indicatorUnpowered;
                energyLeft -= 1;
            }
            return true;
        }
    }

    public void ReturnPower(int numPowerToReturn){
        for(int i = 0; i < numPowerToReturn; i++){
            energyLeft += 1;
            energyIndicators[energyLeft-1].GetComponent<MeshRenderer>().material = indicatorPowered;
        }
    }
}
