use erste;

insert into osoba(Id,Ime,Prezime,BrojTelefona,Email) VALUES(1,"Marko","Markovic","065/000-000","marko.markovic@mail.com");
insert into osoba(Id,Ime,Prezime,BrojTelefona,Email) VALUES(2,"Mirko","Mirkovic","065/000-000","mirko.mirkovic@mail.com");
insert into osoba(Id,Ime,Prezime,BrojTelefona,Email) VALUES(3,"Nikola","Nikolic","065/000-000","nikola.nikolic@mail.com");
insert into osoba(Id,Ime,Prezime,BrojTelefona,Email) VALUES(4,"Jovan","Jovanovic","065/000-000","jovan.jovanovic@mail.com");

-- lozinka je "lozinka"
insert into administrator(Id,KorisnickoIme,LozinkaHash) values(1,"marko","0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd");
insert into administrator(Id,KorisnickoIme,LozinkaHash) values(2,"mirko","0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd");
insert into sluzbenik(Id,KorisnickoIme,LozinkaHash) values(3,"nikola","0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd");
insert into sluzbenik(Id,KorisnickoIme,LozinkaHash) values(4,"jovan","0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd");

insert into jezik(Id,Naziv) values(1,"Engleski");
insert into jezik(Id,Naziv) values(2,"Njemacki");
insert into jezik(Id,Naziv) values(3,"Francuski");

insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(1,"A1.1",1,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(2,"A1.2",1,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(3,"A2.1",1,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(4,"A2.2",1,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(5,"B1.1",1,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(6,"B1.2",1,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(7,"B2.1",1,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(8,"B2.2",1,'2020-01-20','2020-03-20');

insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(11,"A1.1",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(12,"A1.2",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(13,"A2.1",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(14,"A2.2",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(15,"B1.1",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(16,"B1.2",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(17,"B2.1",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(18,"B2.2",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(19,"C1.1",2,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(20,"C1.2",2,'2020-01-20','2020-03-20');

insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(21,"A1.1",3,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(22,"A1.2",3,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(23,"A2.1",3,'2020-01-20','2020-03-20');
insert into kurs(Id,Nivo,JezikId,DatumOd,DatumDo) values(24,"A2.2",3,'2020-01-20','2020-03-20');

insert into osoba(Id,Ime,Prezime,Email,BrojTelefona) values(5,"Jovana","Jovanovic","jovana.jovanovic","065/000-000");
insert into osoba(Id,Ime,Prezime,Email,BrojTelefona) values(6,"Mira","Mirkovic","mira.mirkovic","065/000-000");

insert into profesor(Id) values(5);
insert into profesor(Id) values(6);