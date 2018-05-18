###################################
#//////////////////////////////
#// 
#// shopping.sql
#//
#//
#// Author:  Brian
#//  
#//
#///////////////////////////////
####################################

CREATE DATABASE SHOPPING;

USE SHOPPING;

CREATE TABLE SHOP (
    id int NOT NULL auto_increment,
    name varchar (30) NOT NULL,
    email varchar (30) NOT NULL,
    password varchar (100) NOT NULL,
    product varchar (100) NOT NULL,
    prodcode varchar (10) NOT NULL,
    price float(10,2) NOT NULL,
    discount float(10,7) NOT NULL,
    total float(10,2) NOT NULL,
    balance float(10,2) NOT NULL,
    datep datetime NOT NULL default '0000/00/00 00:00:00',
    comments text,
    PRIMARY KEY (id)
    );

CREATE TABLE PRODUCTS (
    id int NOT NULL auto_increment,
    name varchar (99) NOT NULL,
    code varchar (10) NOT NULL,
    quantity float(16,8) NOT NULL,
    price float(10,2) NOT NULL,
    discount float(10,7) default 000.0000000,
    datep datetime NOT NULL default '0000/00/00 00:00:00',
    comments text,
    PRIMARY KEY (id)
    );

CREATE TABLE CUSTOMERS (
    id int NOT NULL auto_increment,
    title varchar (30),
    name varchar (30) NOT NULL,
    surname varchar (40) NOT NULL,
    email varchar (30) NOT NULL,
    address varchar (100) NOT NULL,
    password varchar (100) NOT NULL,
    topup float(10,2) NOT NULL,
    balance float(10,2) NOT NULL,
    registered boolean,
    datep datetime NOT NULL default '0000/00/00 00:00:00',
    comments text,
    PRIMARY KEY (id)
    );

CREATE TABLE TRANSACTIONS (
    id int NOT NULL auto_increment,
    user int NOT NULL,
    topup float(10,2),
    purchase float(10,2),
    prodcode varchar (10),
    price float(10,2),
    discount float(10,7),
    balance float(10,2) NOT NULL,
    datep datetime NOT NULL default '0000/00/00 00:00:00',
    comments text,
    PRIMARY KEY (id)
    );

CREATE TABLE DISCOUNTS (
    id int NOT NULL auto_increment,
    pmin int,
    pmax int,
    discount float(10,7),
    comments text,
    datep datetime NOT NULL default '0000/00/00 00:00:00',
    PRIMARY KEY (id)
    );

GRANT ALL ON SHOPPING.* to shopm@localhost identified by 'myp2pw';

INSERT INTO DISCOUNTS (
    pmin,pmax,discount,comments,datep )
    VALUES (
    50,100,0,'Price 50 - 100',now() );

INSERT INTO DISCOUNTS (
    pmin,pmax,discount,comments,datep )
    VALUES (
    112,115,0.25,'Price 112 - 115',now() );

INSERT INTO DISCOUNTS (
    pmin,discount,comments,datep )
    VALUES (
    120,0.50,'Price > 120',now() );

INSERT INTO PRODUCTS (
    name,code,quantity,price,datep,comments )
    VALUES (
    'product01','pr001',999,149.99,now(),'discount values @ discount TABLE.' );

INSERT INTO PRODUCTS (
    name,code,quantity,price,datep,comments )
    VALUES (
    'product02','pr002',1999,49.99,now(),'discount values @ discount TABLE.' );

INSERT INTO PRODUCTS (
    name,code,quantity,price,datep,comments )
    VALUES (
    'product03','pr003',2999,99.99,now(),'discount values @ discount TABLE.' );

INSERT INTO PRODUCTS (
    name,code,quantity,price,datep,comments )
    VALUES (
    'product04','pr004',99,114.99,now(),'discount values @ discount TABLE.' );

INSERT INTO PRODUCTS (
    name,code,quantity,price,datep,comments )
    VALUES (
    'product05','pr005',5999,14.99,now(),'discount values @ discount TABLE.' );

show tables;

describe shop;

describe products;

describe customers;

describe transactions;

describe discounts;

select * from discounts;

select * from products;

#
# Enjoy!
#
#;
\s