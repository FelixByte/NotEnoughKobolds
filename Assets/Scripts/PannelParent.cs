using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelParent : MonoBehaviour
{

    public Transform pannelParent;

    public void SetMenu(int newPannel){
        pannelParent.localPosition = new Vector2 (newPannel * 1100f, 0f);
    }

}
