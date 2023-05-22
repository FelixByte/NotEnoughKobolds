using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NestController : MonoBehaviour
{

    // used for lock / unlock
    public bool isUnlocked;

    // used to produce units and display the production / unit information
    public Slider productionSlider;
    public TMP_Text infoText, statsText, tPrice;
    

    // the kobold this nest makes
    public KoboldObject selectedKobold;

    // checks if it has the reasources to make
    public List<KoboldObject> neededKobolds;
    public List<int> amountOfKobolds;
    public bool canMake;
    public int kNurses;

    void Awake(){

        // sets the required amount of kobolds needed to create this unit
        neededKobolds = selectedKobold.kNeededKobolds;
        amountOfKobolds = selectedKobold.amountRequired;
        SetPriceText();
    }

    void Update(){

        // checks if you are able to make the kobolds
        if(isUnlocked && canMake && kNurses > 0){

            // adds to production slider
            productionSlider.value += 1 * Time.deltaTime;

            // when the slider is maxed reset and produce 
            if (productionSlider.value >= productionSlider.maxValue){
                productionSlider.value = 0;
                canMake = false;
                selectedKobold.kAmount += kNurses;
            }
        }

        //checks if can make if all else fails
        else if (isUnlocked && !canMake && kNurses > 0){
            canMake = CheckCanMake();
        }
    }

    bool CheckCanMake(){

        // runs through each element and returns false if can't make
        for(int i = 0; i < neededKobolds.Count; i++){
            if(neededKobolds[i].kAmount < (amountOfKobolds[i] * kNurses)){
                return(false);
            }
        }

        // automatically takes away kobolds when can buy and returns true
        for(int i = 0; i < neededKobolds.Count; i++){
            neededKobolds[i].kAmount -= (amountOfKobolds[i] * kNurses);
        }
        return(true);
    }

    void SetPriceText(){
        tPrice.text = "";
        if(neededKobolds.Count < 1){
            tPrice.text = "Free";
        }
        for (int i = 0; i < neededKobolds.Count; i++){
            tPrice.text += "" + neededKobolds[i].kName + ": " + amountOfKobolds[i];
        }
    }

}
