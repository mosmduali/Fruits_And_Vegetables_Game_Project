using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour
{
    
    
    public int ToplamMeyveSayisi; // Level de ki Meyve sayısını alır.
    public int IlkMeyveSayisi = 0; // Level de meyve sayısının kaç ta biteceğini belirtir.
    public GameObject FruitsAndOtherObject; // Meyveler ve diğer objeler adlı empty objesini alır.
    public GameObject FinishScene; // Finish empty objesini alır.


    Score Score;

    public void level_son(){ 
        Score = GetComponent<Score>(); // Score nin componenti olan Score yi alır.
        IlkMeyveSayisi += 1; // ilk meyve sayısını her level_son a girdiğinde artırır

        if (IlkMeyveSayisi == ToplamMeyveSayisi) // Eğer ilk meyve sayısı, toplam meyve sayısına eşit ise
        {
            Time.timeScale = 0f;                // Zamanı durdur yani Time.timeScale yi 0f a eşitle
            Score.FinishScoreText.text = Score.TimeText.text.ToString();  // FinishScoreText in text ine de Score class ının içinde ki TimeText in text ini ata
            FruitsAndOtherObject.SetActive(false);  // FruitsAndOtherObject objesinin Inspector unu görünmez yap yani false.
            FinishScene.SetActive(true);    // FinishScene objesinin Inspector unu görünür yap yani true.
        
            GameObject.Find("LevelMusic").GetComponent<AudioSource>().volume = 0f;

            // level 6 sonu time başarı Scoru.
            if(SceneManager.GetActiveScene().buildIndex == 1){
                PlayerPrefs.SetString("Level1Score", Score.TimeText.text);
            }else if(SceneManager.GetActiveScene().buildIndex == 2){
                PlayerPrefs.SetString("Level2Score", Score.TimeText.text);
            }else if(SceneManager.GetActiveScene().buildIndex == 3){
                PlayerPrefs.SetString("Level3Score", Score.TimeText.text);
            }else if(SceneManager.GetActiveScene().buildIndex == 4){
                PlayerPrefs.SetString("Level4Score", Score.TimeText.text);
            }else if(SceneManager.GetActiveScene().buildIndex == 5){
                PlayerPrefs.SetString("Level5Score", Score.TimeText.text);
            }else if(SceneManager.GetActiveScene().buildIndex == 6){
                PlayerPrefs.SetString("Level6Score", Score.TimeText.text);
            }
            /**/
            
        // Level kilit sistemi 
        PlayerPrefs.SetString("Level0", "true");
        if(SceneManager.GetActiveScene().buildIndex == 1 && GameObject.Find("FinishScene").activeSelf == true){
            
            PlayerPrefs.SetString("Level1", "true");
        }
        if(SceneManager.GetActiveScene().buildIndex == 2 && GameObject.Find("FinishScene").activeSelf == true){
            
            PlayerPrefs.SetString("Level2", "true");
        }
        if(SceneManager.GetActiveScene().buildIndex == 3 && GameObject.Find("FinishScene").activeSelf == true){
            
            PlayerPrefs.SetString("Level3", "true");
        }
        if(SceneManager.GetActiveScene().buildIndex == 4 && GameObject.Find("FinishScene").activeSelf == true){
            
            PlayerPrefs.SetString("Level4", "true");
        }
        if(SceneManager.GetActiveScene().buildIndex == 5 && GameObject.Find("FinishScene").activeSelf == true){
            
            PlayerPrefs.SetString("Level5", "true");
        }
        }
    }
}
