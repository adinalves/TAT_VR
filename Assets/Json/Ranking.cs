using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI name;
    // [SerializeField] private TextMeshProUGUI mao;
    // [SerializeField] private TextMeshProUGUI acertos;    
    
    public void AtribuirDadosDoRanking(string _name)
    {
        name.text = _name;
        // mao.text = _mao;
        // acertos.text = _acertos;
    }
}

