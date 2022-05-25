using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    /*****************************************************/
    /*|                 Osman Dvalıdze                  |*/
    /*|         osman.dvalidze@ogr.dpu.edu.tr           |*/
    /*|             osmandvali@gmail.com                |*/
    /*|                                                 |*/
    /*|               @mosman_dvalidze                  |*/
    /*|   https://www.facebook.com/osman.dvalidze2000/  |*/
    /*|    https://www.linkedin.com/in/osmandvalidze/   |*/
    /*|                                                 |*/
    /*|                                                 |*/
    /*****************************************************/
    Score score;
    
    // Bir sonraki Seviye ye geçiş.
    public void nextLevel(){
        Time.timeScale = 1f;
        Score.x = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Aşırı yükleme ile Unity programından Index numarası alınarak o index penceresini açar.
    public void nextLevel(int levelIndex){
        SceneManager.LoadScene(levelIndex);
    }


    // Oyunun hangi index de oynandığına bağlı olarak aynı index den oyununun tekrarlanmasını sağlar
    public void restartLevel(){
        Time.timeScale = 1f;
        Score.x = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Oyundan çıkma komutları burda yer alır.
    public void exitGame()
    {
        Application.Quit();
    }
    // Seviye ekranını açar.
    public void levelsScene()
    {
        SceneManager.LoadScene("Levels");
    }
    // Credits Ekranını açar.
    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }
    // Options Ekranını açar.
    public void option()
    {
        SceneManager.LoadScene("Options");
    }
    // Menü Ekranını açar.
    public void menu()
    {
        Time.timeScale = 1f;
        Score.x = 0;
        SceneManager.LoadScene("Menu");
    }
    public void resume(){
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().volume = 0.3f;
        Time.timeScale = 1f;
        GameObject.Find("Pause").GetComponentInChildren<Button>().interactable = true;
    }
    public void pause(){
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().volume = 0f;
        GameObject.Find("Pause").GetComponentInChildren<Button>().interactable = false;
        if(GameObject.Find("Pause").GetComponentInChildren<Button>().interactable == false){
            Time.timeScale = 0f;
        }
    }

}
