using UnityEngine;
using UnityEngine.UI;

public class Stores : MonoBehaviour
{
    public GameManager GameManager;
    public Text storeCountText;
    public Slider storeAutoSlider;
    [Header("Settings")]
    public int storeCount;
    public double storeCost;
    public double storeProfit;
    public double autoStoreCost;
    public float storeAutoTimer = 4f;
    float currentTimer = 0;
    bool autoClick;
    void Start(){
        GameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (autoClick){
            currentTimer += Time.deltaTime;
            if (currentTimer > storeAutoTimer){
                currentTimer = 0f;
                GameManager.AddToMoney(storeProfit * storeCount);
            }
            storeAutoSlider.value = currentTimer / storeAutoTimer;
        }
    }
    public void BuyStore(){
        if (!GameManager.CanBuy(storeCost))
            return;
        storeCount = storeCount + 1;
        storeCountText.text = "Store Count: "+storeCount.ToString();
        GameManager.RemoveToMoney(storeCost);
        
    }
    public void StoreClick(){
        GameManager.AddToMoney(storeProfit * storeCount);
    }
    public void BuyAutoClick(){
        if (!GameManager.CanBuy(autoStoreCost))
            return;
        if(!autoClick){
            GameManager.RemoveToMoney(autoStoreCost);
            autoClick = true;
        }
    }
}
