using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;

namespace Pakage01
{
 
    public struct Obstruction_Status
    {
        public static int Obstruction_count = 0; // 현재 만들어진 방해물 수 
       
        public int name_number;
        public float incidence;// 방해물 출현률 방해물 출현률은 0 ~ 1 까지 이며  0.6을 작성하면 60퍼센트로 출현 함 
        public float damage;  
        public float speed;
        public float scale;
        
        public Obstruction_Status(Obstruction_Status status)
        {
            this.name_number = status.name_number;
            this.incidence = status.incidence;
            this.damage = status.damage;
            this.speed = status.speed;
            this.scale = status.scale;
        }

        public Obstruction_Status(int name_number, float incidence, float damage, float speed, float scale)
        {
            this.name_number = name_number;
            this.incidence = incidence;
            this.damage = damage;
            this.speed = speed;
            this.scale = scale;
    }


    }

    public struct Stage_Status
    {
        public int number_restrictions; // 방해물 제한개수 
        public int stage_number; // 몇번째 스테이지
        public float stage_length;//스테이지 총 길이  
        public float stage_speed; // 스테이지 속도 

        public Stage_Status(Stage_Status status)
        {
            this.number_restrictions = status.number_restrictions;
            this.stage_number = status.stage_number;
            this.stage_length = status.stage_length;
            this.stage_speed = status.stage_speed;
        }

        public Stage_Status(int number_restrictions, int stage_number, float stage_length, float stage_speed)
        {
            this.number_restrictions = number_restrictions;
            this.stage_number = stage_number;
            this.stage_length = stage_length;
            this.stage_speed = stage_speed;
        }
    }


    public static class GameBalancer
    {

        public enum Obstruction_enum { initial_value, Asteroid, miniBlackhole, Comet,       //기본 방해물 
                                       apple , peach , grape , Strawberry , Fruit_tree,     //스테이지 1번 Obstruction_enum = 4~8        
                                       cookie, Cake , Macaron , Pudding , Windmill          //스테이지 2번 Obstruction_enum = 9~13
        };

        public static Obstruction_Status[] obstruction_status = new Obstruction_Status[14]
        {
            //인수값              (string name, float incidence, float damage, float speed, float scale) // 
            new Obstruction_Status((int)Obstruction_enum.initial_value, 0.6f,5f,5f,6f),  // name이 곧 스테이지 넘버 
            new Obstruction_Status((int)Obstruction_enum.Asteroid, 0.6f,5f,5f,6f),
            new Obstruction_Status((int)Obstruction_enum.miniBlackhole, 0.6f,5f,5f,6f),
            new Obstruction_Status((int)Obstruction_enum.Comet, 0.6f,5f,5f,6f),

            new Obstruction_Status((int)Obstruction_enum.apple,5f,5f,5f,5f),
            new Obstruction_Status((int)Obstruction_enum.peach,5f,5f,5f,5f),
            new Obstruction_Status((int)Obstruction_enum.grape,0.6f,5f,30f,5f),
            new Obstruction_Status((int)Obstruction_enum.Strawberry,0.6f,5f,30f,0f),
            new Obstruction_Status((int)Obstruction_enum.Fruit_tree,0f,0f,0f,0f),

            new Obstruction_Status((int)Obstruction_enum.cookie,0f,0f,0f,0f),
            new Obstruction_Status((int)Obstruction_enum.Cake,0f,0f,0f,0f),
            new Obstruction_Status((int)Obstruction_enum.Macaron,0f,0f,0f,0f),
            new Obstruction_Status((int)Obstruction_enum.Pudding,0f,0f,0f,0f),
            new Obstruction_Status((int)Obstruction_enum.Windmill,0f,0f,0f,0f),


        };

        public static Stage_Status[] stage_Status = new Stage_Status[3]
        {
            //인수값
            //public Stage_Status(int number_restrictions, int stage_number, float stage_length, float stage_speed)
            new Stage_Status(0, 0,0f,0f),// 0번 인덱스 더미
            new Stage_Status(8, 1,120f,5f),
            new Stage_Status(8, 2,120f,5f)
        };
    }

  
}

//public class Status : MonoBehaviour
//{
//    void Start()
//    {
//        //StartCoroutine(setting_states());
//    }

//    public virtual IEnumerator setting_states()
//    {
//        while (true)
//        {
//            GetComponent<Rigidbody>().velocity = new Vector3(0, -GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0); // y축에 스피드 값 status값 불러와야함
//            yield return new WaitForSeconds(0.1f);
//        }
//    }

//    public virtual void Test()
//    {
//        Debug.Log("***************TEST1*******************");
//    }


//    
//}


//public class Asteroid : Status
//{
//    public override IEnumerator setting_states()
//    {
//        while (true)
//        {
//            Debug.Log("이거 실행 된다");
//            GetComponent<Rigidbody>().velocity = new Vector3(0, GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0); // y축에 스피드 값 status값 불러와야함
//            yield return new WaitForSeconds(0.1f);
//        }
//    }


