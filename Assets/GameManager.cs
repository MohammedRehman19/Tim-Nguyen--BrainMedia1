using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.GraphView;
using System.Linq;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject FadeOut;
    UnityDBCSCustom DBCC;
    [HideInInspector]
     public List <GameObject>  clickedObject = new List<GameObject>();
      int levelclickRegister = 0;
    // Start is called before the first frame update
    void Start()
    {
        DBCC = GetComponent<UnityDBCSCustom>();
        Invoke("iniSetup",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddListButton()
    {
        if (!EventSystem.current.currentSelectedGameObject.gameObject.transform.parent.transform.GetChild(2).GetComponent<RawImage>().enabled)
        {
            EventSystem.current.currentSelectedGameObject.transform.parent.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
            DBCC.EnterNumber(levelclickRegister, EventSystem.current.currentSelectedGameObject.name);
            buttonSetup(EventSystem.current.currentSelectedGameObject.gameObject);
        }
        else
        {
            EventSystem.current.currentSelectedGameObject.transform.parent.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
            buttonRemoveSetup(EventSystem.current.currentSelectedGameObject.gameObject);
            removeLetter(EventSystem.current.currentSelectedGameObject.gameObject.name);
            DBCC._context = "";
            DBCC.RemoveNumber(levelclickRegister, DBCC.levels[levelclickRegister]);
        }
    }


    public void LevelButtonCLicked()
    {

        int oldTemp = 0;
        levelclickRegister =EventSystem.current.currentSelectedGameObject.GetComponent<levelConfig>().levelindex;
        if( oldTemp != levelclickRegister)
        {
            Onall();
        }
        iniSetup();
    }
     void Onall()
    {
        foreach(GameObject temp in clickedObject)
        {
            temp.transform.parent.transform.GetChild(2).GetComponent<RawImage>().enabled = false;
            temp.transform.parent.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
        }

        clickedObject = new List<GameObject>(0);
    }

    void iniSetup()
    {
     

         char[] tempArrayy =  DBCC.levels[levelclickRegister].ToCharArray();
            foreach(char temp in tempArrayy)
            {

                buttonSetup(GameObject.Find(temp.ToString()));
            }
        FadeOut.SetActive(false);
    }

    void removeLetter(string letter)
    {
        char[] tempArrayy = DBCC.levels[levelclickRegister].ToCharArray();
        List<char> tempArrayys = new List<char>();
        tempArrayys = tempArrayy.ToList();
        tempArrayys.Remove(letter[0]);
        DBCC.levels[levelclickRegister] = "";
        foreach (char temp in tempArrayys)
        {
            DBCC.levels[levelclickRegister] += temp;
        }

       
    }
    void buttonSetup(GameObject buttont)
    {
        Debug.Log(buttont.transform.name);
        buttont.transform.parent.transform.GetChild(2).GetComponent<RawImage>().enabled = true;
        clickedObject.Add(buttont.transform.parent.transform.GetChild(2).gameObject);
        buttont.transform.parent.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
    }

    void buttonRemoveSetup(GameObject buttont)
    {
        Debug.Log(buttont.transform.name);
        buttont.transform.parent.transform.GetChild(2).GetComponent<RawImage>().enabled = false;
        clickedObject.Remove(buttont.transform.parent.transform.GetChild(2).gameObject);
    }

}
