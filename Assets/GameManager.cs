using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.GraphView;

public class GameManager : MonoBehaviour
{
    
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
       
        DBCC.EnterNumber(levelclickRegister,EventSystem.current.currentSelectedGameObject.name);
        buttonSetup(EventSystem.current.currentSelectedGameObject.gameObject);
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
        
    }

    void buttonSetup(GameObject buttont)
    {
        Debug.Log(buttont.transform.parent.name);
        buttont.transform.parent.transform.GetChild(2).GetComponent<RawImage>().enabled = true;
        clickedObject.Add(buttont.transform.parent.transform.GetChild(2).gameObject);
    }



}
