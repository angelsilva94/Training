delete from Brands where 1=1
delete from Categories where 1=1
delete from OrderDetails where 1=1
delete from Orders where 1=1
delete from OrderStatus where 1=1
delete from ProductCategories where 1=1
delete from Products where 1=1
delete from ReviewProducts where 1=1
delete from UserInfoes where 1=1
delete from Users where 1=1


DBCC CHECKIDENT (OrderDetails, RESEED, 0)
DBCC CHECKIDENT (Brands, RESEED, 0)
DBCC CHECKIDENT (Categories, RESEED, 0)
DBCC CHECKIDENT (Orders, RESEED, 0)
DBCC CHECKIDENT (OrderStatus, RESEED, 0)
DBCC CHECKIDENT (Products, RESEED, 0)
DBCC CHECKIDENT (Users, RESEED, 0)