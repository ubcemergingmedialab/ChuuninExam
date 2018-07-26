using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class TickerScript : MonoBehaviour {

    public float MAX_X = 0.60f;
    public float MIN_X = 0.08f;
    private float diff;

    public GameObject ticker;
    private VRTK_Control_UnityEvents controlEvents;

    // Use this for initialization
    void Start () {
        Vector3 initial = ticker.transform.position;
        initial.x = MIN_X;
        ticker.transform.position = initial;

        diff = MAX_X - MIN_X;

        controlEvents = GetComponent<VRTK_Control_UnityEvents>();
        if (controlEvents == null)
        {
            controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
        }

        controlEvents.OnValueChanged.AddListener(HandleChange);
    }

    private void HandleChange(object sender, Control3DEventArgs e)
    {
        float toMove = diff * (e.normalizedValue/100);
        Vector3 init = ticker.transform.position;
        init.x = MAX_X - toMove;
        ticker.transform.position = init;
    }
}
