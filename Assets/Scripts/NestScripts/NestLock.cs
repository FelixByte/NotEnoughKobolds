using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NestLock : MonoBehaviour
{

    // needs reasources for unlocking
    public ReasourceController pReasources;

    //the nest this lock is linked too
    public NestController pNest;

    // the lock display
    public TMP_Text unlockText;
    public Image lockImage;
    public Button lockButton;
    public List<int> unlockRequirements = new List<int>();

    void Start(){

        // resets the text
        unlockText.text = "";

        // if no price it's free
        if(unlockRequirements.Count == 0){
            unlockText.text = "Free";
        }

        // runs through every 3 elements and sets the reasource price
        else{
            for (int i = 0; i < unlockRequirements.Count; i += 3){
                unlockText.text += "" + pReasources.reasourceNames[unlockRequirements[i], unlockRequirements[i + 1]] + ": " + unlockRequirements[i + 2] + "\n";
            }
        }
    }

    // checks inf the nest can be unlocked when the lock button is pressed
    public void UnlockNest(){

        // checks for unlock
        pNest.isUnlocked = CheckUnlock();

        // unlocks pannel if true
        if(pNest.isUnlocked){
            lockImage.enabled = false;
            lockButton.gameObject.SetActive(false);
            unlockText.enabled = false;
        }
    }

    // runs through the reasource requirements to see if can unlock
    bool CheckUnlock(){
        // if no requirements it's free
        if(unlockRequirements.Count > 3){
            return(true);
        }

        // runs through every 3 elements to check the price
        else{

            // checks if can buy, if not return false
            for (int i = 0; i < unlockRequirements.Count; i += 3){
                if(pReasources.pReasources[unlockRequirements[i], unlockRequirements[i + 1]] < unlockRequirements[i + 2]){
                    return(false);
                }
            }

            // reduces the reasources based on the price
            for (int i = 0; i < unlockRequirements.Count; i += 3){
                pReasources.pReasources[unlockRequirements[i], unlockRequirements[i + 1]] -= unlockRequirements[i + 2];
            }
            pReasources.UpdateReasources();
            return(true);
        }
    }
}
