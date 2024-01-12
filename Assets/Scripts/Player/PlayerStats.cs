using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] Beyblade _bb;
    public Beyblade Beyblade => _bb;

    int hp;

    private void Start()
    {
        SetParts();
        hp = _bb.GetTotalStat("Stamina");
    }

    public void Hit(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Debug.Log("You died!");
            Destroy(gameObject);
        }
    }
    public void SetParts()
    {
        foreach(Transform child in gameObject.transform.GetComponentInChildren<Transform>())
        {
            if(child.gameObject.GetComponent<BeybladeComponentHolder>()  != null)
                _bb.SetComp(child.gameObject.GetComponent<BeybladeComponentHolder>().BeybladeComponent);
        }
    }
}
