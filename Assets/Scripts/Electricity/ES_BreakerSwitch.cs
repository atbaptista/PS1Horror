using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ES_BreakerSwitch : MonoBehaviour, Interactable
{
    public ES_BreakerBox breakerBox;
    public GameObject poweredObject;

    // Start is called before the first frame update
    void Start()
    {
        breakerBox = GetComponentInParent<ES_BreakerBox>();
    }

    public void Interact(GameObject Player)
    {
        //switch is on so turn it off
        if(poweredObject.GetComponent<Powerable>().isOn()){
            breakerBox.ReturnPower(poweredObject.GetComponent<Powerable>().EnergyToReturn());
            poweredObject.GetComponent<Powerable>().TurnOff();
        }
        else{ //switch is off so turn it on
            if(breakerBox.UsePower(poweredObject.GetComponent<Powerable>().EnergyToReturn())){ //check if theres enough power, this changes the power indicators
                poweredObject.GetComponent<Powerable>().TurnOn();
            }
            else{
                //can play sound effect of switch trying to be clicked and not working or something here
            }
        }
    }
}
