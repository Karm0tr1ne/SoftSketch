using UnityEngine;


[CreateAssetMenu(fileName = "SkinData",menuName = "ScriptableObject/SkinData",order = 2)]
public class SkinData : ScriptableObject
{
    [Header("Inventory Sprite")]
    [Tooltip("Square Type Sprite")]
    public Sprite Square;
    [Tooltip("Interact Type Sprite")]
    public Sprite Interact;
    [Tooltip("Heater Type Sprite")] 
    public Sprite Heater;
    [Tooltip("Gyro Type Sprite")] 
    public Sprite Gyro;
}
