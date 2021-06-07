using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
   
    public void PlayGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Pentru a face procesul automat
                                                                             //si a nu ne incurca
                                                                             //intra in conexiune cu scene managerul
                                                                             //din unity unde putem gestiona indexul
                                                                             // si ordinea 

    }

    public void QuitGame(){

        Application.Quit();//functia pentru quit game apeleaza metoda in urma apasarii butonului.

    }
}
