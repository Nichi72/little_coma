using UnityEngine;
using System.Collections;

public class ChangeScrollDirection : MonoBehaviour
{
    public UVScroller scroller;

    private int scrollIndex;

    void Start()
    {
        InvokeRepeating("ChangeScroll", 0.5f, 3f);
        // public void InvokeRepeating(string methodName, float time, float repeatRate);
        //time 초에 /methodName/메서드를 호출한 후, 매 /repeatRate/초 마다 반복적으로 호출합니다.
    }

    void ChangeScroll()
    {
        scrollIndex++; // 3초마다 1씩 갱신되면서 3초가 되면 1로 초기화 됨
        if (scrollIndex > 3)
        {
            scrollIndex = 1;
        }

        scroller.direction = (UVScroller.ScrollDirection)scrollIndex;
    }
}