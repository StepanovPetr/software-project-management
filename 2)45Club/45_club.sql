SELECT 'CREATE DATABASE 45club'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = '45club');

CREATE SCHEMA IF NOT EXISTS 45club AUTHORIZATION AUTHORIZATION postgres;

set schema '45club';

CREATE Table persons
(
 id int PRIMARY KEY,
 last_name varchar NOT NULL,
 first_name varchar NOT NULL,
 phone varchar(11)
);

CREATE Table transports
(
 id int PRIMARY KEY,
 view int NOT NULL,
 date_of_issue date NOT NULL,
 model varchar NOT NULL,
 vin varchar NOT NULL,
 state_sign varchar(11) NOT NULL
);


CREATE Table owners
(
 id int PRIMARY KEY,
 transport_id int NOT NULL,
 person_id int NOT NULL,
 is_active boolean,
 
 FOREIGN KEY (transport_id) REFERENCES transports (id),
 FOREIGN KEY (person_id) REFERENCES persons (id)
);

CREATE Table works
(
 id int PRIMARY KEY,
 transport_id int NOT NULL,
 date_of_work date NOT NULL,
 price int,
 text varchar,

 FOREIGN KEY (transport_id) REFERENCES TRANSPORTS (id)
);