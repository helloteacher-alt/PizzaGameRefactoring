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
    
    void Start()
    {
        gameObject.GetDeepComponents(pizzaToppingsList);
    }
    
    void Update()
    {
        BakingHandler(); 
    }

    void BakingHandler()
    {
        if (!IsBaking) return;
        Timecount();
        NextTimecount();
    }

    public void Timecount()
    {
        progress.value += 1 * Time.deltaTime;
    }

    public void NextTimecount()
    {
        if (progress.value < progress.maxValue) return;
        IsBaking = false;
        progress.value = 0;
        progress.gameObject.SetActive(false);
        Render();
    }

    public void Place(string ingrediantNamne)
    {
        if (!IsServing)
        {
            if (ingrediants.ContainsKey(ingrediantNamne)){}
            else ingrediants[ingrediantNamne] = 0;
            ingrediantsNameList = new List<string>(ingrediants.Keys);
        }
        else ingrediants.Clear();
        Render();
    }


    public void Render()
    {
        foreach (SpriteRenderer topping in pizzaToppingsList)
        {
            if (ingrediants.ContainsKey(topping.gameObject.name) && ingrediants[topping.gameObject.name] == 1) 
                topping.color = new Color(207f / 255f, 132f / 255f, 46f / 255f);
            else topping.color = Color.white;
            topping.gameObject.SetActive(ingrediants.ContainsKey(topping.gameObject.name) && !IsBaking);
        }
    }

    public void Oven()
    {
        if (IsOven && ingrediants.ContainsKey("dough"))
        {
            ingrediants["dough"] = 1; // set DIRTY to Dough
            Render();
            IsBaking = true;
            progress.gameObject.SetActive(true);
        }
    }
}