using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] // переменная закрытого типа,
    private GameObject[] _enemyPrefab; // массив объектов шаблонов
    private GameObject _enemy; // текущий враг

    private void Update()
    {
        // Создадаем нового врага, если врагов нет
        // Так можно регулировать кол-во врагов на сцене
        if(_enemy == null)
        {
            int randEnemy = Ramdom.Range(1, _enemyPrefab.length); // случайно выбираем врага
            _enemy = Instantiate(_enemyPrefab[randEnemy]) as GameObject; // создаем клона как игровой объект
            _enemy.transform.position = new Vector3(0, 3, 0); // задаем позицию появления
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0); // поворачиваем
        }
    }
}
