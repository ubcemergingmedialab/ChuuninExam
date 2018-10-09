using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour {
    public static Audio_Manager instance = null;
    public int curFreq = 0; //todo: change based on freqKnob position;
    private int freqStepSize;
    private float volStepSize;
    public int maxFreq = 99;
    private int freqBuf;
    public float totVol = 1.0f; //todo: change based on volKnob position;
    private AudioSource[] songs;
    private int numSongs;
    private AudioSource noise;
    private int[] freqPivots;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        songs = GetComponentsInChildren<AudioSource>();
        noise = GetComponent<AudioSource>();
        numSongs = songs.Length;
        freqStepSize = maxFreq / numSongs;
        freqBuf = freqStepSize / 3;
        freqPivots = new int[numSongs];
        for(int i = 0; i<numSongs; i++)
        {
            freqPivots[i] = (i*freqStepSize);
        }
	}
	
	// Update is called once per frame
	void Update () {
        volStepSize = totVol / freqBuf;
        int i = 0;
        for (int j = 0; j < numSongs; j++){
            int freqToCompare = freqPivots[j];
            int diff = Mathf.Abs(freqToCompare - curFreq);
            if(diff <= freqBuf)
            {
                i++;
                noise.volume = totVol - (diff * volStepSize);
                songs[j].volume = (diff * volStepSize);
            }
            else
            {
                songs[j].volume = 0;
            }
        }
        if(i == 0)
        {
            noise.volume = totVol;
        }

	}
}
