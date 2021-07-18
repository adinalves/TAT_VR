using System.IO;
using UnityEngine;

public class JSON : MonoBehaviour
{
    private StreamReader leitor;
    [SerializeField] private string json;
    [SerializeField] private DataRaiz jogadores;
    [SerializeField] private Ranking[] ranking;

    private void Start()
    {        
        leitor = new StreamReader(Application.dataPath + "/Json/Jogadores.json");        
        json = leitor.ReadToEnd();
        jogadores = JsonUtility.FromJson<DataRaiz>(json);
        
        //Debug.Log(jogadores)

        //  for(int i = 0; i < jogadores.jogadores.Length; i++)
        // {
        //     Debug.Log(jogadores.jogadores[i].name);
        //     ranking[i].AtribuirDadosDoRanking(
        //         jogadores.jogadores[i].name);
        // }

       


    }
}