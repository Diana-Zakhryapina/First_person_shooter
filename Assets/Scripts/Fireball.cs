using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f; //скорость движения
    public int damage = 1; // наносимый урон

    private void Update()
    {
        // У огненного шара постоянное движение вперед
        transform.Translate(0, 0, speed*Time.deltaTime);
    }

    // Когда с тригером столкнется другой объект, вызывается этот метод
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name); // выводим информацию в консоль: с кем столкнулся объект

        PlayerCharacter player = other.GetComponent<PlayerCharacter>(); // проверяем other на наличие компонента PlayerCharacter
        if(player != null) // если PlayerCharacter все-таки есть
        {
            player.Hurt(damage);
        }

        Destroy(this.gameObject); // разрушаем файерболл
    }
}
