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
        
        // ������ ���� ��ư�� ���� �̺�Ʈ �߰�
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

    // ���� �޴� ����
    void OpenShopMenu()
    {
        ShopMenu.SetActive(true);
    }

    // ���� �޴� �ݱ�
    void QuitShopMenu()
    {
        ShopMenu?.SetActive(false);
    }

    // ������ ����
    void Purchase()
    {
        itemSO = GetComponent<ItemSO>();
        currency.Buy(itemSO.price);
    }
}
