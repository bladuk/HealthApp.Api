# HealthApp.Api
Серверная часть мобильного приложения оценки качества питания.

## Эндпоинты
`GET /api/Assessment/{userId}/latest` - получить последнюю оценку качества питания пользователя с рекомендациями

### Пример возвращаемого значения
```json
{
  "createdAt": "2025-07-13T13:52:56.914681Z",
  "currentIntake": [
    {
      "id": "4982b49c-0c60-4797-9d64-b0dcd597b9c2",
      "name": "Калории",
      "unit": "ккал",
      "amount": 1172.42,
      "min": 2500,
      "max": 3500,
      "status": 2
    },
    {
      "id": "639c0dd7-9149-4e76-a086-b83c631bf4d3",
      "name": "Витамин D",
      "unit": "мкг",
      "amount": 6.1,
      "min": 15,
      "max": 30,
      "status": 2
    },
    {
      "id": "f570da3c-3726-45d5-a521-f145c5f5aa12",
      "name": "Витамин C",
      "unit": "мг",
      "amount": 42.39,
      "min": 100,
      "max": 200,
      "status": 2
    },
    {
      "id": "a6714a50-c813-48f1-b214-0c74081eb8bc",
      "name": "Вода",
      "unit": "г",
      "amount": 839.35,
      "min": 1500,
      "max": 1600,
      "status": 2
    }
  ],
  "intakeWithSet": [
    {
      "id": "4982b49c-0c60-4797-9d64-b0dcd597b9c2",
      "name": "Калории",
      "unit": "ккал",
      "amount": 2645.42,
      "min": 2500,
      "max": 3500,
      "status": 0
    },
    {
      "id": "639c0dd7-9149-4e76-a086-b83c631bf4d3",
      "name": "Витамин D",
      "unit": "мкг",
      "amount": 16.6,
      "min": 15,
      "max": 30,
      "status": 0
    },
    {
      "id": "f570da3c-3726-45d5-a521-f145c5f5aa12",
      "name": "Витамин C",
      "unit": "мг",
      "amount": 132.67,
      "min": 100,
      "max": 200,
      "status": 0
    },
    {
      "id": "a6714a50-c813-48f1-b214-0c74081eb8bc",
      "name": "Вода",
      "unit": "г",
      "amount": 1500.0,
      "min": 1500,
      "max": 1600,
      "status": 0
    }
  ],
  "set": {
    "id": "85a73de0-a713-4d11-9279-e34180b3f9b2",
    "price": 1499,
    "items": [
      {
        "id": "64626826-5d61-435a-af39-1a88108e156e",
        "name": "Витаминный комплекс ED Smart",
        "imageUrl": "https://example.com/images/ed-smart.jpg",
        "shopUrl": "https://shop.example.com/ed-smart"
      },
      {
        "id": "d1563460-cbdf-4485-bfa0-c66b8ad6a1c2",
        "name": "Коллаген с витамином C",
        "imageUrl": "https://example.com/images/collagen-c.jpg",
        "shopUrl": "https://shop.example.com/collagen-c"
      }
    ]
  }
}
```

## База данных
### ER-диаграмма
![ERD](https://github.com/bladuk/HealthApp.Api/blob/main/Assets/erd.png)
### Описание
- `User` - учетные записи пользователей;
- `Assessment` - пройденные анкеты;
- `Nutrient` - список нутриентов;
- `NutrientIntake` - потребление нутриентов пользователем анкеты;
- `Set` - рекомендованный набор товаров;
- `SetItem` - товар в наборе;
- `ItemNutrient` - нутриенты в товаре.

## Статус нутриентов
Норма нутриента задаётся в `Nutrient.min` и `Nutrient.max`
- `amount` < `min` - дефицит
- `amount` < `(min + max)` / `2` - недостаток
- Иначе - норма
