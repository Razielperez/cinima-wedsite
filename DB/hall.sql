CREATE TABLE HallTable(
	name nvarchar(50),
	numSeat integer,
	PRIMARY KEY (name)
	);
	
	delete from HallTable;
	INSERT INTO HallTable VALUES('A',36);
	INSERT INTO HallTable VALUES('B',26);
	INSERT INTO HallTable VALUES('C',46);
	INSERT INTO HallTable VALUES('D',33);
	INSERT INTO HallTable VALUES('E',50);
	INSERT INTO HallTable VALUES('F',42);
	INSERT INTO HallTable VALUES('G',40);

	
	select * from HallTable;