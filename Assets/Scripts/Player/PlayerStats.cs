using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] Beyblade _bb;
    public Beyblade Beyblade => _bb;

    int hp;

    private void Start() => hp = _bb.GetTotalStat("Stamina");

    public void Hit(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Debug.Log("You died!");
            Destroy(gameObject);
            GameManager.Get().LevelManager.EndLevel();
        }
    }
}
