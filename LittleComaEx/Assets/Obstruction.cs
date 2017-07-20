using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;


public class Obstruction : MonoBehaviour {
    /*
 *  질문사항
 *  방해물 크기에 대해 이해가 잘 안간다.
 *  
    --문제점 1
    mono를 상속받은 부모 클래스에 virctual 메소드 하나 만들어서 
    자식에게 override 메소드를 만든다.

    그리고 코루틴을 돌려야 하기 때문에 자식 클래스에서 
    Start() 메소드 안에 코루틴을 돌릴려고 하니까
    아예 Start 메소드를 인식하지 못했음

    해결방안 ->  mono를 상속받은 클래스를 부모로 두지 않고
    일반 클래스를 만들고 
    거기에서 상속 및 오버라이딩을 한 후 
    mono 클래스에 보낸다 -> 실패 ( MonoBehaviour를 상속 받지 않

    으면 GetComponet도 못쓰게 되버림 )

    해결방안2 -> 부모 클래스에서 자식클래스의 인스턴스를 만들고
    Start 문에 넣어서 자식 코루틴 메소드를 돌린다.
    -> 실패 ( Null ReferenceEx ) 
    실패요인 분석 ( 부모 클래스에 자식클래스 인스턴스를 만들면 
    당연히 생성 시점이 다르 기 때문에 오류가 난다고 생각

    해결방안 3 -> 
    스크립트 명과 클래스 명이 같아야 Start()문이 작동함 (라고 가

    정했음)
    Ob 체크 스크립트를 만든 뒤에 그 스크립트 안에
    코루틴으로 Ob스크립트 내용을 가지고 오게끔 한다.
    ( 안됨 NullReferenceEx 뜸 )  

    해결방안 4 -> 
    모노 비헤이비어 상속 받은걸 상속 해주면 안되고 
    관련 메소드를 하나 만든 다음
    델리게이트로 핸들링 한다. 

   - 문제점 2
   현재 now_obstruction는 랜덤값으로 초기화 되고있다
   하지만 Random.Range();는 일정함 "범위" 이기 때문에 1, 9 , 10 , 11를 무작위로 섞을수 없다.
   이런 무작위를 어떻게 만들어야 할까

   해결방안1  리턴이 있는 함수에 배열을 넣어서 안에서 인덱스를 이용해 섞은후 그 값을 리턴한다.  


    알아가는것-
    상속 관계에서 public 안한 것들은 상속을 해주지 않음 
     
    클래스의 생성자 -> 파생 클래스의 생성자 -> 파생 클래스의 소멸자 -> 기반 클래스의 소멸자

    base 키워드로 super 객체 접근 가능함 

    struck은 선언만으로도 생성이 가능하나
    class는 new 연산자와 생성자가 필요함 

    모노비헤비어 상속받은걸 상속 해주면 안됨
    메소드 들을 연결받는 델리게이트로 쓰면 됨

    델리게이트 요약 
    1.. 델리게이트 선언
    2. 델리게이트 인스턴스 생성 인스턴스 생성 할때 델리게이트가 참조할 메소드를 매개 변수로 넘겨줌
    3 델리게이트를 호출함 

 * */
    // Use this for initialization


    public delegate void Delgate_obstruction();
    public delegate IEnumerator Delgate_I_obstruction();
    Transform tr;
    Vector3 vec;
    public int random;
    public static float TEST = 0f;
    Delgate_obstruction obstruction;
    void Start () {



        tr = GetComponent<Transform>();
        random = Random.Range(1, 11); //1 ~ 10 까지 
        //Debug.Log("랜덤 값 : " + random);
        //Debug.Log("GameMng.Instance.now_obstruction의 랜덤 값 : " + GameMng.Instance.now_obstruction);
        
        //Delgate_I_obstruction I_obstruction = new Delgate_I_obstruction(I_pattern_base); // 코루틴 델리게이트 
        //I_obstruction += new Delgate_I_obstruction(I_Left_or_right);
        //I_obstruction += new Delgate_I_obstruction(I_pattern_base);
        StartCoroutine(Helper());
        StartCoroutine(Destroy_obstruction());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void delgate_SetUp()
    {

    }
    public IEnumerator Helper()
    {
         // 일반 함수 델리게이트 
        obstruction = new Delgate_obstruction(pattern_base);
        // 와일문 안에 스위치문 있었음
        Debug.Log("GameMng.Instance.now_obstruction :" +GameMng.Instance.now_obstruction);
        switch (GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].name_number)
        {
            
            case (int)GameBalancer.Obstruction_enum.apple: // 일직선 아래로 
                obstruction();
                break;

            case (int)GameBalancer.Obstruction_enum.peach: // 빠르게 일직선 아래로 
                obstruction += new Delgate_obstruction(pattern_fast);
                obstruction();
                break;

            case (int)GameBalancer.Obstruction_enum.grape: // 곡선 아래로 
                Debug.Log("!!!!!!!!!!!!!!6번 그래프 들어왔습니다 ");
                obstruction = new Delgate_obstruction(pattern_base);
                obstruction();

                obstruction -= new Delgate_obstruction(pattern_base);
                while (true)
                {
                    obstruction += new Delgate_obstruction(pattern_slerp);
                    obstruction();
                    yield return new WaitForSeconds(0.5f);
                }
                break;

            case (int)GameBalancer.Obstruction_enum.Strawberry: // 대각선 아래로
                obstruction = new Delgate_obstruction(pattern_base);
                obstruction += new Delgate_obstruction(pattern_LR);

                obstruction();
                break;

            case (int)GameBalancer.Obstruction_enum.Fruit_tree: // 일직선 아래로 

                break;
   
        }
        yield return new WaitForSeconds(0.1f);
    }

    public virtual void pattern_base() // 기본
    {
        //Debug.Log("################# pattern_base 들어옴");
        //TEST += 1f;
        //Debug.Log("################# pattern_base TEST : " + TEST);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed *Time.deltaTime *1000 , 0));  // y축에 스피드 값 status값 불러와야함

    }
    public virtual void pattern_fast() // 기본
    {
        //Debug.Log("################# pattern_base 들어옴");
        //TEST += 1f;
        //Debug.Log("################# pattern_base TEST : " + TEST);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed * Time.deltaTime * 5000, 0));  // y축에 스피드 값 status값 불러와야함

    }

    public void pattern_LR()
    {
        //Debug.Log("################# pattern_LR 들어옴");
        
        if (random%2 == 0)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed * Time.deltaTime * 1000, 0, 0));
        }
        else if(random % 2 == 1)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed * Time.deltaTime * 1000, 0, 0));
        }
    }
    public void pattern_slerp()
    {
        //Debug.Log("################# pattern_slerp 들어옴");
        //TEST+=0.00001f;
        //Debug.Log("################# pattern_slerp TEST : " + TEST);
        if (random % 2 == 0)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed * Time.deltaTime *100 , 0, 0));
        }
        else if (random % 2 == 1)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed * Time.deltaTime *100 , 0, 0));
        }
    }

    public IEnumerator Destroy_obstruction()
    {
        while (true)
        {
            GameMng.Instance.now_obstruction = Random.Range(4, 8); // 재설정 해줘야 함 
            Debug.Log("RE_now_obstruction: " + GameMng.Instance.now_obstruction);
            yield return new WaitForSeconds(4f);
            //GameMng.Instance.now_obstruction = Random.Range(0, GameMng.Instance.create_obstruction_list);       어차피 obj 생성 될때마다  
            //Debug.Log("## now_obstruction :: " + GameMng.Instance.now_obstruction);
            Obstruction_Status.Obstruction_count--;
            Debug.Log("ㅡ################# Destroy_obstruction TEST : " + TEST);
            obstruction = null;
            Destroy(gameObject);
        }
    }

    //public virtual IEnumerator I_pattern_base() // 기본
    //{
    //    Debug.Log("########################코루틴 들어왔습니다");
    //    while (true)
    //    {
    //        //GetComponent<Rigidbody>().velocity = new Vector3(0, GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0);  // y축에 스피드 값 status값 불러와야함
    //        GetComponent<Rigidbody>().AddForce(new Vector3(0, GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0));
    //        GetComponent<Rigidbody>().AddForce(new Vector3(GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0, 0));
    //        //vec = new Vector3(0, GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed * Time.deltaTime , 0);
    //        //Debug.Log(vec);
    //        //tr.Translate(vec);
    //        yield return null;
    //    }
    //}

    //public virtual IEnumerator I_Left_or_right() // 기본
    //{
    //    Debug.Log("########################2코루틴 들어왔습니다");
    //    while (true)
    //    {
    //        //GetComponent<Rigidbody>().velocity = new Vector3(GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0, 0);  // y축에 스피드 값 status값 불러와야함
    //        ////GetComponent<Rigidbody>().AddForce(new Vector3(GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0, 0));
    //        yield return null;
    //    }
    //}


    //   

}





