using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    //Первым делом получаем информацию об ИИ врага, его напишем позже
    private EnemyAI _enemyAI; //ссылка на компонент

    private void Start()
    {
        //Получим данные о EnemyAI (инициализируем врага)
        _enemyAI = GetComponent<EnemyAI>();
    }

    //Реакция на попадание

    public void ReactToHit()
    {
        //Если такой компонент есть
        if (_enemyAI != null)
            _enemyAI.SetAlive(false); //вызываем его открытый метод (Устанавливаем смерть объекта)

        //Запускаем сопрограмму для смерти
        StartCoroutine(DieCoroutine(3));
    }

    //Сопрограмма смерти
    private IEnumerator DieCoroutine(float waitSecond)
    {
        this.transform.Rotate(45, 0, 0); //поворачиваем объект имитируя попадание, позже можно реализовать любую анимацию смерти

        //ждем
        yield return new WaitForSeconds(waitSecond);

        //уничтожаем объект
        Destroy(this.transform.gameObject);
    }
}
