# Описание API

Запросы посылаются на `http://localhost:5007/`

---------------------------------------------------------------------------

## Описание сущностей базы данных

Предмет:

1) `subject` - название предмета

2) `description` - описание предмета

Ученик:

1) `nickname` - имя ученика

2) `age` - возраст ученика

Оценка:

1) `nickname` - имя ученика

2) `subject` - название предмета

3) `mark` - полученная оценка

---------------------------------------------------------------------------

## GET запросы

---------------------------------------------------------------------------

URL:

`/subjects/get` - получить предмет по его названию

PARAMS:

`subject` - название предмета

ANSWER:

`{result: "NOT_FOUND"}` - предмет не найден

`{subject: "Programming", description: "It is programming"}` - предмет найден

---------------------------------------------------------------------------

URL:

`/subjects/get/all` - получить список всех предметов

PARAMS:

`sort` - флаг сортировки по ID (1 - возрастание, 0 - убывание)

ANSWER:

`[ {subject: "Programming", description: "It is programming"},  {subject: "Science", description: "People love science"} ]` - массив предметов

---------------------------------------------------------------------------

URL:

`/pupils/get/all` - получить список всех учеников

PARAMS:

`sort` - флаг сортировки по ID (1 - возрастание, 0 - убывание)

ANSWER:

`[ {nickname: "Bill", age: 12},  {nickname: "Jack", age: 17} ]` - массив учеников

---------------------------------------------------------------------------

URL:

`/pupils/get/count` - получить количество учеников

PARAMS:

нет параметров

ANSWER:

`{count: 123}` - количество учеников

---------------------------------------------------------------------------

URL:

`/marks/get` - получить оценки ученика по определённому предмету

PARAMS:

`nickname` - имя ученика

`subject` - название предмета

`sort` - флаг сортировки по ID (1 - возрастание, 0 - убывание)

ANSWER:

`[ {mark: 2}, {mark: 5} ]` - массив оценок ученика по предмету

---------------------------------------------------------------------------

## POST запросы

---------------------------------------------------------------------------

URL:

`/database/clear` - удаление всех записей в базе данных

PARAMS:

нет параметров

ANSWER:

`{result: "OK"}` - база данных успешно очищена

---------------------------------------------------------------------------

URL:

`/subjects/add` - добавление нового предмета

PARAMS:

`subject` - название предмета

`description` - описание предмета

ANSWER:

`{result: "OK"}` - предмет успешно добавлен

`{subject: "Programming", description: "It is programming"}` - предмет уже существует в базе данных

---------------------------------------------------------------------------

URL:

`/pupils/add` - добавление нового ученика

PARAMS:

`nickname` - имя ученика

`age` - возраст ученика

ANSWER:

`{result: "OK"}` - ученик успешно добавлен

`{nickname: "Bill", age: 12}` - ученик уже существует в базе данных

---------------------------------------------------------------------------

URL:

`/marks/add` - добавление новой оценки

PARAMS:

`nickname` - имя ученика

`subject` - название предмета

`mark` - полученная оценка

ANSWER:

`{result: "OK"}` - оценка успешно добавлена

`{result: "BAD_NICKNAME_OR_SUBJECT"}` - предмет или ученик не найдены

