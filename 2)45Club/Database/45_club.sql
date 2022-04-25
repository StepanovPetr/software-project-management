CREATE Table PERSONS
(
 ID int PRIMARY KEY,
 LastName varchar NOT NULL,
 FirstName varchar NOT NULL,
 MidleName varchar,
 Phome varchar(11)
);

CREATE Table TRANSPORTS
(
 ID int PRIMARY KEY,
 View int NOT NULL,
 DateOfIssue date NOT NULL,
 Model varchar NOT NULL,
 Win varchar NOT NULL,
 StateSign varchar(11) NOT NULL
);