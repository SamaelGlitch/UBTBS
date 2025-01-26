using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public TextMeshProUGUI pricesText;
    public GameObject timeOut;
    public int meta = 1000;
    public int price = 0;
    
    public void TimingOut(int precioactual)
    {
        price += precioactual;
    } 

    public void Precios()
    {
        if (timeOut == null)
        {
            if (meta < price)
            {
                Debug.Log("GANASTE :DDDDDD");
            }
            else
            {
                Debug.Log("PERDISTE XDDDD");
            }
        }
        else 
        {

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Precios();
        pricesText.text = price + " / " + meta.ToString();
    }
}
