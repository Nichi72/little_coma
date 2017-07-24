﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;
using UnityEngine.SceneManagement;
//using RandomF;


/*
 *  개선 사항 
 *  오브젝트 풀 형식으로 만든다 
 *  
 *  질문사항
 *  생성주기는 얼마나?
 *  
 *  필기-
 *  
 *  방해물과 플레이어의 z축은 0으로 고정한다.
 * 
 * 
 * */
public class GameMng : MonoBehaviour {

    public GameObject [] obj;
    public int objCount; // 한 스테이지에 총 방해물 수 제한 
    static int stage=1;
    public int now_obstruction;               // 현재 쓸 Obstruction_Status의 배열을 랜덤으로 선정
    public int create_obstruction_list;       // Obstruction_Status의 배열에서 사용할 총 갯수 만약 2를 적어두면 4개의 배열중 2개를 쓴다는 의미 
    public Vector3 create_obstruction_position;
    private static GameMng _instance = null;  // 자신의 인스턴스를 만든다. 외부에서 접근 하지 못하게 접근자는 private다

    public static GameMng Instance  // 외부에서 접근 가능한 메소드를 만들어준다. 
    {
        get
        {
            if (_instance == null) // 
                Debug.LogError("싱글턴 == null");
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this; // 내부적 인스턴스에 자기 자신 코드를 넣는다 .
    }
    void Start()
    {
        create_obstruction_list = 2; // Obstruction_Status의 배열에서 사용할 총 갯수 만약 2를 적어두면 4개의 배열중 2개를 쓴다는 의미
                                     //List<int> create_obstruction_list = new List<int>();
                                     //now_obstruction = 7; //
        now_obstruction =Random.Range(4, 8); // 4~7
        StartCoroutine(Create_stage(stage));
        StartCoroutine(Create_obstruction(stage));
    }
    public int RadomF(int min , int max , int [] num )
    {
        
        return 0;
    }
    IEnumerator Create_stage(int stage) // 스테이지 끝날때 stage값을 바꿔줘야함 
    {
        Debug.Log("@@ 씬 바뀌어요!");
        if (stage == GameBalancer.stage_Status[stage].stage_number)
        {
            
             yield return new WaitForSeconds(GameBalancer.stage_Status[stage].stage_length); 
            // yield return new WaitForSeconds(GameBalancer.stage_Status[stage].stage_length); 
            SceneManager.LoadScene("Stage_02");
        }
    }

    IEnumerator Create_obstruction(int stage) // 스테이지 끝날때 stage값을 바꿔줘야함
    {
        if (stage < 0)
        {
            stage = 1;
            Debug.Log("stage 값이 음수 또는 0으로 입력되어 1로 초기화 되었습니다.");
        }
                
        switch (stage)
        {
            case 1:
            case 2:
                create_obstruction_list = 2;
                break;
            case 3:    
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
                create_obstruction_list = 3; // 미정
                break;
        }
       
        while (true) // 원래는 트루였음 
        {
            if (Obstruction_Status.Obstruction_count < GameBalancer.stage_Status[stage].number_restrictions) // [ 총 개수 체크 ] // 현재 방해물 총개수  < 현재 스테이지 방해물 제한수 
            {
                create_obstruction_position = transform.position = new Vector3(Random.Range(-6f, 7f), 8, 0);                           // X축 -5 부터 5 까지 출현
                Debug.Log("@@@create_obstruction_position :: " + create_obstruction_position);
                if (Random.Range(0f, 1f) < GameBalancer.obstruction_status[now_obstruction].incidence) // 현재 선택된 ob 출현률 체크 
                {
                    Debug.Log("now_obstruction: "+now_obstruction);
                    Instantiate(obj[now_obstruction], transform.position, transform.rotation);  // 적 인스턴스 생성 // 오브젝트를 골라내기 위해now_obstruction를 쓰는 것임 
                    Obstruction_Status.Obstruction_count++;                                     // 생성된 적 인스턴스 카운트 +1
                    Debug.Log("현재 총 만들어진 수 :: " + Obstruction_Status.Obstruction_count);
                }
                else
                {
                    Debug.Log("생성 안됨");
                }
            }
            yield return new WaitForSeconds(0.425f);// 생성주기 
            // Test용 //yield return new WaitForSeconds(6f);// 생성주기 
        }
    }
}
