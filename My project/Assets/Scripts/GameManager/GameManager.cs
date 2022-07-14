using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int Level;
    float money;
    private SaveObject Save;
    MoneyManager _MoneyManager;
    [SerializeField] private GameObject EndGamePanel;
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] private TextMeshProUGUI levelText;
    private void Awake()
    {
        PlayerMovement.GameEnded += GameEnded;
        _MoneyManager = MoneyManager.GetInstance();
        _MoneyManager.AddText(MoneyText);
        _MoneyManager.AddMoney(0);
        SaveWorks();
    }
    private void GameEnded()
    {
        //Anlamadigim bir problem cikiyor burada
        EndGamePanel.SetActive(true);
    }
    public void NextLevel()
    {
        Save.Level++;
        Save.Money = _MoneyManager.GetMoney();
        SaveManager.Save(Save);
        SceneManager.LoadScene(Save.Level % 2);
    }
    private void SaveWorks()
    {
        Level = 0;
        Save = SaveManager.Load();
        if (Save?.Level == null)
        {
            Save = new SaveObject();
            Save.Level = 0;
            Save.Money = 0;
            SaveManager.Save(Save);
            _MoneyManager.AddMoney(0);
            levelText.text = "Level 1";
        }
        else
        {
            if(Save.Level % 2 == SceneManager.GetActiveScene().buildIndex)
            {
                levelText.text = "Level " + (Save.Level + 1).ToString();
                money = Save.Money;
                MoneyText.text = money.ToString() + "  $";
                _MoneyManager.SetAllMoney(money);
            }
            else
            {
                SceneManager.LoadScene(Save.Level % 2);
            }
        }
    }
}
