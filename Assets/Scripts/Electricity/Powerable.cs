using UnityEngine;

//objects part of the electrical system should implement this
//ES_Lights.cs is an example of how it is implemented
public interface Powerable
{
    void TurnOn();  
    void TurnOff();
    //returns whether the object is turned on or off
    bool isOn();
    int EnergyToReturn();
}