using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add this component to an empty gameobject that contains all the lights to be turned on/off as children
public class ES_Lights : MonoBehaviour, Powerable
{
    public Light[] lights;
    public bool isPowered = true;
    public int energyReturned = 1;

    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponentsInChildren<Light>();
    }

    public void TurnOff()
    {
        isPowered = false;
        foreach(Light i in lights){
            i.enabled = false;
        }
    }

    public void TurnOn()
    {
        isPowered = true;
        foreach(Light i in lights){
            i.enabled = true;
        }
    }

    public bool isOn()
    {
        return isPowered;
    }

    public int EnergyToReturn()
    {
        return energyReturned;
    }
}
