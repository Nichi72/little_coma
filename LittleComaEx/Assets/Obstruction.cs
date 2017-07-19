using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;
/*
 *  질문사항
 *  방해물 크기에 대해 이해가 잘 안간다.


    알아가는것-
    상속 관계에서 public 안한 것들은 상속을 해주지 않음 
     
    클래스의 생성자 -> 파생 클래스의 생성자 -> 파생 클래스의 소멸자 -> 기반 클래스의 소멸자

    base 키워드로 super 객체 접근 가능함 

    struck은 선언만으로도 생성이 가능하나
    class는 new 연산자와 생성자가 필요함 

 * */


public class Obstruction : MonoBehaviour
{
    obstruction_mng obManager;

    void Start()
    {
        obManager = new obstruction_mng();
        Debug.Log("!@#$%^&*()!축하합니다!@#$%^&*(");
        StartCoroutine(obManager.setting_states());
        obManager.Test();

        //StartCoroutine(setting_states());

    }
   
}


