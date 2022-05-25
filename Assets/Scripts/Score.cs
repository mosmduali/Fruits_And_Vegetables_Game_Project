using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    /*****************************************************/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*****************************************************/

    public GameObject LoseScene; // Bir GameObject gösterilmesini ister
    public GameObject FruitsAndOtherObject; // Bir GameObject gösterilmesini ister
    public Text scoreText, TimeText, FinishScoreText;  // Bir Text objesininin gösterilmesini ister
    EndLevel EndLevel; 


    public static int x = 0;

    [SerializeField] public float startingTime, endTime = 0f; // Başlangıç zamanı ve bitiş zamanı nın girilmesi beklenir.
    public Text[] finishText; // Bir dizi olarak Text objeleri istenir.

    void score(){ // Score adlı private bir metod. scoreText adlı objenin text ine x i ekler.
        scoreText.text = x.ToString();
    }
    void timer(){ // Score adlı private bir metod.
        EndLevel = GetComponent<EndLevel>(); // EndLevel adlı Classın komponenti olan EndLevel adlı komponent e ulaşır ve EndLevel e atar.
        endTime -= 1 * Time.deltaTime; // Bilgisayarın hızına göre sabit değer de endTime ye değer atar.
        TimeText.text = endTime.ToString("0"); // TimeText adlı Text in text ine endTime
        if(SceneManager.GetActiveScene().buildIndex == 6){ // Eğer altıncı ekrandaysa finishText adlı dizinin teker teker dizi elemanlara önceden kayıtlı olan skor lar atanır.
            finishText[0].text = PlayerPrefs.GetString("Level1Score"); 
            finishText[1].text = PlayerPrefs.GetString("Level2Score");
            finishText[2].text = PlayerPrefs.GetString("Level3Score"); // PlayerPrefs verileri lokal olarak saklamak için kullanıldı.
            finishText[3].text = PlayerPrefs.GetString("Level4Score");
            finishText[4].text = PlayerPrefs.GetString("Level5Score");
            finishText[5].text = PlayerPrefs.GetString("Level6Score");
            
        }
        if (endTime <= 0f){// Eğer endTime 0f dan küçük veya eşit ise endTime yi 0 a eşite.
            endTime = 0f;
            
            if (endTime <= 0 && EndLevel.IlkMeyveSayisi != EndLevel.ToplamMeyveSayisi){ // Eğer endTime sıfır dan küçük veya eşit ise ve IlkMeyveSayisi, ToplamMeyveSayisina eşit değil ise
                FruitsAndOtherObject.SetActive(false);                                  // FruitsAndOtherObject componentinin Inspector unu false yap
                LoseScene.SetActive(true);                                              // LoseScene componentinin Inspector unu true yap.
                 
                GameObject.Find("LevelMusic").GetComponent<AudioSource>().volume = 0f;
                GameObject.Find("LoseSceneMusic").GetComponent<AudioSource>().Play();
                
            }
        }
    }

    void Start()
    {
        endTime = startingTime; // Her baaşlangıç da endTime, startingTime ye eşitlenir

    }

    void Update() // Sürekli score ve timer adlı metodlar çağrılır
    {
        score(); 
        timer();
    }




}
