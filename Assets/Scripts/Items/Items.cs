using UnityEngine;
using UnityEngine.UI;

// [추상클래스] PickupItem 그 자체로는 인스턴스화가 불가능
// 추상 메소드가 포함되어 자식 클래스에서 구현하도록 '강제'할 수 있음
public abstract class Items : MonoBehaviour
{

    protected abstract void OnPurchase(GameObject receiver);
}