
using UnityEngine;
using UnityEngine.UI;


public class healthbr : MonoBehaviour
{
    [SerializeField] private lives curhealth;
    [SerializeField] private Image totalhealth;
    [SerializeField] private Image nowhealth;
    void Start()
    {
        totalhealth.fillAmount = curhealth.currhealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        nowhealth.fillAmount = curhealth.currhealth / 10; 
    }
}
