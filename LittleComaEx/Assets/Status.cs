using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;

namespace Pakage01
{
 
    public struct Obstruction_Status
    {
        public static int Obstruction_count = 0; // 현재 만들어진 방해물 수 
       
        public string name;
        public float incidence;// 방해물 출현률 방해물 출현률은 0 ~ 1 까지 이며  0.6을 작성하면 60퍼센트로 출현 함 
        public float damage;  
        public float speed;
        public float scale;
        
        public Obstruction_Status(Obstruction_Status status)
        {
            this.name = status.name;
            this.incidence = status.incidence;
            this.damage = status.damage;
            this.speed = status.speed;
            this.scale = status.scale;
        }

        public Obstruction_Status(string name, float incidence, float damage, float speed, float scale)
        {
            this.name = name;
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
            //인수값              (string name, float incidence, float damage, float speed, float scale)
            new Obstruction_Status(Obstruction_enum.initial_value.ToString(), 0.6f,5f,5f,6f),  // name이 곧 스테이지 넘버 
            new Obstruction_Status(Obstruction_enum.Asteroid.ToString(), 4f,5f,5f,6f),
            new Obstruction_Status(Obstruction_enum.miniBlackhole.ToString(), 4f,5f,5f,6f),
            new Obstruction_Status(Obstruction_enum.Comet.ToString(), 4f,5f,5f,6f),

            new Obstruction_Status(Obstruction_enum.apple.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.peach.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.grape.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.Strawberry.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.Fruit_tree.ToString(),0f,0f,0f,0f),

            new Obstruction_Status(Obstruction_enum.cookie.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.Cake.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.Macaron.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.Pudding.ToString(),0f,0f,0f,0f),
            new Obstruction_Status(Obstruction_enum.Windmill.ToString(),0f,0f,0f,0f),


        };




        

        public static Stage_Status[] stage_Status = new Stage_Status[2]
        {
            //인수값
            //public Stage_Status(int number_restrictions, int stage_number, float stage_length, float stage_speed)
            new Stage_Status(8, 0,100f,5f),
            new Stage_Status(8, 1,150f,5f)
        };
    }

  
}

public class obstruction_mng : MonoBehaviour
{

    public virtual IEnumerator setting_states()
    {
        while (true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0); // y축에 스피드 값 status값 불러와야함
            yield return new WaitForSeconds(0.1f);
        }
    }

    public virtual void Test()
    {
        Debug.Log("***************TEST1*******************");
    }
    public IEnumerator Destroy_obstruction()
    {
        while (true)
        {
            Debug.Log("^^^^^^^^^^^^^이거 실행 된다");
            yield return new WaitForSeconds(5f);
            GameMng.Instance.now_obstruction = Random.Range(0, GameMng.Instance.create_obstruction_list);       // 현재 쓸 Obstruction_Status의 배열을 랜덤으로 초기화 
            Debug.Log("## now_obstruction :: " + GameMng.Instance.now_obstruction);
            Obstruction_Status.Obstruction_count--;
            Destroy(gameObject);
        }
    }
}


public class Asteroid : obstruction_mng
{
    public override IEnumerator setting_states()
    {
        while (true)
        {
            Debug.Log("이거 실행 된다");
            GetComponent<Rigidbody>().velocity = new Vector3(0, GameBalancer.obstruction_status[GameMng.Instance.now_obstruction].speed, 0); // y축에 스피드 값 status값 불러와야함
            yield return new WaitForSeconds(0.1f);
        }
    }

}
