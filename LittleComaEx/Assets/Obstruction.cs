using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  
 *  
 *  질문사항
 *  방해물 크기에 대해 이해가 잘 안간다.
 *  
 *  
 * 
 * 
 * */

public struct Status
{
    static int Number_restrictions = 0; // 방해물 제한개수 
    public string name;
    public float incidence;// 방해물 출현률
    public float damage;
    public float speed;
    public float scale;

    public Status(Status status)
    {
        this.name = status.name;
        this.incidence = status.incidence;
        this.damage = status.damage;
        this.speed = status.speed;
        this.scale = status.scale;
    }

    public Status(string name, float incidence, float damage,float speed,float scale)
    {
        this.name = name;
        this.incidence = incidence;
        this.damage = damage;
        this.speed = speed;
        this.scale = scale;
    }
}
public class Obstruction : MonoBehaviour {

    Status status;
    
    enum State { initial_value, Asteroid, miniBlackhole, Comet };
    State state = State.initial_value;

    void Start()
    {
        StartCoroutine(states());
    }
    // Use this for initialization
    IEnumerator states()
    {
        while (true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 0); // y축에 스피드 값 status값 불러와야함
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}


public class Asteroid : Obstruction
{ 
    Obstruction asteroid = new Asteroid();

}
