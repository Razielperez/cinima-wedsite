CREATE TABLE OrderTable(
	nameMovie nvarchar(50),
	date nvarchar(50),
	hour nvarchar(50),
	hall nvarchar(50),
	seat nvarchar(50),
	PRIMARY KEY (date,hour,hall,seat)
	);

	
	INSERT INTO OrderTable
	VALUES('Sonic the Hedgehog','2021-04-01' ,'17:00' ,'C','11');
	INSERT INTO OrderTable
	VALUES('Sonic the Hedgehog','2021-04-01' ,'17:00' ,'C','29');
	
	select * from OrderTable;
	delete from OrderTable ;
	