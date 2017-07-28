using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{

    // 캐릭터의 Transform 변수
    Transform playerTransform;
    // 캐릭터의 상태 표시를 위한 열거형 데이터
    enum State { None, Idle, Run, ChangeDirection, MoveDirection };
    // 현재 캐릭터의 행동 상태
    State state = State.Idle;
    // 캐릭터가 이동할 좌표 정리
    // float LeftPosition = -1.5f, CenterPosition = 0.0f, RightPosition = 1.5f;
    // 캐릭터 이동 제한
    float limitPosition_Left, limitPosition_Right;
    // 캐릭터의 기본 좌표
    float PlayerPositionY, PlayerPositionZ;
    // 현재 캐릭터가 이동해야할 좌표를 저장할 변수
    Vector3 movePosition;
    // 사운드 매니저
    SoundManager soundManager;

    // 캐릭터 움직이는 속도 조절
    public float moveSpeed;

    // 캐릭터 컨트롤러 연결
    Button bt_Left, bt_Right;

    // 효과음
    // 피격 효과음
    public AudioClip SE_OnDamage;
    // 이동 효과음
    public AudioClip SE_OnChangeDirection;

    // 캐릭터 HP
    // 캐릭터의 최대 HP
    const float MaxHitPoint = 50.0f;
    // 현재 캐릭터의 HP
    float hitPoint;

    // ?? 뭐지
    public int gook = 1;

    public float HitPoint
    {
        get
        { return hitPoint; }

        set
        { }
    }

    // Use this for initialization
    void Start()
    {
        characterDataReset();
        state = State.Run;
        playerTransform = this.gameObject.transform;
        PlayerPositionY = playerTransform.position.y;
        PlayerPositionZ = playerTransform.position.z;
        soundManager = SoundManager._instence;
        movePosition = playerTransform.position;
        bt_Left = GameObject.Find("Bt_Left").GetComponent<Button>();
        bt_Right = GameObject.Find("Bt_Right").GetComponent<Button>();
        limitPosition_Left = 0.0f - (Camera.main.aspect * Camera.main.orthographicSize - 0.6f);
        limitPosition_Right = Camera.main.aspect * Camera.main.orthographicSize - 0.6f;
    }

    // 캐릭터의 상태 초기화
    void characterDataReset()
    {
        hitPoint = MaxHitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        print("HP : " + hitPoint);
    }


    public IEnumerator moveCharacter(string direction)
    {
        print("Start Move Character");
        state = State.MoveDirection;
        soundManager.PlaySE(SE_OnChangeDirection);
        
        switch (direction)
        {
            case "Left":
                while (state == State.MoveDirection)
                {
                    if (playerTransform.position.x > limitPosition_Left)
                        playerTransform.position = new Vector3(playerTransform.position.x - moveSpeed, PlayerPositionY, PlayerPositionZ);
                    yield return new WaitForFixedUpdate();
                }
                break;
            case "Right":
                print("Move to right");
                while (state == State.MoveDirection)
                {
                    print("moving");
                    if (playerTransform.position.x < limitPosition_Right)
                        playerTransform.position = new Vector3(playerTransform.position.x + moveSpeed, PlayerPositionY, PlayerPositionZ);
                    print("move position: " + playerTransform.position.x);
                    yield return new WaitForFixedUpdate();
                }
                break;
        }
    }

    public void stopCharacter()
    {
        state = State.Idle;
    }

    /*
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
        // 효과음
        soundManager.PlaySE(SE_OnChangeDirection);

        // 이동을 위한 변수
        float positionX = playerTransform.position.x;
        float temp = 0.0f;
        // 이동
        while (temp < 1.0f)
        {
            playerTransform.position = Vector3.Lerp(playerTransform.position, movepoint, temp);
            yield return new WaitForSeconds(0.01f);
            temp += 0.02f;
        }
        state = State.Run;
    }
    */

    // 충돌
    void OnDamage(object[] data)
    {
        
        //효과음
        soundManager.PlaySE(SE_OnDamage);

        // HP값 수정
        hitPoint -= (float) data[1];

        // 장애물 삭제
        GameObject.Destroy(data[0] as GameObject);

        // 캐릭터 사망
        if (hitPoint <= 0)
        {
            dead();
        }
    }

    // 사망 처리
    void dead()
    {

    }

    // 충돌된 장애물 삭제
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstruction")
            GameObject.Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstruction")
            GameObject.Destroy(other.gameObject);
    }
}
