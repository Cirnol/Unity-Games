using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Profile NPCProfile;

    private TextMeshPro Name;
    private float Health;

    void Start()
    {
        Name = GetComponent<TextMeshPro>();
        Name.text = NPCProfile.Name;
        Health = NPCProfile.Health;
    }

    public void TakeDamge(float dealtDamage)
    {
        Health -= dealtDamage;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        transform.position += transform.up * NPCProfile.Speed * Time.deltaTime;
    }

    public void DealDamage(NPC target)
    {
        target.TakeDamge(NPCProfile.Damage);
    }
}
