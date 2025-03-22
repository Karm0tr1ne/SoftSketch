using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "SkinData",menuName = "ScriptableObject/SkinData",order = 2)]
public class SkinData : ScriptableObject
{
    [Header("Inventory Sprite")]
    [Tooltip("Square Type Sprite")]
    public Sprite Square;
    [FormerlySerializedAs("Interact")] [Tooltip("Interact Type Sprite")]
    public Sprite Swipe;
    [Tooltip("Heater Type Sprite")] 
    public Sprite Heater;
    [Tooltip("Gyro Type Sprite")] 
    public Sprite Gyro;
}
