using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    enum State {Start, Playing, Win, Lose};

    [SerializeField]
    Text timeLeftText;

    [SerializeField]
    float timeLeft;

    static State state;

    [SerializeField]
    static GameObject[] lives = new GameObject[3];

    [SerializeField]
    GameObject menu, gagne, perdu;

    static int livesLeft;

    // Start is called before the first frame update
    void Start()
    {
        lives = GameObject.FindGameObjectsWithTag("Coeur");
        state = State.Start;
        timeLeft = 25;
        livesLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {

        // Quand le joueur lance la partie, le temps s'écoule
        if(state == State.Playing)
            timeLeft -= Time.deltaTime;

        timeLeftText.text = timeLeft.ToString();

        // Quand le temps atteind 0, le joueur perds 
        if(timeLeft < 0)    
            state = State.Lose;

        switch(state) {
            case State.Start: 
                menu.SetActive(true);
                break;
            case State.Playing:
                menu.SetActive(false);
                break;
            case State.Win:
                gagne.SetActive(true);
                break;
            case State.Lose:
                perdu.SetActive(true);
                Item.allItems.Clear();
                break;
            default:
                break;
        }
        
    }

    public static void RemoveLife() {
        // Desactive l'image d'un coeur
        if(state == State.Playing) {
            lives[livesLeft-1].SetActive(false);
            livesLeft--;
        }
        // Si le joueur n'a plus de vie, il perd
        if(livesLeft == 0) {
            state = State.Lose;
        }

        
    }
    
    // Est appelé quand tous les objets sont récupérés
    public static void Win() {
        state = State.Win;
    }

    public void Play() {
        state = State.Playing;
    }

    public void Retry() {
        SceneManager.LoadScene("Scene");
    }
}
