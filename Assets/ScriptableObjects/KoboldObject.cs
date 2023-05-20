using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KoboldObject", menuName = "KoboldObject")]
public class KoboldObject : ScriptableObject
{
    // army stats
    public int kAmount, kStrength, kHealth;

    // used for the nest
    public int creationTime;
    public string kName;

    void Start(){
        kAmount = 0;
    }
    
}
