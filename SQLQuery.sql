CREATE TABLE ��������(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	�������� nvarchar(max) NOT NULL
);

CREATE TABLE ���������(
	Id INT IDENTITY(1,1)  PRIMARY KEY,
	�������� nvarchar(max) NOT NULL
);

CREATE TABLE �����������������(
	Id INT IDENTITY(1,1) PRIMARY KEY (�������ID,���������Id),
	�������ID int CONSTRAINT FK_��������_��������� FOREIGN KEY REFERENCES ��������(Id),	
	���������Id INT CONSTRAINT FK_���������_�������� FOREIGN KEY REFERENCES ���������(Id)
);

insert into �������� values --������ � ��������
(N'�����1'),
(N'�����2'),
(N'�����3'),
(N'�����������������');

insert into ��������� values
(N'������'),
(N'�������'),
(N'�����'),
(N'�����'),
(N'����������');

insert into ����������������� values
(1,2),
(2,1),
(3,3),
(3,4),
(3,5);

select �.��������, �.�������� from �������� �
left join ����������������� �� on �.Id = ��.�������ID
left join ��������� � on �.Id = ��.���������Id
