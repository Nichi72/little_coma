using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;
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

    public GameObject obj;
    public int objCount; // 한 스테이지에 총 방해물 수 제한 
    static int stage=1;
    private static GameMng _instance = null; // 자신의 인스턴스를 만든다. 외부에서 접근 하지 못하게 접근자는 private다

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
        StartCoroutine(obstruction());

    }





    IEnumerator obstruction() // 스테이지 끝날때 stage값을 바꿔줘야함
    {
        float incidence = 0.2f; // 
        switch (stage)
        {
            case 1:
                incidence = 0.2f;
                break;
            case 2:
                incidence = 0.25f;
                break;
            case 3:
                incidence = 0.3f;
                break;
            case 4:
                incidence = 0.3f;
                break;
            case 5:
                incidence = 0.3f;
                break;
            case 6:
                incidence = 0.3f;
                break;
            case 7:
                incidence = 0.45f;
                break;
            case 8:
                incidence = 0.45f;
                break;
        }

        //Vector3 velocity = GetComponent<Rigidbody>().velocity;
        
        while (true) 
        {
            if (objCount < 8)
            {
                Debug.Log("생성 준비");
                transform.position = new Vector3(Random.Range(-5, 5), 8, 0);
                Debug.Log("incidence  = " + incidence);
                if (Random.Range(0f, 1f) < incidence) // 출현률
                {
                    Instantiate(obj, transform.position, transform.rotation);
                    yield return new WaitForSeconds(0.5f); // 생성주기 
                }
                else
                {
                    Debug.Log("생성 안됨");
                    yield return new WaitForSeconds(0.5f);// 생성주기 
                }
            }
            yield return new WaitForSeconds(0.5f);// 생성주기 
        }
        

    }
}
