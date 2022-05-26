using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelsManager : MonoBehaviour
{

    EndLevel endLevel;
    public Button[] button; // Levels ekranın da ki level butonlarını bir dizi halinde alır.


    public void Start(){
        
        //PlayerPrefs.DeleteAll();



        // Level kilit sistemi
        button[0].GetComponent<Button>().interactable = true;
        
        if(PlayerPrefs.GetString("Level1") == "true"){
            button[1].GetComponent<Button>().interactable = true;
        }
        if(PlayerPrefs.GetString("Level2") == "true"){
            button[2].GetComponent<Button>().interactable = true;
        }
        if(PlayerPrefs.GetString("Level3") == "true"){
            button[3].GetComponent<Button>().interactable = true;
        }
        if(PlayerPrefs.GetString("Level4") == "true"){
            button[4].GetComponent<Button>().interactable = true;
        }
        if(PlayerPrefs.GetString("Level5") == "true"){
            button[5].GetComponent<Button>().interactable = true;
        }


        
    }




}
