using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HUDmenu : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject CreditMenu;
    public GameObject MouseObj;
    public List<GameObject> MainBtnList = new List<GameObject>();
    public string GameSceneName;
    public List<string> Credits = new List<string>();
    public GameObject CreditRoot;
    public GameObject CreditPrefab;

    GameObject BtnPlay;
    GameObject BtnCredit;
    GameObject BtnQuit;
    GameObject BtnBackToMain;
    GameObject Fx;
    void Play(GameObject _Btn)
    {
        Application.LoadLevel(1);
    }
    void ShowCredit(GameObject _Btn)
    {
        TweenTransform trans = CreditMenu.GetComponent<TweenTransform>();
        trans.PlayForward();
    }
    
    void BackToMainMenu(GameObject _Btn)
    {
        TweenTransform trans = MainMenu.GetComponent<TweenTransform>();
        trans.PlayReverse();
    }

    void Quit(GameObject _Btn)
    {
        Application.Quit();     
    }

    IEnumerator ShowClickFx( GameObject Fx)
    {
        if (Fx != null)
        {
            Fx.SetActive(true);
        }
        yield return new WaitForSeconds(0.3f);
        Fx.SetActive(false);
    }
    void ClickeFx(GameObject Fx)
    {
        if (Input.GetMouseButtonDown(0)) {
            if (Fx.activeSelf == true)
            {
                StopCoroutine(ShowClickFx(Fx));
                Fx.SetActive(false);
            }
            StartCoroutine(ShowClickFx(Fx));
            //Debug.Log("clicked");
        }
    }
    void FollowMouse(GameObject MouseObj)
    {
        Vector3 pos = Input.mousePosition;
        Vector3 movepos = new Vector3(pos.x, pos.y, 1f);
        MouseObj.transform.position = Camera.main.ScreenToWorldPoint(movepos);
    }

    void CreditInit(List<string>_Credits , GameObject _CreditPrefab ,GameObject _MenuRoot)
    {
        for (int i = 0; i < _Credits.Count; i++)
        {
           GameObject creditcur = NGUITools.AddChild(_MenuRoot, _CreditPrefab);
           creditcur.transform.GetComponentInChildren<UILabel>().text = _Credits[i];
           creditcur.name = _Credits[i];
        }
    }

    void mainMenuInit()
    {
        BtnPlay   = MainBtnList[0];
        BtnCredit = MainBtnList[1];
        BtnQuit   = MainBtnList[2];
        BtnBackToMain = MainBtnList[3];

        CreditInit(Credits, CreditPrefab, CreditRoot);

        UIEventListener.Get(BtnPlay).onClick = Play;
        UIEventListener.Get(BtnCredit).onClick = ShowCredit;
        UIEventListener.Get(BtnBackToMain).onClick = BackToMainMenu;
        UIEventListener.Get(BtnQuit).onClick = Quit;
        Fx = MouseObj.transform.FindChild("fx").gameObject;
        Fx.SetActive(false);
    }
	// Use this for initialization
	void Awake () {
	     mainMenuInit();
	}
	
	// Update is called once per frame
	void Update () {

        FollowMouse(MouseObj);
        ClickeFx(Fx);
	}
}
