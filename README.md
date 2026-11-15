### 3.LogisticsUnitTests

# LogisticsUnitTests

Модульные тесты для проверки работоспособности серверного API информационной системы «Моя логистика». Проект выполнен в рамках дипломной работы (специальность 09.02.07).

## Что тестируется

* **Авторизация:** проверка метода входа (`Login`), генерация и корректность токена JWT.
* **CRUD-операции сервисов:**
  * Получение записей по ID и списками (`Get`, `GetList`);
  * Создание новых сущностей (`Create`);
  * Обновление существующих записей (`Update`);
  * Удаление данных (`Delete`).
* **Тестируемые сущности:** `Cargo`, `CargoTypes`, `DriverLicence`, `Drivers`, `Requests`, `Requisites`, `Vehicles` и др.

## Стек технологий

* **Язык:** C# / .NET
* **Фреймворк тестирования:** NUnit
* **Клиент тестирования:** gRPC-клиент для взаимодействия с локальным API

## Связанные части проекта

* Серверное приложение: [LogisticsApiServices](https://github.com/Grigory-Mag/LogisticsApiServices)
* Десктопный клиент: [LogisticsClientsApp](https://github.com/Grigory-Mag/LogisticsClientsApp)

## Запуск тестов

1. Убедиться, что серверная часть [LogisticsApiServices](https://github.com/Grigory-Mag/LogisticsApiServices) запущена и доступна база данных.
2. Открыть решение в **Visual Studio**.
3. Открыть окно **Обозреватель тестов (Test Explorer)** (`Тест` -> `Обозреватель тестов`).
4. Нажать **Запустить все тесты** (Run All).
