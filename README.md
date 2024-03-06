# MediaService
=======
# Команда 22 - Система управления контентом для СМИ и новостных порталов

## Состав команды

- Цой Степан Алексеевич
- Шуняев Владимир Владимирович
- Трубников Андрей Павлович
- Дерещук Татьяна Евгеньевна
- Евдокимова Ульяна Владимировна

# Доменные Сущности


![image_2024-03-03_15-22-01](https://github.com/v1vid/MediaService/assets/112978007/b814ebc4-47b5-45d5-9dd5-e0e4349fce96)

## User

Представляет пользователя в системе.

```csharp
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
}
```

## Role

Определяет роль в системе, которая может быть присвоена пользователю.

```csharp
public class Role
{
    public string RoleType { get; set; }
    public string Description { get; set; }
}
```

## Role

Связь между пользователями и ролями (многие ко многим).

```csharp
public class Role
{
    public string RoleType { get; set; }
    public string Description { get; set; }
}
```

## Tag

Тег, который может быть связан со статьёй или новостью.

```csharp
public class Tag
{
    public int TagId { get; set; }
    public string Name { get; set; }
}
```

## Page

Страница в системе, которая может содержать статьи или новости.

```csharp
public class Page
{
    public int PageId { get; set; }
    public string Title { get; set; }
    public virtual ArticleOrNews ArticleOrNews { get; set; }
}
```

## ArticleOrNews

Статья или новость, которая содержит контент, дату публикации и теги.

```csharp
public class ArticleOrNews
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
}
```

## Search

Система поиска и фильтрации, которая используется для нахождения статей и новостей по тегам.

```csharp
public class Search
{
    public int UserId { get; set; }
    public int TagId { get; set; }
    public virtual User User { get; set; }
    public virtual Tag Tag { get; set; }
}
```

# Методы работы

## 1. Запросить код для авторизации по email - POST api/v1/auth/verification-code

```json
request - {
  "email": "..."
}
```

## 2. Авторизация по email - POST api/v1/auth/login

```json
request - {
  "email": "...",
  "verification_code": "012345"
}
```

response - выставляется cookie SID

## 3. Получить статью - GET api/v1/articles/{articleID}

Параметры запроса:
articleID - ID статьи

```json
response - {
    "id": "..."
    "title": "..."
    "content": "..."
    "publication_date": "..."
    "tags": [...]
}
```

## 4. Получение всех статей пользователя - GET api/v1/users/{usedId}/articles

Параметры запроса:
usedId - ID пользователя

```json
response - {
    "articles" : [
        "id": "..."
        "title": "..."
        "content": "..."
        "publication_date": "..."
        "tags": [...]
    ]
}
```

## 5. Добавить статью - POST api/v1/articles

Для запросы необходимо иметь cookie SID, чтобы авторизовать пользователя

```json
request - {
    "title": "..."
    "content": "..."
    "tags": [...]
}
```

Код 200

```json
response - {
    "article_id": "..."
}
```

ИЛИ

Код 400/403

```json
response - {
    "details": "..."
}
```

## 6. Добавить теги к статье - PUT api/v1/articles/{articleId}/tags

Параметры запроса:
articleID - ID статьи

```json
request - {
    "tags": ["...", "..."]
}
```

Код 200

ИЛИ

Код 400/403

```json
response - {
    "details": "..."
}
```

## 7. Удалить теги у статьи - DELETE api/v1/articles/{articleId}/tags

Параметры запроса:
articleID - ID статьи

```json
request - {
    "tags": ["...", "..."]
}
```

Код 200

ИЛИ

Код 400/403

```json
response - {
    "details": "..."
}
```

## 8. Найти статьи по тегам - GET api/v1/articles/find

```json
request - {
    "tags": ["...", "..."]
}
```

```json
response - {
    "articles" : [
        "id": "..."
        "title": "..."
        "content": "..."
        "publication_date": "..."
        "tags": [...]
    ]
}
```