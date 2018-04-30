using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFinalScore : MonoBehaviour {

    void Update()
    {
        GetComponent<Text>().text = GameObject.Find("GM").GetComponent<GManager>().finalScore;
    }
}
