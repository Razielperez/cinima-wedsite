CREATE TABLE TimeTable(
	name nvarchar(50),
	date nvarchar(50),
	hour nvarchar(50),
	hall nvarchar(50),
	PRIMARY KEY (date,hour,hall)
	);
	delete from TimeTable;

	INSERT INTO TimeTable VALUES('temp2','2021-07-21','11:30','C');
	INSERT INTO TimeTable VALUES('temp1','2021-07-21','11:31','C');
	INSERT INTO TimeTable VALUES('temp3','2021-07-21','11:30','R');
	INSERT INTO TimeTable VALUES('Avengers','2021-07-21','11:30','C');
	INSERT INTO TimeTable VALUES('Avengers','2021-07-21','15:00','C');
	INSERT INTO TimeTable VALUES('Avengers','2021-07-22','18:30','A');
	INSERT INTO TimeTable VALUES('Avengers','2021-07-22','14:40','C');
	INSERT INTO TimeTable VALUES('Avengers','2021-07-22','14:30','A');
	INSERT INTO TimeTable VALUES('Avengers','2021-07-24','19:30','A');
	INSERT INTO TimeTable VALUES('Avengers','2021-07-24','21:00','A');
	INSERT INTO TimeTable VALUES('Avengers','2019-07-21','11:30','C');

	INSERT INTO TimeTable VALUES('Fast and Furious','2021-07-21','08:00','E');
	INSERT INTO TimeTable VALUES('Fast and Furious','2021-07-21','09:00','F');
	INSERT INTO TimeTable VALUES('Fast and Furious','2021-07-21','17:00','E');
	INSERT INTO TimeTable VALUES('Fast and Furious','2021-07-21','12:00','F');
	INSERT INTO TimeTable VALUES('Fast and Furious','2021-07-22','16:00','E');
	INSERT INTO TimeTable VALUES('Fast and Furious','2021-07-23','12:00','B');
	INSERT INTO TimeTable VALUES('Fast and Furious','2021-07-24','11:30','E');

	INSERT INTO TimeTable VALUES('Joker','2021-07-21','13:00','C');
	INSERT INTO TimeTable VALUES('Joker','2021-07-22','17:00','D');
	INSERT INTO TimeTable VALUES('Joker','2021-07-22','09:30','D');
	INSERT INTO TimeTable VALUES('Joker','2021-07-22','20:50','A');
	INSERT INTO TimeTable VALUES('Joker','2021-07-23','22:00','C');
	INSERT INTO TimeTable VALUES('Joker','2021-07-26','21:00','G');

	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-22','10:00','G');
	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-22','12:00','G');
	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-22','14:00','G');
	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-23','19:00','G');
	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-23','22:00','G');
	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-23','22:30','B');
	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-24','13:30','G');
	INSERT INTO TimeTable VALUES('SpongeBob Movie:Rescue operation','2021-07-24','16:20','G');

	INSERT INTO TimeTable VALUES('The Equalizer 2','2021-07-21','16:40','B');
	INSERT INTO TimeTable VALUES('The Equalizer 2','2021-07-22','12:50','B');
	INSERT INTO TimeTable VALUES('The Equalizer 2','2021-07-22','16:50','B');
	INSERT INTO TimeTable VALUES('The Equalizer 2','2021-07-23','17:00','B');
	INSERT INTO TimeTable VALUES('The Equalizer 2','2021-07-23','17:30','F');
	INSERT INTO TimeTable VALUES('The Equalizer 2','2021-07-24','16:20','B');
	INSERT INTO TimeTable VALUES('The Equalizer 2','2021-07-25','11:20','B');

	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-21','12:00','F');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-21','14:50','E');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-22','18:20','B');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-23','20:20','G');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-23','22:20','G');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-23','18:20','G');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-24','19:20','E');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-25','15:50','E');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-25','17:30','F');
	INSERT INTO TimeTable VALUES('Jumanji: Surviving in the Jungle','2021-07-26','11:20','D');

	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-27','14:20','C');
	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-27','17:20','C');
	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-27','19:00','A');
	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-28','13:10','C');
	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-28','14:20','A');
	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-29','09:20','C');
	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-29','10:20','D');
	INSERT INTO TimeTable VALUES('Sonic the Hedgehog','2021-07-29','11:20','C');

	INSERT INTO TimeTable VALUES('Bird Box','2021-07-27','08:20','G');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-27','08:30','D');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-27','10:50','G');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-28','13:30','D');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-28','15:00','D');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-28','17:40','D');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-28','18:00','G');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-28','21:00','D');
	INSERT INTO TimeTable VALUES('Bird Box','2021-07-29','11:00','D');

	INSERT INTO TimeTable VALUES('Venom','2021-07-27','10:00','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-27','13:20','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-27','15:50','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-27','18:30','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-28','09:00','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-28','11:50','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-28','14:00','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-28','17:10','B');
	INSERT INTO TimeTable VALUES('Venom','2021-07-28','20:40','B');

	INSERT INTO TimeTable VALUES('John Wick: Chapter 3','2021-07-27','10:00','G');
	INSERT INTO TimeTable VALUES('John Wick: Chapter 3','2021-07-27','10:40','D');
	INSERT INTO TimeTable VALUES('John Wick: Chapter 3','2021-07-27','13:00','G');
	INSERT INTO TimeTable VALUES('John Wick: Chapter 3','2021-07-28','21:00','B');
	INSERT INTO TimeTable VALUES('John Wick: Chapter 3','2021-07-29','13:00','D');
	INSERT INTO TimeTable VALUES('John Wick: Chapter 3','2021-07-29','15:50','D');
	INSERT INTO TimeTable VALUES('John Wick: Chapter 3','2021-07-29','18:00','D');

	INSERT INTO TimeTable VALUES('The Upside','2021-07-27','10:00','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-27','13:00','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-27','16:30','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-27','19:50','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-28','12:20','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-28','15:00','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-28','18:00','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-28','21:10','F');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-29','11:00','B');
	INSERT INTO TimeTable VALUES('The Upside','2021-07-29','13:50','B');

	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-27','21:00','C');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-27','23:30','C');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-27','22:50','F');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-28','20:00','E');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-28','22:10','E');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-28','13:50','E');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-29','17:50','B');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-29','22:00','B');
	INSERT INTO TimeTable VALUES('Hunter Killer','2021-07-29','23:50','B');

	select * from TimeTable;
