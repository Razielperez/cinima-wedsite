CREATE TABLE CartTable(
	userName nvarchar(50),
	name nvarchar(50),
	date nvarchar(50),
	hour nvarchar(50),
	seats nvarchar(50),
	subTotal nvarchar(50),
	PRIMARY KEY (userName,name,date,hour,seats)
	);
	
	delete from CartTable;
	
	select * from CartTable;
