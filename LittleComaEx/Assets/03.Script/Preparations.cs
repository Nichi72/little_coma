using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparations : MonoBehaviour {

    SoundManager soundManager;
    public AudioClip BGM;

    // Use this for initialization
    void Start () {
        print("BGM_Start");
        soundManager = SoundManager._instence;
        soundManager.playBGM(BGM);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
