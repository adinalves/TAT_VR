using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    //ELEMENTOS DA UI
    public GameObject initialCanvas;
    public InputField nameInputField;
    public GameObject timerCanvas;
    public GameObject NovaAvaliacao;
    public Text timerText;
    public GameObject gunCanvas;
    public GameObject gun;
    public Button BotaoAvaliacao;
    public Button BotaoBack;
    public Button BotaoNew;
    public Button BotaoDireita;
    public Button BotaoEsquerda;
    public float TimerStart;

    //INICIALIZAÇÃO DA APLICAÇÃO
    void Start()
    {
        //Leitura dos dados persistidos em JSON
        DAO.getInstance().load();
        Button btnAvaliacao = BotaoAvaliacao.GetComponent<Button>();
		btnAvaliacao.onClick.AddListener(ExibeAvaliacao);
        
        /*Button btnVoltar = BotaoBack.GetComponent<Button>();
		btnVoltar.onClick.AddListener(Voltar); */

        Button btnNew = BotaoNew.GetComponent<Button>();
		btnNew.onClick.AddListener(Iniciar);

        Button btnDireita = BotaoDireita.GetComponent<Button>();
		btnDireita.onClick.AddListener(Direita);

        
        Button btnEsquerda = BotaoEsquerda.GetComponent<Button>();
		btnEsquerda.onClick.AddListener(Esquerda);

    }

    void Direita() {
        Debug.Log("Mao direita");

    }

     void Esquerda() {
        Debug.Log("Mao esquerda");

    }

    void Iniciar() {
        
        DAO.getInstance().data.setName(nameInputField.text);
        Debug.Log("Salvei o nome " + nameInputField.text);
        /*
        NovaAvaliacao.SetActive(false);
        timerCanvas.SetActive(true);
        gunCanvas.SetActive(true);
        gun.SetActive(true);
        */
        timerCanvas.SetActive(true);
        Cursor.visible = false;
        NovaAvaliacao.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        TimerStart = Time.time;
        

    }



   void ExibeAvaliacao(){
       
		initialCanvas.SetActive(false);
        NovaAvaliacao.SetActive(true);
	}

    void Voltar() {
        initialCanvas.SetActive(true);
        NovaAvaliacao.SetActive(false);

    }

    //ATUALIZAÇÃO DA APLICAÇÃO A CADA FRAME
    void Update()
    {
        
        
        if(timerCanvas.activeSelf) {

            Debug.Log(Time.time);
        int minutes = (int) (Time.time - TimerStart)/ 60;
        int seconds = (int) (Time.time - TimerStart) % 60;
        timerText.text = 
            ((minutes < 10) ? "0" + minutes : "" + minutes) + ":" +
            ((seconds < 10) ? "0" + seconds : "" + seconds); 
        }
            
    }

    //MÉTODOS PARA INTERAÇÃO COM A UI
   /* public void OnClickStartButton()
    {
        
        
        DAO.getInstance().data.setName(nameInputField.text);
        Debug.Log("Salvei o nome " + nameInputField.text);
        //initialCanvas.SetActive(false);
        //NovaAvaliacao.SetActive(true);
        //timerCanvas.SetActive(true);
        //gunCanvas.SetActive(true);
       // gun.SetActive(true);
        
    } */
    
    public void OnClickUpButton()
    {
        gun.transform.Rotate(-1, 0, 0);
    }

    public void OnClickLeftButton()
    {
        gun.transform.Rotate(0, -1, 0);
    }

    public void OnClickRightButton()
    {
        gun.transform.Rotate(0, 1, 0);
    }

    public void OnClickDownButton()
    {
        gun.transform.Rotate(1, 0, 0);
    }

    public void OnClickFireButton()
    {
        Debug.Log("ATIROU!");
    }
    
}