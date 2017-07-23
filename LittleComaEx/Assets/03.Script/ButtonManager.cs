using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    GameObject canvas;

    // Use this for initialization
    void Start() {
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update() {

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeMenu(string menuName)
    {
        //메뉴 활성화
        //GameObject.Find(menuName).SetActive(true);
        canvas.transform.Find(menuName).gameObject.SetActive(true);

        // 현재 활성홛된 메뉴 비활성화
        this.transform.parent.gameObject.SetActive(false);
    }
}
