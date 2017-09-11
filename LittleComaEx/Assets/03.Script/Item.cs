using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    /// <summary>
    /// 이 스크립트에서는 관련 스크립트에 메시지를 전송해 해당 메소드를 부르는 역할입니다.
    /// 때문에 아이템 관련하여 문제가 발생하면 해당 스크립트에 문제가 있을 수도 있습니다.
    /// </summary>
    /// 

    // 외부에서 아이템 효과 설정해주는 방식
    public enum EFFECT { NONE, SHIELD, RECUVERY, SPEEDCHANGE, CLEAROBSTRUCTION}
    public EFFECT item_effect = EFFECT.NONE;

    GameMng gameManager;
    CharacterControl characterControl;
    UVScroller background;

	// Use this for initialization
    /// 연결된 스크립트 종류
    /// 게임 메니저: 장애물 관련하여 동작시 필요 
    /// 캐릭터 컨트롤: 캐릭터 관련하여 동작시 필요
    /// 배경이미지 컨트롤: 속도 관련하여 동작시 필요
	void Start () {
        gameManager = GameMng.Instance;
        characterControl = CharacterControl.Instence;
        background = UVScroller.Instence;
        GetComponent<Rigidbody>().AddForce(Vector3.down*100);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	// 속성으로 아이템의 효과 설정하게 하고싶다...

	// 방어막 효과
    void shield(float timeLimit)
    {
        characterControl.SendMessage("effect_Shield", timeLimit);
    }

	// HP회복
    void recuvery(float recuveryPoint)
    {
        characterControl.SendMessage("effect_Recovery", recuveryPoint);
    }

	// 스피드 변경
    void change_Speed()
    {
        characterControl.SendMessage("setMoveSpeed", 7.0f);
        background.SendMessage("setMoveSpeed", 7.0f);
    }

	// 장애물 제거
    void clearObstruction()
    {
        gameManager.SendMessage("clearObstruction");
    }

    // 캐릭터와 충돌시 효과를 분류하여 작동하도록 만들었습니다.
    /*
    void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "Player") 
		{
			switch (item_effect) 
			{
			case EFFECT.SHIELD:
				shield(2.0f); break;
			case EFFECT.RECUVERY:
				recuvery(5.0f);
				break;
			case EFFECT.SPEEDCHANGE:
				change_Speed();
				break;
			case EFFECT.CLEAROBSTRUCTION:
				clearObstruction();
				break;
			}
		}
        gameManager.SendMessage("Destroy_Item", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }
    */
    // 캐릭터와 충돌시 효과를 분류하여 작동하도록 만들었습니다.
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            switch (item_effect)
            {
                case EFFECT.SHIELD:
                    shield(2.0f); break;
                case EFFECT.RECUVERY:
                    recuvery(5.0f); break;
                case EFFECT.SPEEDCHANGE:
                    change_Speed(); break;
                case EFFECT.CLEAROBSTRUCTION:
                    clearObstruction(); break;
            }
            gameManager.SendMessage("Destroy_Item", this.gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }

    // 오브젝트가 화면 밖으로 나간 경우 사라지도록 처리
    void OnBecameInvisible()
    {
        gameManager.SendMessage("Destroy_Item", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }
}
