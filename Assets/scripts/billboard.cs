using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class billboard : MonoBehaviour {

    // Update is called once per frame

    public RectTransform healthbar;

    void Update () {
        healthbar.transform.LookAt(Camera.main.transform);
        //healthbar = GameObject.Find("billboard").GetComponent<RectTransform>();
        //healthbar.transform.LookAt(Camera.main.transform);
	}
}
