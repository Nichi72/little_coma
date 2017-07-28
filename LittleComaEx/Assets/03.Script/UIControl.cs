using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    float MaxHitPoint ,hitPoint;
    Slider UI_HitPoint;
    CharacterControl CharacterData;

	// Use this for initialization
	void Start () {
        //print("UI Start");
        CharacterData = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        UI_HitPoint = GameObject.Find("HitPoint").GetComponent<Slider>();
        StartCoroutine(DrawUI());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DrawUI()
    {
        // CharacterControl 스크립트의 값 초기화가 완료 되길 기다리기 위해 초기 딜레이를 넣어줌
        yield return new WaitForFixedUpdate();
        MaxHitPoint = CharacterData.HitPoint;
        //print("UI 갱신");
        while (true)
        {
            hitPoint = CharacterData.HitPoint;
            // HP가 최대치일 경우 결과값이 0이 나오기 때문에 제외시킴
            if(MaxHitPoint - hitPoint != 0)
                UI_HitPoint.value = 100 * (hitPoint / MaxHitPoint);
            yield return new WaitForFixedUpdate();
        }
    }
}
