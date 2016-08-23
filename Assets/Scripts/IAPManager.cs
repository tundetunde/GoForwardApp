using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager Instance { set; get; }

    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public static string PRODUCT_1_BLUE = "blue1ball";
    public static string PRODUCT_2_BLUE = "blue2ball";
    public static string PRODUCT_5_BLUE = "blue5ball";
    public static string PRODUCT_10_BLUE = "blue10ball";

    public static string PRODUCT_1_YELLOW = "yellow1ball";
    public static string PRODUCT_2_YELLOW = "yellow2ball";
    public static string PRODUCT_5_YELLOW = "yellow5ball";
    public static string PRODUCT_10_YELLOW = "yellow10ball";

    public static string PRODUCT_1_GREEN = "green1ball";
    public static string PRODUCT_2_GREEN = "green2ball";
    public static string PRODUCT_5_GREEN = "green5ball";
    public static string PRODUCT_10_GREEN = "green10ball";

    public static string PRODUCT_1_ORANGE = "orange1ball";
    public static string PRODUCT_2_ORANGE = "orange2ball";
    public static string PRODUCT_5_ORANGE = "orange5ball";
    public static string PRODUCT_10_ORANGE = "orange10ball";

    public static string PRODUCT_1_RED = "red1ball";
    public static string PRODUCT_2_RED = "red2ball";
    public static string PRODUCT_5_RED = "red5ball";
    public static string PRODUCT_10_RED = "red10ball";

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(PRODUCT_1_BLUE, ProductType.Consumable);
        builder.AddProduct(PRODUCT_2_BLUE, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5_BLUE, ProductType.Consumable);
        builder.AddProduct(PRODUCT_10_BLUE, ProductType.Consumable);

        builder.AddProduct(PRODUCT_1_YELLOW, ProductType.Consumable);
        builder.AddProduct(PRODUCT_2_YELLOW, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5_YELLOW, ProductType.Consumable);
        builder.AddProduct(PRODUCT_10_YELLOW, ProductType.Consumable);

        builder.AddProduct(PRODUCT_1_GREEN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_2_GREEN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5_GREEN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_10_GREEN, ProductType.Consumable);

        builder.AddProduct(PRODUCT_1_ORANGE, ProductType.Consumable);
        builder.AddProduct(PRODUCT_2_ORANGE, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5_ORANGE, ProductType.Consumable);
        builder.AddProduct(PRODUCT_10_ORANGE, ProductType.Consumable);

        builder.AddProduct(PRODUCT_1_RED, ProductType.Consumable);
        builder.AddProduct(PRODUCT_2_RED, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5_RED, ProductType.Consumable);
        builder.AddProduct(PRODUCT_10_RED, ProductType.Consumable);

        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void BuyBlueBalls(int amount)
    {
        switch (amount)
        {
            case 1:
                BuyProductID(PRODUCT_1_BLUE);
                break;
            case 2:
                BuyProductID(PRODUCT_2_BLUE);
                break;
            case 5:
                BuyProductID(PRODUCT_5_BLUE);
                break;
            case 10:
                BuyProductID(PRODUCT_10_BLUE);
                break;
        } 
    }

    public void BuyYelllowBalls(int amount)
    {
        switch (amount)
        {
            case 1:
                BuyProductID(PRODUCT_1_YELLOW);
                break;
            case 2:
                BuyProductID(PRODUCT_2_YELLOW);
                break;
            case 5:
                BuyProductID(PRODUCT_5_YELLOW);
                break;
            case 10:
                BuyProductID(PRODUCT_10_YELLOW);
                break;
        }
    }

    public void BuyGreenBalls(int amount)
    {
        switch (amount)
        {
            case 1:
                BuyProductID(PRODUCT_1_GREEN);
                break;
            case 2:
                BuyProductID(PRODUCT_2_GREEN);
                break;
            case 5:
                BuyProductID(PRODUCT_5_GREEN);
                break;
            case 10:
                BuyProductID(PRODUCT_10_GREEN);
                break;
        }
    }

    public void BuyRedBalls(int amount)
    {
        switch (amount)
        {
            case 1:
                BuyProductID(PRODUCT_1_RED);
                break;
            case 2:
                BuyProductID(PRODUCT_2_RED);
                break;
            case 5:
                BuyProductID(PRODUCT_5_RED);
                break;
            case 10:
                BuyProductID(PRODUCT_10_RED);
                break;
        }
    }

    public void BuyOrangeBalls(int amount)
    {
        switch (amount)
        {
            case 1:
                BuyProductID(PRODUCT_1_ORANGE);
                break;
            case 2:
                BuyProductID(PRODUCT_2_ORANGE);
                break;
            case 5:
                BuyProductID(PRODUCT_5_ORANGE);
                break;
            case 10:
                BuyProductID(PRODUCT_10_ORANGE);
                break;
        }
    }

    void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }


    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }


    //  
    // --- IStoreListener
    //

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // A consumable product has been purchased by this user.
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1_BLUE, StringComparison.Ordinal))
        {
            int blue = PlayerPrefs.GetInt("BlueBalls", 0);
            blue++;
            PlayerPrefs.SetInt("BlueBalls", blue);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2_BLUE, StringComparison.Ordinal))
        {
            int blue = PlayerPrefs.GetInt("BlueBalls", 0);
            blue += 2;
            PlayerPrefs.SetInt("BlueBalls", blue);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5_BLUE, StringComparison.Ordinal))
        {
            int blue = PlayerPrefs.GetInt("BlueBalls", 0);
            blue += 5;
            PlayerPrefs.SetInt("BlueBalls", blue);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10_BLUE, StringComparison.Ordinal))
        {
            int blue = PlayerPrefs.GetInt("BlueBalls", 0);
            blue += 10;
            PlayerPrefs.SetInt("BlueBalls", blue);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1_YELLOW, StringComparison.Ordinal))
        {
            int yellow = PlayerPrefs.GetInt("YellowBalls", 0);
            yellow++;
            PlayerPrefs.SetInt("YellowBalls", yellow);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2_YELLOW, StringComparison.Ordinal))
        {
            int yellow = PlayerPrefs.GetInt("YellowBalls", 0);
            yellow += 2;
            PlayerPrefs.SetInt("YellowBalls", yellow);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5_YELLOW, StringComparison.Ordinal))
        {
            int yellow = PlayerPrefs.GetInt("YellowBalls", 0);
            yellow += 5;
            PlayerPrefs.SetInt("YellowBalls", yellow);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10_YELLOW, StringComparison.Ordinal))
        {
            int yellow = PlayerPrefs.GetInt("YellowBalls", 0);
            yellow += 10;
            PlayerPrefs.SetInt("YellowBalls", yellow);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1_GREEN, StringComparison.Ordinal))
        {
            int green = PlayerPrefs.GetInt("GreenBalls", 0);
            green++;
            PlayerPrefs.SetInt("GreenBalls", green);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2_GREEN, StringComparison.Ordinal))
        {
            int green = PlayerPrefs.GetInt("GreenBalls", 0);
            green += 2;
            PlayerPrefs.SetInt("GreenBalls", green);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5_GREEN, StringComparison.Ordinal))
        {
            int green = PlayerPrefs.GetInt("GreenBalls", 0);
            green += 5;
            PlayerPrefs.SetInt("GreenBalls", green);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10_GREEN, StringComparison.Ordinal))
        {
            int green = PlayerPrefs.GetInt("GreenBalls", 0);
            green += 10;
            PlayerPrefs.SetInt("GreenBalls", green);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1_RED, StringComparison.Ordinal))
        {
            int red = PlayerPrefs.GetInt("RedBalls", 0);
            red++;
            PlayerPrefs.SetInt("RedBalls", red);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2_RED, StringComparison.Ordinal))
        {
            int red = PlayerPrefs.GetInt("RedBalls", 0);
            red += 2;
            PlayerPrefs.SetInt("RedBalls", red);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5_RED, StringComparison.Ordinal))
        {
            int red = PlayerPrefs.GetInt("RedBalls", 0);
            red += 5;
            PlayerPrefs.SetInt("RedBalls", red);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10_RED, StringComparison.Ordinal))
        {
            int red = PlayerPrefs.GetInt("RedBalls", 0);
            red += 10;
            PlayerPrefs.SetInt("RedBalls", red);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1_ORANGE, StringComparison.Ordinal))
        {
            int orange = PlayerPrefs.GetInt("OrangeBalls", 0);
            orange++;
            PlayerPrefs.SetInt("OrangeBalls", orange);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2_ORANGE, StringComparison.Ordinal))
        {
            int orange = PlayerPrefs.GetInt("OrangeBalls", 0);
            orange += 2;
            PlayerPrefs.SetInt("OrangeBalls", orange);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5_ORANGE, StringComparison.Ordinal))
        {
            int orange = PlayerPrefs.GetInt("OrangeBalls", 0);
            orange += 5;
            PlayerPrefs.SetInt("OrangeBalls", orange);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10_ORANGE, StringComparison.Ordinal))
        {
            int orange = PlayerPrefs.GetInt("OrangeBalls", 0);
            orange += 10;
            PlayerPrefs.SetInt("OrangeBalls", orange);
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        }
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}