using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // 사운드 상태
    enum State { NONE, IDLE, PLAYING, SILENT };


    // 
    State BGMState = State.NONE;
    State SEState = State.NONE;

    // 배경음 처리를 위한 오디오 소스
    AudioSource Audio_BGM = new AudioSource();
    // 효과음 처리를 위한 오디오 소스
    AudioSource Audio_SE = new AudioSource();

	// Use this for initialization
	void Start () {
        BGMState = State.IDLE;
        SEState = State.IDLE;
        Audio_BGM.loop = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

    // 배경음
    void setBGMclip(AudioClip clip)
    {
        Audio_BGM.Stop();
        Audio_BGM.clip = clip;
    }

    public void playBGM (AudioClip clip)
    {
        switch (BGMState)
        {
            case State.IDLE:
            case State.PLAYING:
                Audio_BGM.Play();
                BGMState = State.PLAYING;
                break;
        }
    }

    public void stopBGM()
    {
        Audio_BGM.Stop();
        //BGMState = State.NONE;
        BGMState = State.IDLE;
    }

    public void BGM_Off()
    {
        stopBGM();
        BGMState = State.SILENT;
    }

    public void BGM_On()
    {
        BGMState = State.IDLE;
        if(Audio_BGM.clip != null)
            Audio_BGM.Play();
    }

    // 효과음
    public void PlaySE (AudioClip clip)
    {
        switch (SEState)
        {
            case State.IDLE:
                Audio_SE.PlayOneShot(clip);
                break;
        }
    }

    public void stopSE()
    {
        Audio_SE.Stop();
        //SEState = State.NONE;
        SEState = State.IDLE;
    }

    public void SE_Off()
    {
        stopSE();
        SEState = State.SILENT;
    }

    public void SE_On()
    {
        SEState = State.IDLE;
    }

    // 진동
    public void Vibrate_On()
    {

    }

    public void Vibrate_Off()
    {

    }
}
