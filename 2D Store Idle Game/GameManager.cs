using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    double CurrentMoney;
    public Text CurrentMoneyText;
    void Start()
    {
        CurrentMoney = 0.0;
        CurrentMoneyText.text = CurrentMoney.ToString("N2");
    }

    ///<summary>
    ///A function to add money to the main money amount.
    ///</summary>
    ///<param name="Amount">
    ///Amount set to add money.
    ///</param>

    public void AddToMoney(double Amount){
        CurrentMoney += Amount;
        CurrentMoneyText.text = CurrentMoney.ToString("N2");
    }
    ///<summary>
    ///A function to remove money to the main money amount.
    ///</summary>
    ///<param name="Amount">
    ///Amount set to remove money.
    ///</param>
    public void RemoveToMoney(double Amount){
        CurrentMoney -= Amount;
        CurrentMoneyText.text = CurrentMoney.ToString("N2");
    }
    ///<summary>
    ///A Function to check whether the player can buy new stores.
    ///</summary>
    ///<param name="Amount">
    ///Amount about store price.
    ///</param>
    public bool CanBuy(double Amount){
        if (Amount>CurrentMoney){
            return false;
        }else{
            return true;
        }
    }
}
