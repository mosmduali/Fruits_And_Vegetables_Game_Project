using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MeyvelerScript : MonoBehaviour
{

    Camera Camera; 
    GameObject[] Shadows; // Shadows adlı bir dizi alır.
    Vector3 StartingPosition; // Başlangıç pozisyonunu belirler

    EndLevel EndLevel;

    
 


    void Start(){
        EndLevel = GetComponent<EndLevel>(); // EndLevel adlı component çağrılır ve EndLevel adlı class a atanır.
        Camera = GameObject.Find("Camera").GetComponent<Camera>(); // Camera adlı GameObject ini bulur ve bunun Camera adlı componentini Camera ya atar.
        Shadows = GameObject.FindGameObjectsWithTag("Shadows"); // Shadows taglı GameObject ini bulur ve Shadows a atar.
        StartingPosition = transform.position; // başlangıç pozisyonunu transform pozisyon yapar yani ekranda olduğu pozisyon
        EndLevel = GameObject.Find("ObjectPropetries").GetComponent<EndLevel>(); // ObjectProperties adlı GameObject ini bulur ve bunun EndLevel adlı componentini EndLevel a atar.

       if(SceneManager.GetActiveScene().buildIndex == 1 && GameObject.Find("SoundManager")){
           GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0;
       }
        if(SceneManager.GetActiveScene().buildIndex == 2 && GameObject.Find("SoundManager")){
           GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0;
       }
        if(SceneManager.GetActiveScene().buildIndex == 3 && GameObject.Find("SoundManager")){
           GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0;
       }
        if(SceneManager.GetActiveScene().buildIndex == 4 && GameObject.Find("SoundManager")){
           GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0;
       }
        if(SceneManager.GetActiveScene().buildIndex == 5 && GameObject.Find("SoundManager")){
           GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0;
       }
        if(SceneManager.GetActiveScene().buildIndex == 6 && GameObject.Find("SoundManager")){
           GameObject.Find("SoundManager").GetComponent<AudioSource>().volume = 0;
       }
       
        
    
    }   

    void OnMouseDrag()// Objenin veya objelerin sürüklenmesi için kullanılır
    {
        Vector3 pozisyon = Camera.ScreenToWorldPoint(Input.mousePosition); // Vecttor3 x,y,z eksenlerini temsil eder. // Vector3 olarak tanımlanan pozisyon değişkenine 
        pozisyon.z = 0; // pozisyonun z kordinatı 0 olarak eşitlenir
        transform.position = pozisyon; //
        

        GameObject.Find("WhenShadowEqualsShadow").GetComponent<AudioSource>().volume = 0.5f;
        GameObject.Find("WhenShadowEqualsShadow").GetComponent<AudioSource>().Play();
        
        
        
        
        

        

    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // Mouse üzerindeki bir tuşa basıldıktan sonra kullanıcının elini ilgili tuştan çekmesi sonrasında çalışan metot dur.
        {
            foreach (GameObject shadow in Shadows) { // Gölgeler objesinin içindeki gölge objelerini teker teker gezer
                if (gameObject.name == shadow.name){ // Tanımlı olan GameObject in ismi yine tanımlı olan Gölge tagındaki objelere eşit olduğunda çalışır
                    
                    float mesafe = Vector3.Distance(shadow.transform.position, transform.position); // float cinsinden mesafe tanımlanır ve Vector3 ...
                    if (mesafe <= 1){ // Eğer mesafe 1 e eşit veya küçük ise
                        transform.position = shadow.transform.position; // Objenin pozisyonunu gölgenin pozisyonuna eşitle.
                        Destroy(this); // O an ki dönen objeyi kaldırır

                        GameObject.Find("WhenShadowEqualsShadow").GetComponent<AudioSource>().volume = 0;
                        GameObject.Find("GetMouseButtonUp").GetComponent<AudioSource>().Play();
                        
                        EndLevel.level_son(); // EndLevel class ın da ki level_son() metod unu çağırır
                        Score.x += 1; // score class ının içinde ki x e 1 ekler
                    }
                    else{
                        transform.position = StartingPosition; // Eğer tanımlı olan pozisyonun dışındaysa veya gölge ile eşit değil ise tanımlı olan pozisyona geri dön.

                    }

                }

            }
        }
    }
}
