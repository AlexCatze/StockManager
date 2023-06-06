# Менеджер приймання та обліку на складі

---

## Задачі:

- Підтрика декількох типів товарів. Кожен тип товару повинен мати: назву, опис, фото, унікальний номер що можна закодувати в штрих-код(2D або 1D)
- Реєстрація кількості товару на складі.
- Контроль надходження/видачі товару зі складу. 
- Формування звітів про обіг товарів на складі.

---

## Загальна архітектура рішення

Проект складаєтся з серверного та клієнтського ПЗ. Сервер написано на ASP.NET MVC 6. Сервер дозволяє через WEB-сторінку керувати переліком складів та типів товарів, також надає HTTP API для роботи клієнта.

Клієнт написано на .NET Compact Framework. Клієнт з'єднуєтся з сервером через HTTP та за допомогою аппаратних засобів терміналу дозволяє вести автоматизований облік на складі.

---
## Структура бази даних

База даних складаєтся з 4х таблиць:
- Stocks – містить інформацію про доступні склади
- ItemTypes – містить перелік типів товарів
- Items – містить інформацію про наявні товари
- Transactions – історія операцій з товарами

---

## Використана під час розробки документація

- ASP.NET overview - [https://learn.microsoft.com/en-us/aspnet/overview](https://learn.microsoft.com/en-us/aspnet/overview)
- Entity Framework documentation hub - [https://learn.microsoft.com/en-us/ef/](https://learn.microsoft.com/en-us/ef/)
- Common Device Control Library. Manual For Developers. - CASIO Computer Co., Ltd. 
- IT-3000 Series .NET Library Manual - CASIO Computer Co., Ltd.
- .NET Compact Framework MSDN library

---