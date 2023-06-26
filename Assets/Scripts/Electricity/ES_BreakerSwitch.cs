using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the gameobject with the breakerbox component needs to be the parent of all the switches
public class ES_BreakerSwitch : MonoBehaviour, Interactable
{
    [HideInInspector] public ES_BreakerBox breakerBox;
    public GameObject poweredObject;

    private Powerable _powerableComponent;

    // Start is called before the first frame update
    void Start()
    {
        breakerBox = GetComponentInParent<ES_BreakerBox>();
        _powerableComponent = poweredObject.GetComponent<Powerable>();
    }

    public void Interact(GameObject Player)
    {
        //switch is on so turn it off
        if(_powerableComponent.isOn()){
            breakerBox.ReturnPower(_powerableComponent.EnergyToReturn());
            _powerableComponent.TurnOff();
        }
        else{ //switch is off so turn it on
            if(breakerBox.UsePower(_powerableComponent.EnergyToReturn())){ //check if theres enough power, this changes the power indicators
                poweredObject.GetComponent<Powerable>().TurnOn();
            }
            else{
                //can play sound effect of switch trying to be clicked and not working or something here
            }
        }
    }
}
