-- Bulk Data Insertion in SQL Table using Union ALL
CREATE TABLE DummyProduct (
    ProductID int,
    ProductName varchar(255),
    ProductDescription varchar(255),
    ProductPrice varchar(255),
    ProductStock varchar(255)
);

--
select 1, 'Mobile', 'IPhone 12', 80000, 200
UNION ALL
select 2, 'Laptop', 'HP Pavilion 15', 100000, 100
UNION ALL
select 3, 'TV', 'Samsung Smart TV', 35000, 300

--
INSERT into Product
select 1, 'Mobile', 'IPhone 12', 80000, 200
UNION ALL
select 2, 'Laptop', 'HP Pavilion 15', 100000, 100
UNION ALL
select 3, 'TV', 'Samsung Smart TV', 35000, 300


--Insert data in bulk
INSERT into DummyProduct
select * from Product
UNION ALL
select 4, 'Keyboard', 'HP Gaming Keyboard', 2000, 400


--select all the record
select * from DummyProduct

