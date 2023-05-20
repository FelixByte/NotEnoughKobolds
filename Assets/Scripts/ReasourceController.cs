using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReasourceController : MonoBehaviour
{

    public TMP_Text rText;

    int rTeirs = 4;
    int rAmounts = 5;

    public int[,] pReasources;
    public string[,] reasourceNames;

    void Awake(){

        pReasources = new int[rTeirs, rAmounts];
        reasourceNames = new string[rTeirs, rAmounts];

        // tier 1
        reasourceNames[0, 0] = "Sticks";
        reasourceNames[0, 1] = "Rocks";
        reasourceNames[0, 2] = "String";
        reasourceNames[0, 3] = "Leather";
        reasourceNames[0, 4] = "Bones";

       
    }

    void Start(){
        pReasources[0, 0] = 200;
        UpdateReasources();
    }

    public void UpdateReasources(){
        rText.text = "";
        for (int i = 0; i < rTeirs; i++){
            for (int j = 0; j < rAmounts; j++){
                rText.text += "" + reasourceNames[i, j] + ": " + pReasources[i, j] + "  ";
            }
            rText.text += "\n";
        }
    }
}
