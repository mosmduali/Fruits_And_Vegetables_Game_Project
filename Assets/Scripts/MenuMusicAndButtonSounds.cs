using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuMusicAndButtonSounds : MonoBehaviour
{
   
    public static MenuMusicAndButtonSounds instance; // MenuMusic... adlı class ı static bir metod olarak tanımladık.

    private void Awake(){ // Metod ilk çalışmaya başlar

        GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 1; // Game objesi olan SoundManager i bulur ve bunun Componenti olan AudioSource nin ses seviyesini 1 e eşitler.

        if(instance == null ){ // Bu şart kabul olduğu sürece alt daki komutlar çalışır
            DontDestroyOnLoad(this.gameObject); //  Şart  kabul olduğu sürece destroy olmayacak           
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

}

    




