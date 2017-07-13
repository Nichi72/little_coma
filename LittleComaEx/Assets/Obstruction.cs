using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pakage01;
/*
 *  질문사항
 *  방해물 크기에 대해 이해가 잘 안간다.

 * */

public class Obstruction : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(states());
    }
    // Use this for initialization
    IEnumerator states()
    {
        
        //switch()
        //{
        //    //case: GameBalancer.Obstruction_enum.Asteroid
        //}
        int i = 0;
        while (true)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, GameBalancer.status[i].speed, 0); // y축에 스피드 값 status값 불러와야함
            yield return new WaitForSeconds(0.1f);
        }
    }

}


    public class Asteroid : Obstruction
    {
        

    }
