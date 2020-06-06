using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
public class GetTextures : MonoBehaviour
{
    public GameObject OSA;
	[HideInInspector]
    public int length;
    [HideInInspector]
    public List<Texture> showtexture = new List<Texture>();
  

    void Start ()
	{ 
            StartCoroutine(GetTexture());	
    }
       

	
    IEnumerator GetTexture()
    {
        int temp = 0;
        int currenttemp = 1;
        var files = System.IO.Directory.GetFiles(@"C:\Appimages\");
        length = files.Length;
     //   print(files.Length);
        while (temp < files.Length)
        {

          
            UnityWebRequest www = UnityWebRequestTexture.GetTexture("C:/Appimages/Capture00" + currenttemp + ".png");
            yield return www.SendWebRequest();
          

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                showtexture.Add(myTexture);
              
            }

            temp += 1;
            currenttemp = temp + 1;
        }

        OSA.SetActive(true);
     
    }

}