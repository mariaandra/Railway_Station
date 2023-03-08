if OBJECT_ID('StatiiSosire','V') is not null
drop view StatiiSosire
go
create view [dbo].[StatiiSosire] as
select T.IDTren,Tip_Tren,Ora_sosire,Ora_plecare,S.Nume_statie,Program.Ziua
from Program
inner join Rute as R
on R.IDRuta=Program.IDRuta
inner join Trenuri as T
on T.IDTren=R.IDTren
inner join Statii as S
on S.IDStatie=R.IDStatie
where Ora_plecare IS NULL;

if OBJECT_ID('StatiiPlecare','V') is not null
drop view StatiiPlecare
go
create view [dbo].[StatiiPlecare] as
select T.IDTren,Tip_Tren,Ora_sosire,Ora_plecare,S.Nume_statie,Program.Ziua
from Program
inner join Rute as R
on R.IDRuta=Program.IDRuta
inner join Trenuri as T
on T.IDTren=R.IDTren
inner join Statii as S
on S.IDStatie=R.IDStatie
where Ora_sosire IS NULL;


with Plecare (IDTren,Tip_Tren,Ora_sosire,Ora_plecare,Nume_statie,Ziua) as
(
	Select IDTren,Tip_Tren,Ora_sosire,Ora_plecare,Nume_statie,Ziua
	From StatiiPlecare
	Where Nume_statie='Galati'
	AND Ziua='2021-11-15'
)

Select S.IDTren,S.Tip_Tren,P.Ora_plecare,S.Ora_sosire,S.Ziua
From StatiiSosire as S
inner join Plecare as P
on S.IDTren=P.IDTren
Where S.Nume_statie='Bucuresti Nord'
AND S.Ziua='2021-11-15'
