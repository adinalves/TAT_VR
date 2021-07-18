using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameLogic : MonoBehaviour
{
    //ELEMENTOS DA UI
    public GameObject initialCanvas;
    public InputField nameInputField;
    public GameObject timerCanvas;
    public GameObject NovaAvaliacao;
    public GameObject CanvasRanking;
    public GameObject CanvasResultado;
    public GameObject Weapon;
    public Text timerText;
    public GameObject gunCanvas;
    public GameObject gun;
    public Button BotaoAvaliacao;
    public Button BotaoRanking;
    public Button BotaoBack;
    public Button BotaoNew;
    public Button BotaoDireita;
    public Button BotaoEsquerda;
    public Button BotaoVoltarTelaInicial;
    public Button BotaoNovaAvaliacaoResultado;
    public Button BotaoRankingResultado;


    public float TimerStart;
    public int mao = 1;

    public GameObject alvo;
    public GameObject arma;
    
    public Text NameResultado;
    public Text TimeResultado;
    public Text AcertosResultado;
    public Text MencaoResultado;
    public Text DispersaoResultado;

    public TextAsset textJSON;
   // public Ranking ranking;
    public Text rankingNome;
    public Text rankingImpactos;
    public Text rankingTempo;
    public Text rankingDispersao;

    
   
   

    [System.Serializable]
    public class Player 
    {
        public string nome;
        public int acertos;
        public string tempo;
        public double dispersao;
    }
    
    [System.Serializable]
    public class PlayerList
    {
       // public Player[] player;


        public List<Player> player = new List<Player>();
        
// subjects.add(new Subject{....});
// subjects.add(new Subject{....});
    }


   

    public PlayerList myPlayerList = new PlayerList();
    public Player jogador = new Player();
    public string auxNome;
    public string auxImpactos;
    public string auxTempo;
    public string auxRankingDispersao;

    private StreamWriter escritor;
    [SerializeField] private string json;


    public void SerializarJSON()
    {
        //JsonUtility.FromJsonOverwrite(json, myPlayerList);
        
        
        json = JsonUtility.ToJson(myPlayerList);
        escritor = new StreamWriter(Application.dataPath + "/Json/Jogadores.json", false);        
        escritor.Write(json);
        escritor.Close();
    }




    //INICIALIZAÇÃO DA APLICAÇÃO
    void Start()
    {
       

        

       myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);

        Weapon.SetActive(false);
        
        //Leitura dos dados persistidos em JSON
       // DAO.getInstance().load();
        Button btnAvaliacao = BotaoAvaliacao.GetComponent<Button>();
		btnAvaliacao.onClick.AddListener(ExibeAvaliacao);
        
        /*Button btnVoltar = BotaoBack.GetComponent<Button>();
		btnVoltar.onClick.AddListener(Voltar); */

        Button btnNew = BotaoNew.GetComponent<Button>();
		btnNew.onClick.AddListener(Iniciar);

        Button btnRanking = BotaoRanking.GetComponent<Button>();
		btnRanking.onClick.AddListener(Ranking);

        Button btnDireita = BotaoDireita.GetComponent<Button>();
		btnDireita.onClick.AddListener(Direita);

        
        Button btnEsquerda = BotaoEsquerda.GetComponent<Button>();
		btnEsquerda.onClick.AddListener(Esquerda);

        Button btnVoltar = BotaoVoltarTelaInicial.GetComponent<Button>();
		btnVoltar.onClick.AddListener(VoltarTelaInicial);

        Button btnNovaAvaliacaoResultado = BotaoNovaAvaliacaoResultado.GetComponent<Button>();
		btnNovaAvaliacaoResultado.onClick.AddListener(NovaAvaliacaoResultado);

        Button btnRankingResultado = BotaoRankingResultado.GetComponent<Button>();
		btnRankingResultado.onClick.AddListener(Ranking);


        //Debug.Log(myPlayerList.player[0].name);

        //ranking.text = myPlayerList.player[0].name;
         
        //  for(int i = 0; i < myPlayerList.player.Count; i++)
        // {
        //     auxNome += myPlayerList.player[i].name + "\n"; 

        // }

        //  for(int i = 0; i < myPlayerList.player.Count; i++)
        // {
        //     auxImpactos += myPlayerList.player[i].acertos + "\n"; 

        // }
        // // Debug.Log(aux);

        // rankingNome.text = auxNome;
        // rankingImpactos.text = auxImpactos;

    }

    

    void NovaAvaliacaoResultado()
    {
        nameInputField.text = "";
        CanvasResultado.SetActive(false);
        NovaAvaliacao.SetActive(true);
        
    }

    void VoltarTelaInicial()
    {
        initialCanvas.SetActive(true);
        CanvasRanking.SetActive(false);
    }

    void Direita() {
        mao = 1; 
        Debug.Log("Mao direita");

    }

     void Esquerda() {
        mao = 0;
        Debug.Log("Mao esquerda");

    }

    void Iniciar() {
        
       // DAO.getInstance().data.setName(nameInputField.text);
        //Debug.Log("Salvei o nome " + nameInputField.text);
       NameResultado.text = nameInputField.text;

        jogador.nome = nameInputField.text;
        
        AcertosResultado.text = "-";
        MencaoResultado.text = "-";
        DispersaoResultado.text = "-";
        
        /*
        NovaAvaliacao.SetActive(false);
        timerCanvas.SetActive(true);
        gunCanvas.SetActive(true);
        gun.SetActive(true);
        */
        TimerStart = Time.time;
        timerCanvas.SetActive(true);
        //Cursor.visible = false;
        NovaAvaliacao.SetActive(false);
       
        // //Cursor.lockState = CursorLockMode.Locked;
        // TimerStart = Time.time;

        // // GameObject Target = GameObject.Find("Target");
        // // Target target = Target.GetComponent<Target>();
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        
        Invoke("InvokeAvaliacao", 0.4f);

    }

    void InvokeAvaliacao() {
        //Cursor.lockState = CursorLockMode.Locked;
        

        // GameObject Target = GameObject.Find("Target");
        // Target target = Target.GetComponent<Target>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Weapon.SetActive(true);
    }



   void ExibeAvaliacao(){
       
        nameInputField.text = "";
		initialCanvas.SetActive(false);
        NovaAvaliacao.SetActive(true);
	}

     void Ranking(){
       
         auxNome = "";
         auxImpactos = "";
         auxTempo = "";
         auxRankingDispersao = "";

         
         //List<Player> sorted = (myPlayerList.player).OrderBy(x => x.acertos).ToList();
        //  var nums = new List<int> { 2, 1, 8, 0, 4, 3, 5, 7, 9 };

        // nums.Sort();
        // Debug.Log(string.Join(" ", nums));
       // myPlayerList.player.Sort((x, y) => y.acertos.CompareTo(x.acertos));

        List<Player> aux = new List<Player>();
        aux = myPlayerList.player;

        aux.Sort((x, y) => {
                        int ret = y.acertos.CompareTo(x.acertos);
                        return ret != 0 ? ret : x.dispersao.CompareTo(y.dispersao);
                    });


       // Debug.Log(myPlayerList.player[0].nome);

       for(int i = 0; i < aux.Count; i++)
        {
            auxNome += aux[i].nome + "\n"; 
            auxImpactos += aux[i].acertos +  " (" + mencao(aux[i].acertos) + ")" + "\n"; 
            auxTempo += aux[i].tempo + "\n"; 
            auxRankingDispersao += aux[i].dispersao.ToString("F") + "\n";
        }

    
        // Debug.Log(aux);

        rankingNome.text = auxNome;
        rankingImpactos.text = auxImpactos;
        rankingTempo.text = auxTempo;
        rankingDispersao.text = auxRankingDispersao;

        CanvasResultado.SetActive(false);
		initialCanvas.SetActive(false);
        CanvasRanking.SetActive(true);

	}

    void Voltar() {
        initialCanvas.SetActive(true);
        NovaAvaliacao.SetActive(false);

    }

    //ATUALIZAÇÃO DA APLICAÇÃO A CADA FRAME
    void Update()
    {
        
        


        

        //alvo.GetComponent<Target>().getHit();

        //Debug.Log(alvo.GetComponent<Target>().getHit());

        if(timerCanvas.activeSelf) {

            
        int minutes = (int) (Time.time - TimerStart)/ 60;
        int seconds = (int) (Time.time - TimerStart) % 60;
        timerText.text = 
            ((minutes < 10) ? "0" + minutes : "" + minutes) + ":" +
            ((seconds < 10) ? "0" + seconds : "" + seconds); 
        }

        // if(CanvasResultado.activeSelf) {
        // jogador.acertos = FindObjectOfType<Bullet>().getAcertos();
        // Debug.Log(jogador.acertos);
        // }

        //Debug.Log(arma.GetComponent<Gun>().getBullet());
        
       //if(CanvasResultado.activeSelf) {
        //if(false) {

            if(arma.GetComponent<Gun>().getBullet()<=0) {
            
            Invoke("CallFinalAvaliacao", 3f);
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;

            // //arma.GetComponent<Gun>().setBullet = 3;
            // timerCanvas.SetActive(false);
            
            // TimeResultado.text = timerText.text;
            // AcertosResultado.text = (alvo.GetComponent<Target>().getHit()).ToString();
           

            // int hit = alvo.GetComponent<Target>().getHit();
            // MencaoResultado.text = mencao(hit);

            // double disp = alvo.GetComponent<Target>().Dispersao();
            // DispersaoResultado.text = disp.ToString("F");
            
            //myPlayerList.player.Add(new Player{nome=jogador.nome, acertos=hit, tempo = timerText.text, dispersao = disp});
           // SerializarJSON();
            

          //  Debug.Log(alvo.GetComponent<Target>().Dispersao().ToString("F"));


          CanvasResultado.SetActive(true);
          timerCanvas.SetActive(false);
          TimeResultado.text = timerText.text;
           Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }

    }

    public void CallFinalAvaliacao(){
        

            //arma.GetComponent<Gun>().setBullet = 3;
            
            
        
            AcertosResultado.text = (alvo.GetComponent<Target>().getHit()).ToString();
           

            int hit = alvo.GetComponent<Target>().getHit();
            MencaoResultado.text = mencao(hit);

            double disp = alvo.GetComponent<Target>().Dispersao();
            DispersaoResultado.text = disp.ToString("F");
            Weapon.SetActive(false);
            myPlayerList.player.Add(new Player{nome=jogador.nome, acertos=hit, tempo = timerText.text, dispersao = disp});
            SerializarJSON();
           // CanvasResultado.SetActive(true);
           //Invoke("CallDispersao", 3f);
            
    }

    // public void CallDispersao(){

    //         double disp = alvo.GetComponent<Target>().Dispersao();
    //         DispersaoResultado.text = disp.ToString("F");
    // }



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


    public string mencao(int hits){

        if(hits == 15)
        {
            return "E";
        }
        else if(hits==14 || hits==13){
            return "MB";
        }
        else if(hits<=12 && hits>=9) {
            return "B";
        }
        else if(hits<=6 && hits>=8){
            return "R";
        }
        else
        {
            return "I";
        }

    }


  
    
}