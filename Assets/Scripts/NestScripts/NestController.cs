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
    public TMP_Text infoText, statsText;
    

    // the kobold this nest makes
    public KoboldObject selectedKobold;
    public bool canMake;
    public int kNurses;

    void Update(){
        if(isUnlocked && kNurses > 0){
            productionSlider.value += 1 * Time.deltaTime;
        }
    }

}
