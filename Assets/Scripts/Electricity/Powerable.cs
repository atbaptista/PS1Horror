using UnityEngine;

public interface Powerable
{
    void TurnOn();  
    void TurnOff();
    //returns whether the object is turned on or off
    bool isOn();
    int EnergyToReturn();
}