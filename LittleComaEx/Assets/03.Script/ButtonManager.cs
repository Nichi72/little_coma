using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    // UI전체를 포함하는 Canvas 오브젝트를 담을 변수
    GameObject canvas;
    // 사운드매니저 스크립트
    SoundManager soundManager;
    // 버튼 클릭 사운드
    public AudioClip ButtonSE;
    // 버튼에서 연결되는 기능들을 모아놓은 클래스
    Function buttonFuntion;
    // 하나의 인자값을 나누어 저장할 String 배열
    string[] splitedMessage = new string[5];


    // Use this for initialization
    void Start() {
        canvas = GameObject.Find("Canvas");
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnClick(string message)
    {
        // 효과음
        soundManager.PlaySE(ButtonSE);
        // 기능
        // 메시지 분할
        splitedMessage = message.Split('_');
        switch (message)
        {
            case "ChangeScene": buttonFuntion.ChangeScene();
                break;
                case ""                
        }
        buttonFuntion.
    }
    


    class Function : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ChangeMenu(GameObject canvas, string menuName)
        {
            //메뉴 활성화
            //GameObject.Find(menuName).SetActive(true);
            canvas.transform.Find(menuName).gameObject.SetActive(true);

            // 현재 활성홛된 메뉴 비활성화
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
