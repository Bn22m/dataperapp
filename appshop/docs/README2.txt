Type 'help;' or '\h' for help. Type '\c' to clear the current input statement.

mysql> ###################################
mysql> #//////////////////////////////
mysql> #//
mysql> #// shopping.sql
mysql> #//
mysql> #//
mysql> #// Author:  Brian
mysql> #//
mysql> #//
mysql> #///////////////////////////////
mysql> ####################################
mysql>
mysql> CREATE DATABASE SHOPPING;
Query OK, 1 row affected (0.00 sec)

mysql>
mysql> USE SHOPPING;
Database changed
mysql>
mysql> CREATE TABLE SHOP (
    ->     id int NOT NULL auto_increment,
    ->     name varchar (30) NOT NULL,
    ->     email varchar (30) NOT NULL,
    ->     password varchar (100) NOT NULL,
    ->     product varchar (100) NOT NULL,
    ->     prodcode varchar (10) NOT NULL,
    ->     price float(10,2) NOT NULL,
    ->     discount float(10,7) NOT NULL,
    ->     total float(10,2) NOT NULL,
    ->     balance float(10,2) NOT NULL,
    ->     datep datetime NOT NULL default '0000/00/00 00:00:00',
    ->     comments text,
    ->     PRIMARY KEY (id)
    ->     );
Query OK, 0 rows affected (0.13 sec)

mysql>
mysql> CREATE TABLE PRODUCTS (
    ->     id int NOT NULL auto_increment,
    ->     name varchar (99) NOT NULL,
    ->     code varchar (10) NOT NULL,
    ->     quantity float(16,8) NOT NULL,
    ->     price float(10,2) NOT NULL,
    ->     discount float(10,7) default 000.0000000,
    ->     datep datetime NOT NULL default '0000/00/00 00:00:00',
    ->     comments text,
    ->     PRIMARY KEY (id)
    ->     );
Query OK, 0 rows affected (0.13 sec)

mysql>
mysql> CREATE TABLE CUSTOMERS (
    ->     id int NOT NULL auto_increment,
    ->     title varchar (30),
    ->     name varchar (30) NOT NULL,
    ->     surname varchar (40) NOT NULL,
    ->     email varchar (30) NOT NULL,
    ->     address varchar (100) NOT NULL,
    ->     password varchar (100) NOT NULL,
    ->     topup float(10,2) NOT NULL,
    ->     balance float(10,2) NOT NULL,
    ->     registered boolean,
    ->     datep datetime NOT NULL default '0000/00/00 00:00:00',
    ->     comments text,
    ->     PRIMARY KEY (id)
    ->     );
Query OK, 0 rows affected (0.06 sec)

mysql>
mysql> CREATE TABLE TRANSACTIONS (
    ->     id int NOT NULL auto_increment,
    ->     user int NOT NULL,
    ->     topup float(10,2),
    ->     purchase float(10,2),
    ->     prodcode varchar (10),
    ->     price float(10,2),
    ->     discount float(10,7),
    ->     balance float(10,2) NOT NULL,
    ->     datep datetime NOT NULL default '0000/00/00 00:00:00',
    ->     comments text,
    ->     PRIMARY KEY (id)
    ->     );
Query OK, 0 rows affected (0.09 sec)

mysql>
mysql> CREATE TABLE DISCOUNTS (
    ->     id int NOT NULL auto_increment,
    ->     pmin int,
    ->     pmax int,
    ->     discount float(10,7),
    ->     comments text,
    ->     datep datetime NOT NULL default '0000/00/00 00:00:00',
    ->     PRIMARY KEY (id)
    ->     );
Query OK, 0 rows affected (0.06 sec)

mysql>
mysql> GRANT ALL ON SHOPPING.* to shopm@localhost identified by 'myp2pw';
Query OK, 0 rows affected (0.05 sec)

mysql>
mysql> INSERT INTO DISCOUNTS (
    ->     pmin,pmax,discount,comments,datep )
    ->     VALUES (
    ->     50,100,0,'Price 50 - 100',now() );
Query OK, 1 row affected (0.08 sec)

mysql>
mysql> INSERT INTO DISCOUNTS (
    ->     pmin,pmax,discount,comments,datep )
    ->     VALUES (
    ->     112,115,0.25,'Price 112 - 115',now() );
Query OK, 1 row affected (0.00 sec)

mysql>
mysql> INSERT INTO DISCOUNTS (
    ->     pmin,discount,comments,datep )
    ->     VALUES (
    ->     120,0.50,'Price > 120',now() );
Query OK, 1 row affected (0.03 sec)

mysql>
mysql> INSERT INTO PRODUCTS (
    ->     name,code,quantity,price,datep,comments )
    ->     VALUES (
    ->     'product01','pr001',999,149.99,now(),'discount values @ discount TABLE.' );
Query OK, 1 row affected (0.01 sec)

mysql>
mysql> INSERT INTO PRODUCTS (
    ->     name,code,quantity,price,datep,comments )
    ->     VALUES (
    ->     'product02','pr002',1999,49.99,now(),'discount values @ discount TABLE.' );
Query OK, 1 row affected (0.00 sec)

mysql>
mysql> INSERT INTO PRODUCTS (
    ->     name,code,quantity,price,datep,comments )
    ->     VALUES (
    ->     'product03','pr003',2999,99.99,now(),'discount values @ discount TABLE.' );
Query OK, 1 row affected (0.01 sec)

mysql>
mysql> INSERT INTO PRODUCTS (
    ->     name,code,quantity,price,datep,comments )
    ->     VALUES (
    ->     'product04','pr004',99,114.99,now(),'discount values @ discount TABLE.' );
Query OK, 1 row affected (0.00 sec)

mysql>
mysql> INSERT INTO PRODUCTS (
    ->     name,code,quantity,price,datep,comments )
    ->     VALUES (
    ->     'product05','pr005',5999,14.99,now(),'discount values @ discount TABLE.' );
Query OK, 1 row affected (0.00 sec)

mysql>
mysql> show tables;
+--------------------+
| Tables_in_shopping |
+--------------------+
| customers          |
| discounts          |
| products           |
| shop               |
| transactions       |
+--------------------+
5 rows in set (0.16 sec)

mysql>
mysql> describe shop;
+----------+--------------+------+-----+---------------------+----------------+
| Field    | Type         | Null | Key | Default             | Extra          |
+----------+--------------+------+-----+---------------------+----------------+
| id       | int(11)      | NO   | PRI | NULL                | auto_increment |
| name     | varchar(30)  | NO   |     | NULL                |                |
| email    | varchar(30)  | NO   |     | NULL                |                |
| password | varchar(100) | NO   |     | NULL                |                |
| product  | varchar(100) | NO   |     | NULL                |                |
| prodcode | varchar(10)  | NO   |     | NULL                |                |
| price    | float(10,2)  | NO   |     | NULL                |                |
| discount | float(10,7)  | NO   |     | NULL                |                |
| total    | float(10,2)  | NO   |     | NULL                |                |
| balance  | float(10,2)  | NO   |     | NULL                |                |
| datep    | datetime     | NO   |     | 0000-00-00 00:00:00 |                |
| comments | text         | YES  |     | NULL                |                |
+----------+--------------+------+-----+---------------------+----------------+
12 rows in set (0.08 sec)

mysql>
mysql> describe products;
+----------+-------------+------+-----+---------------------+----------------+
| Field    | Type        | Null | Key | Default             | Extra          |
+----------+-------------+------+-----+---------------------+----------------+
| id       | int(11)     | NO   | PRI | NULL                | auto_increment |
| name     | varchar(99) | NO   |     | NULL                |                |
| code     | varchar(10) | NO   |     | NULL                |                |
| quantity | float(16,8) | NO   |     | NULL                |                |
| price    | float(10,2) | NO   |     | NULL                |                |
| discount | float(10,7) | YES  |     | 0.0000000           |                |
| datep    | datetime    | NO   |     | 0000-00-00 00:00:00 |                |
| comments | text        | YES  |     | NULL                |                |
+----------+-------------+------+-----+---------------------+----------------+
8 rows in set (0.08 sec)

mysql>
mysql> describe customers;
+------------+--------------+------+-----+---------------------+----------------+
| Field      | Type         | Null | Key | Default             | Extra          |
+------------+--------------+------+-----+---------------------+----------------+
| id         | int(11)      | NO   | PRI | NULL                | auto_increment |
| title      | varchar(30)  | YES  |     | NULL                |                |
| name       | varchar(30)  | NO   |     | NULL                |                |
| surname    | varchar(40)  | NO   |     | NULL                |                |
| email      | varchar(30)  | NO   |     | NULL                |                |
| address    | varchar(100) | NO   |     | NULL                |                |
| password   | varchar(100) | NO   |     | NULL                |                |
| topup      | float(10,2)  | NO   |     | NULL                |                |
| balance    | float(10,2)  | NO   |     | NULL                |                |
| registered | tinyint(1)   | YES  |     | NULL                |                |
| datep      | datetime     | NO   |     | 0000-00-00 00:00:00 |                |
| comments   | text         | YES  |     | NULL                |                |
+------------+--------------+------+-----+---------------------+----------------+
12 rows in set (0.03 sec)

mysql>
mysql> describe transactions;
+----------+-------------+------+-----+---------------------+----------------+
| Field    | Type        | Null | Key | Default             | Extra          |
+----------+-------------+------+-----+---------------------+----------------+
| id       | int(11)     | NO   | PRI | NULL                | auto_increment |
| user     | int(11)     | NO   |     | NULL                |                |
| topup    | float(10,2) | YES  |     | NULL                |                |
| purchase | float(10,2) | YES  |     | NULL                |                |
| prodcode | varchar(10) | YES  |     | NULL                |                |
| price    | float(10,2) | YES  |     | NULL                |                |
| discount | float(10,7) | YES  |     | NULL                |                |
| balance  | float(10,2) | NO   |     | NULL                |                |
| datep    | datetime    | NO   |     | 0000-00-00 00:00:00 |                |
| comments | text        | YES  |     | NULL                |                |
+----------+-------------+------+-----+---------------------+----------------+
10 rows in set (0.01 sec)

mysql>
mysql> describe discounts;
+----------+-------------+------+-----+---------------------+----------------+
| Field    | Type        | Null | Key | Default             | Extra          |
+----------+-------------+------+-----+---------------------+----------------+
| id       | int(11)     | NO   | PRI | NULL                | auto_increment |
| pmin     | int(11)     | YES  |     | NULL                |                |
| pmax     | int(11)     | YES  |     | NULL                |                |
| discount | float(10,7) | YES  |     | NULL                |                |
| comments | text        | YES  |     | NULL                |                |
| datep    | datetime    | NO   |     | 0000-00-00 00:00:00 |                |
+----------+-------------+------+-----+---------------------+----------------+
6 rows in set (0.02 sec)

mysql>
mysql> select * from discounts;
+----+------+------+-----------+-----------------+---------------------+
| id | pmin | pmax | discount  | comments        | datep               |
+----+------+------+-----------+-----------------+---------------------+
|  1 |   50 |  100 | 0.0000000 | Price 50 - 100  | 2018-05-16 20:08:25 |
|  2 |  112 |  115 | 0.2500000 | Price 112 - 115 | 2018-05-16 20:08:25 |
|  3 |  120 | NULL | 0.5000000 | Price > 120     | 2018-05-16 20:08:25 |
+----+------+------+-----------+-----------------+---------------------+
3 rows in set (0.00 sec)

mysql>
mysql> select * from products;
+----+-----------+-------+---------------+--------+-----------+---------------------+---------
--------------------------+
| id | name      | code  | quantity      | price  | discount  | datep               | comments
                          |
+----+-----------+-------+---------------+--------+-----------+---------------------+---------
--------------------------+
|  1 | product01 | pr001 |  999.00000000 | 149.99 | 0.0000000 | 2018-05-16 20:08:25 | discount
 values @ discount TABLE. |
|  2 | product02 | pr002 | 1999.00000000 |  49.99 | 0.0000000 | 2018-05-16 20:08:25 | discount
 values @ discount TABLE. |
|  3 | product03 | pr003 | 2999.00000000 |  99.99 | 0.0000000 | 2018-05-16 20:08:25 | discount
 values @ discount TABLE. |
|  4 | product04 | pr004 |   99.00000000 | 114.99 | 0.0000000 | 2018-05-16 20:08:25 | discount
 values @ discount TABLE. |
|  5 | product05 | pr005 | 5999.00000000 |  14.99 | 0.0000000 | 2018-05-16 20:08:25 | discount
 values @ discount TABLE. |
+----+-----------+-------+---------------+--------+-----------+---------------------+---------
--------------------------+
5 rows in set (0.00 sec)

mysql>
mysql> #
mysql> # Enjoy!
mysql> #
mysql> #;
mysql> \s
