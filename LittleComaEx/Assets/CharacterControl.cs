using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    enum State { None, Idle, Run, MovePosition};
    State state = State.Idle;
    const float LeftPosition = -1.8f, CenterPosition = 0.0f, RightPosition = 1.8f;
    Vector3 movepoint;
         
    Transform playerTransform;
    
	// Use this for initialization
	void Start () {
        state = State.Run;
        playerTransform = this.gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetMoveDirection(string point)
    {
        switch (state)
        {
            case State.Run:
                state = State.MovePosition;
                switch (point)
                {
                    case "Left": movepoint = new Vector3(LeftPosition, 0, 0); break;
                    case "Center": movepoint = new Vector3(CenterPosition, 0, 0); break;
                    case "Right": movepoint = new Vector3(RightPosition, 0, 0); break;
                }
                StartCoroutine("MoveCharacter");
                break;
        }
        
    }

    IEnumerator MoveCharacter()
    {
        print("MoveCharacter");
        float positionX = playerTransform.position.x;
        float temp = 0.0f;

        while (temp < 1.0f)
        {
            playerTransform.position = Vector3.Lerp(playerTransform.position, movepoint, temp);
            yield return new WaitForSeconds(0.01f);
            temp += 0.01f;
        }
        state = State.Run;
    }

}
