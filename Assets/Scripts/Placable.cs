using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placable : MonoBehaviour
{
    public Dictionary<string, int> ingrediants = new Dictionary<string, int>();
    public List<string> ingrediantsNameList = new List<string>();
    public List<SpriteRenderer> pizzaToppingsList = new List<SpriteRenderer>();
    public bool IsOven = false;
    public bool IsBaking = false;
    public bool IsServing = false;
    public Slider progress;

    //coinCount Coin = new coinCount();
    //public Text coinCountText;
    //int totalCoin;

    // Start is called before the first frame update
    void Start()
    {
        //coinCountText = GetComponent<Text>();
        //totalCoin = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsBaking)
        {
            progress.value += 1 * Time.deltaTime;
            if (progress.value >= progress.maxValue)
            {
                IsBaking = false;
                progress.value = 0;
                progress.gameObject.SetActive(false);
                Render();
            }
        }
    }

    public void Place(string ingrediantNamne)
    {
        if (!IsServing)
        {
            if (ingrediants.ContainsKey(ingrediantNamne))
            {
                //ingrediants[ingrediantNamne]++;
            }
            else ingrediants[ingrediantNamne] = 0;
            ingrediantsNameList = new List<string>(ingrediants.Keys);

        }
        else
        {
            ingrediants.Clear();
        }
        Render();
    }


    public void Render()
    {
        foreach (SpriteRenderer topping in pizzaToppingsList)
        {
            if (ingrediants.ContainsKey(topping.gameObject.name) && ingrediants[topping.gameObject.name] == 1)
            {
                topping.color = new Color(207f / 255f, 132f / 255f, 46f / 255f);
            }
            else topping.color = Color.white;
            if (ingrediants.ContainsKey(topping.gameObject.name) && !IsBaking)
            {
                topping.gameObject.SetActive(true);
            }
            else topping.gameObject.SetActive(false);
        }
    }

    public void Oven()
    {
        if (IsOven && ingrediants.ContainsKey("dough"))
        {
            /* foreach (string ingrediant in ingrediants.Keys)
             {
                 ingrediants[ingrediant] = 1;
             }*/
            ingrediants["dough"] = 1;
            Render();
            IsBaking = true;
            progress.gameObject.SetActive(true);
        }
    }
}
