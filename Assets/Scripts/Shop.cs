using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Button ShopBtn;
    public Button QuitBtn;
    public Button[] PurchaseBtns;

    public GameObject ShopMenu;

    private Currency currency;
    private ItemSO itemSO;

    // Start is called before the first frame update
    void Start()
    {
        ShopBtn.onClick.AddListener(OpenShopMenu);
        QuitBtn.onClick.AddListener(QuitShopMenu);
        
        // 아이템 구매 버튼에 구매 이벤트 추가
        PurchaseBtns = GetComponentsInChildren<Button>();
        for (int i = 0; i < PurchaseBtns.Length; i++)
        {
            PurchaseBtns[i].onClick.AddListener(Purchase);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 상점 메뉴 열기
    void OpenShopMenu()
    {
        ShopMenu.SetActive(true);
    }

    // 상점 메뉴 닫기
    void QuitShopMenu()
    {
        ShopMenu?.SetActive(false);
    }

    // 아이템 구매
    void Purchase()
    {
        itemSO = GetComponent<ItemSO>();
        currency.Buy(itemSO.price);
    }
}
