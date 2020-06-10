insert into Boards(Id, Title) values (1, "Board 1");
insert into Boards(Id, Title) values (2, "Board 2");

insert into Columns(Id, Title, BoardId) values (1, "Test 1", 1 );
insert into Columns(Id, Title, BoardId) values (2, "Test 2", 1 );
insert into Columns(Id, Title, BoardId) values (3, "Test 3", 1 );

insert into Columns(Id, Title, BoardId) values (1, "Test 1", 2 );
insert into Columns(Id, Title, BoardId) values (2, "Test 2", 2 );
insert into Columns(Id, Title, BoardId) values (3, "Test 3", 2 );
insert into Columns(Id, Title, BoardId) values (4, "Test 4", 2 );
insert into Columns(Id, Title, BoardId) values (5, "Test 5", 2 );

insert into Items (Id, Title, Description, BoardId) values(1, "Gå ut med hunden", "Efter jobbet måste detta ske", 1);
insert into Items (Id, Title, Description, BoardId) values(2, "Hämta mat", "Två portioner", 1);
insert into Items (Id, Title, Description, BoardId) values(3, "Städa toa", "Använd grönsåpa", 1);
insert into Items (Id, Title, Description, BoardId) values(4, "Besiktiga bilen", "Föra april", 1);