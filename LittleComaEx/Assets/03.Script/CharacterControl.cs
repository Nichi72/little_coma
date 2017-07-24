using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    // 캐릭터의 Transform 변수
    Transform playerTransform;
    // 캐릭터의 상태 표시를 위한 열거형 데이터
    enum State { None, Idle, Run, MovePosition};
    // 현재 캐릭터의 행동 상태
    State state = State.Idle;
    // 캐릭터가 이동할 좌표 정리
    float LeftPosition = -1.5f, CenterPosition = 0.0f, RightPosition = 1.5f;
    // 캐릭터의 기본 좌표
    float PlayerPositionY, PlayerPositionZ;
    // 현재 캐릭터가 이동해야할 좌표를 저장할 변수
    Vector3 movepoint;

    // 캐릭터 HP
    // 캐릭터의 최대 HP
    const float MaxHitPoint = 50.0f;
    // 현재 캐릭터의 HP
    float hitPoint;

    public int gook = 1;

    public float HitPoint
    {
        get
        { return hitPoint; }

        set
        { }
    }

    // Use this for initialization
    // 캐릭터의 상태 초기화
    void characterDataReset()
    {
        movepoint = new Vector3(0, 0, 0);
        hitPoint = MaxHitPoint;
    }

	void Start () {
        characterDataReset();
        state = State.Run;
        playerTransform = this.gameObject.transform;
        PlayerPositionY = playerTransform.position.y;
        PlayerPositionZ = playerTransform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetMovePosition(string point)
    {
        print("메시지 도착");
        switch (state)
        {
            case State.Run:
                state = State.MovePosition;
                switch (point)
                {
                    case "Left": movepoint = new Vector3(LeftPosition, PlayerPositionY, PlayerPositionZ); break;
                    case "Center": movepoint = new Vector3(CenterPosition, PlayerPositionY, PlayerPositionZ); break;
                    case "Right": movepoint = new Vector3(RightPosition, PlayerPositionY, PlayerPositionZ); break;
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
            temp += 0.02f;
        }
        state = State.Run;
    }

    // 충돌
    void OnHit(float damage)
    {
        OnDamage(damage);

        // 사망
        if (hitPoint <= 0)
        {
            dead();
        }
    }

    // 데미지 처리
    void OnDamage(float damage)
    {
        hitPoint -= damage;
    }

    // 사망
    void dead()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(collision.gameObject);
    }

}
