using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VolControl : MonoBehaviour {

    private VRTK_Control_UnityEvents controlEvents;

    // Use this for initialization
    void Start()
    {

        controlEvents = GetComponent<VRTK_Control_UnityEvents>();
        if (controlEvents == null)
        {
            controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
        }

        controlEvents.OnValueChanged.AddListener(HandleChange);
    }

    private void HandleChange(object sender, Control3DEventArgs e)
    {
        Audio_Manager.instance.totVol = e.normalizedValue();
    }
}
