using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultsScreenController : MonoBehaviour
{

    [SerializeField] GameObject XPText;
    [SerializeField] GameObject statsText;
    [SerializeField] GameObject currencyText;
    public specimen2 spec;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(setValues());
        if(Results.getXPGained() >= 0)
        {
            XPText.GetComponent<TextMeshProUGUI>().text = "XP Gained: " + Results.getXPGained();
        }
        else
        {
            XPText.GetComponent<TextMeshProUGUI>().text = "XP Lost: " + Results.getXPGained();
        }

        if (Results.getIntelligenceGained() > 0){
            statsText.GetComponent<TextMeshProUGUI>().text = "Intelligence Gained: " + Results.getIntelligenceGained();
        } 
        else if (Results.getIntelligenceGained() < 0) statsText.GetComponent<TextMeshProUGUI>().text = "Intelligence Lost: " + Results.getIntelligenceGained();
        else if (Results.getEnduranceGained() > 0){
            statsText.GetComponent<TextMeshProUGUI>().text = "Endurance Gained: " + Results.getEnduranceGained();
        } 
        else if (Results.getEnduranceGained() < 0) statsText.GetComponent<TextMeshProUGUI>().text = "Endurance Lost: " + Results.getEnduranceGained();
        else if (Results.getStrengthGained() > 0) statsText.GetComponent<TextMeshProUGUI>().text = "Strength Gained: " + Results.getStrengthGained();
        else if (Results.getStrengthGained() < 0) statsText.GetComponent<TextMeshProUGUI>().text = "Strength Lost: " + Results.getStrengthGained();
        else statsText.GetComponent<TextMeshProUGUI>().text = "No stats gained/lost";
        //SpecimenBase
        spec.xp += Results.getXPGained();
        spec.intelligence += Results.getIntelligenceGained();
        spec.endurance += Results.getEnduranceGained();
        spec.strength += Results.getStrengthGained();
        spec.currency += Results.getCurrencyGained();
        currencyText.GetComponent<TextMeshProUGUI>().text = "Currency Gained: " + Results.getCurrencyGained();
    }

    public void returnToOpenWorld()
    {
        spec.SavePlayer();
        SceneManager.LoadScene("OpenWorld");
    }

    IEnumerator setValues(){
        //yield return new WaitForSeconds(1);
        spec.LoadPlayer();
        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TestGameManager.testVar);
    }
}
