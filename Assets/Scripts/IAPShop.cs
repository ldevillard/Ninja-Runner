using System; 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{
    public Animator anim;
    public Text Coins;

    private string coin100 = "com.logandev.roofninja.coin100";
    private string coin500 = "com.logandev.roofninja.coin500";
    public GameObject RestoreButton;

    void Awake()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
            RestoreButton.SetActive(false);
    }

    void Start()
    {
        AudioFX.Mine.SFXShop();
    }

    public void OnQuit()
    {
        AudioFX.Mine.SFXShop();
        anim.SetBool("Quit", true);
    }

    void Update()
    {
        Coins.text = "" + Score.CoinPoint;
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == coin100)
        {
            Score.Mine.AddCoins(100);
            SaveManager.Save();

            Debug.Log("Successful purchasing 100 coins!");
        }

        if (product.definition.id == coin500)
        {
            Score.Mine.AddCoins(500);
            SaveManager.Save();

            Debug.Log("Successful purchasing 500 coins!");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + " failed because " + failureReason); 
    }
}
 