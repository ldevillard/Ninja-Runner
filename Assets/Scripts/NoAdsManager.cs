using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class NoAdsManager : MonoBehaviour
{
    private string NoAdsID = "com.logandev.roofninja.noads";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == NoAdsID)
        {
            Ads.NoAds = true;
            SaveManager.Save();
            Debug.Log("Successful purchasing noAds!");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + " failed because " + failureReason);
    }
}
