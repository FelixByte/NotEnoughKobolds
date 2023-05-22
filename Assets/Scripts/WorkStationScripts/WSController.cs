using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSController : MonoBehaviour
{
    // uses this to make the thing
    public ReasourceController rControler;

    // units needed to make the thing
    public List<KoboldObject> kWorkers = new List<KoboldObject>();
    public int[] workingKobolds;

    // checks if has enough workers
    public bool hasWorkers;

    // the thing to make
    public int rToMake, tToMake;

    void Awake(){
        workingKobolds = new int[kWorkers.Count];
    }

    void Update(){
        if (hasWorkers){
            
        }
    }

    public void ChangeWorkers(int kWorkers, int amount){
        
    }

    bool CheckWorkers(){
        for (int i = 0; i < workingKobolds.Length; i++){
            if (workingKobolds[i] > 0){
                return(true);
            }
        }
        return(false);
    }

}
