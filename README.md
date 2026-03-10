# FrameworksPractice1

Мини-веб-служба на **ASP.NET Core Minimal API** для практической работы по дисциплине **«Технологии разработки приложений на базе фреймворков»**.

Проект демонстрирует:

- построение **конвейера обработки запросов** через middleware;
- работу с **Minimal API**;
- хранение данных **в памяти процесса**;
- единый формат ошибок;
- валидацию входных данных;
- базовую архитектуру с разделением на **Domain / Services / Middlewares / Errors**.

## О проекте

Приложение реализует простой API для работы с сущностью **Item**.

Модель элемента:

- `Id: Guid`
- `Name: string`
- `Price: decimal`

Данные сохраняются в **in-memory** репозитории на базе `ConcurrentDictionary`, то есть без базы данных. Это соответствует формату учебного задания, где требуется небольшая веб-служба с хранением данных в памяти процесса. :contentReference[oaicite:2]{index=2} :contentReference[oaicite:3]{index=3}

## Стек

- **C#**
- **.NET / ASP.NET Core Minimal API**
- **Middleware pipeline**
- **In-memory repository**
- **System.Text.Json**

## Структура проекта

```text
FrameworksPractice1/
├── Domain/
│   ├── CreateItemRequest.cs
│   ├── ErrorResponse.cs
│   └── Item.cs
├── Errors/
│   ├── DomainException.cs
│   ├── NotFoundException.cs
│   └── ValidationException.cs
├── Middlewares/
│   ├── ErrorHandlingMiddleware.cs
│   ├── RequestIdMiddleware.cs
│   └── TimingAndLogMiddleware.cs
├── Services/
│   ├── InMemoryItemRepository.cs
│   ├── ItemRepository.cs
│   └── RequestId.cs
├── Program.cs
└── appsettings.json
