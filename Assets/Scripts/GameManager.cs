using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public Scene lvl1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void Jugar() {
    SceneManager.LoadScene("Allan");
}

    public void Volverajugar() {
    SceneManager.LoadScene("Allan");
   }

   public void Salir() {
       Application.Quit();
   }

   public void Iramenu() {
       SceneManager.LoadScene("Menu principal");
   }
   public void Teganasteelregalo() {
   SceneManager.LoadScene("Menu principal");
}

 public void Salir() {
       Application.Quit();
}




   