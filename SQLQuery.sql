CREATE TABLE Продукты(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Название nvarchar(max) NOT NULL
);

CREATE TABLE Категории(
	Id INT IDENTITY(1,1)  PRIMARY KEY,
	Название nvarchar(max) NOT NULL
);

CREATE TABLE ПродуктыКатегории(
	Id INT IDENTITY(1,1) PRIMARY KEY (ПродуктID,КатегорииId),
	ПродуктID int CONSTRAINT FK_Продукты_Категории FOREIGN KEY REFERENCES Продукты(Id),	
	КатегорииId INT CONSTRAINT FK_Категории_Продукты FOREIGN KEY REFERENCES Категории(Id)
);

insert into Продукты values --пример с фильмами
(N'Фильм1'),
(N'Фильм2'),
(N'Фильм3'),
(N'ФильмБезКатегории');

insert into Категории values
(N'Боевик'),
(N'Комедия'),
(N'Драма'),
(N'Ужасы'),
(N'Фантастика');

insert into ПродуктыКатегории values
(1,2),
(2,1),
(3,3),
(3,4),
(3,5);

select п.Название, к.Название from Продукты п
left join ПродуктыКатегории пк on п.Id = пк.ПродуктID
left join Категории к on к.Id = пк.КатегорииId
