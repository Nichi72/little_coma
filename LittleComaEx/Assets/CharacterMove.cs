using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    CharacterControl characterControl;

    // Use this for initialization
    void Start() {
        characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void SendMassege(string point)
    {
        characterControl.SendMessage("SetMoveDirection", point);
    }
}
