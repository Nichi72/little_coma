using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pakage01
{
 
    public struct Obstruction_Status
    {
        static int Number_restrictions = 0; // 방해물 제한개수 
        public string name;
        public float incidence;// 방해물 출현률
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
    

    public static class GameBalancer
    {

        public enum Obstruction_enum { initial_value, Asteroid, miniBlackhole, Comet };

        public static Obstruction_Status[] status = new Obstruction_Status[4]
        {
            //인수값 (string name, float incidence, float damage, float speed, float scale)
            new Obstruction_Status(Obstruction_enum.initial_value.ToString(), 4f,5f,5f,6f),
            new Obstruction_Status(Obstruction_enum.Asteroid.ToString(), 4f,5f,5f,6f),
            new Obstruction_Status(Obstruction_enum.miniBlackhole.ToString(), 4f,5f,5f,6f),
            new Obstruction_Status(Obstruction_enum.Comet.ToString(), 4f,5f,5f,6f)
        };
    }
    

    /*public static class TowerLibrary
    {// 체력, 체력재생, 공격력, 방어력, 사정거리, 레벨, 공격지연시간, 코스트
        public static TowerStatus[] towerStatus = new TowerStatus[4] {
            new TowerStatus("tower01", 300, 5, 50, 0, 4, 1, 1f, 70),//수정 전 100, 2, 30, 0, 4, 1, 1f, 50),
            new TowerStatus("tower02", 50, 5, 0, 0, 0, 1, 0f, 100), //수정 전 80, 1, 0, 0, 0, 1, 0f, 30),
            new TowerStatus("tower03", 200,4,80,0,5,1,1f,120),//수정 전 60,2,20,0,7,1,1f,80)
            new TowerStatus("tower04", 850,50,170,50,1,1,0.73f,1000)//수정 전 170,4,10,2,1,1,0.73f,100)
            
        };
        */
}
