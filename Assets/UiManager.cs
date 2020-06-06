using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UiManager : MonoBehaviour
{
    TestController _gameController;
   
  
    [Inject]
    public void Construct(
          TestController gameController)
    {
        _gameController = gameController;
       
    }
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        {

         //   StartGui();  
        }
        GUILayout.EndArea();
    }

    // Start is called before the first frame update
    void StartGui()
    {
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            {
                GUILayout.Space(100);
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                {
                    GUILayout.FlexibleSpace();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();
                        GUILayout.Label("ASTEROIDS");
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(60);

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.FlexibleSpace();

                        GUILayout.Label("Click to start");

                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();

                GUILayout.FlexibleSpace();
            }

            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();
    }

}
