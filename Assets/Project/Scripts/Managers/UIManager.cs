using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menuControl;
    public Button battleStartButton;
    public Button returnButton;
    public Text resultText;
    public Text warningText;
    int maxHeroCount;


    private void Awake()
    {
        Restart();
    }

    private void OnEnable()
    {
        EventManager.chosenHeroCount += ChosenHeroCount;
        EventManager.playerCountInGame += SetMaxHeroCount;
        EventManager.playerLostGame += OnBattleLost;
        EventManager.playerWinGame += OnBattleWon;
    }

    private void OnDisable()
    {
        EventManager.chosenHeroCount -= ChosenHeroCount;
        EventManager.playerCountInGame -= SetMaxHeroCount;
        EventManager.playerLostGame -= OnBattleLost;
        EventManager.playerWinGame -= OnBattleWon;
    }

    private void Start()
    {
        warningText.text = "PICK " + maxHeroCount + " HEROES";
    }

    private void SetMaxHeroCount(int count)
    {
        maxHeroCount = count;
    }

    // to activate start button we check chosen hero count
    private void ChosenHeroCount(int count)
    {
        if (count == maxHeroCount)
        {
            battleStartButton.gameObject.SetActive(true);
        }
        else
        {
            battleStartButton.gameObject.SetActive(false);
        }
    }

    // if start button clicked we close menu and start button
    public void BattleStart()
    {
        battleStartButton.gameObject.SetActive(false);
        warningText.text = "PICK A HERO TO ATTACK";
        EventManager.onBattleStarts?.Invoke();
    }

    public void Restart()
    {
        warningText.gameObject.SetActive(true);
        menuControl.SetActive(true);
        battleStartButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        EventManager.onMenuActive?.Invoke();
    }

    public void OnBattleLost()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "YOU LOST";
        returnButton.gameObject.SetActive(true);
    }

    private void OnBattleWon()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "YOU WIN";
        returnButton.gameObject.SetActive(true);
    }
}
