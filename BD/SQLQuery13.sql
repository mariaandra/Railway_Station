--create view StatiiPlecare as
--select T.IDTren,Tip_Tren,Ora_sosire,Ora_plecare,S.Nume_statie
--from Program
--inner join Rute as R
--on R.IDRuta=Program.IDRuta
--inner join Trenuri as T
--on T.IDTren=R.IDTren
--inner join Statii as S
--on S.IDStatie=R.IDStatie
--where Ora_sosire IS NULL;

--create view StatiiSosire as
--select T.IDTren,Tip_Tren,Ora_sosire,Ora_plecare,S.Nume_statie
--from Program
--inner join Rute as R
--on R.IDRuta=Program.IDRuta
--inner join Trenuri as T
--on T.IDTren=R.IDTren
--inner join Statii as S
--on S.IDStatie=R.IDStatie
--where Ora_plecare IS NULL;

select IDTren,Tip_Tren,Data
from StatiiPlecare
where Nume_statie='Galati'
intersect
select IDTren,Tip_Tren,Data
from StatiiSosire
where Nume_statie='Bucuresti Nord'

select IDTren,Tip_Tren,Ora_sosire,Ora_plecare,Nume_statie,Data
from StatiiPlecare as SP
inner join StatiiSosire as SS
on SP.IDTren=SS.IDTren

with Plecare (IDTren,Tip_Tren,Ora_sosire,Ora_plecare,Nume_statie,Ziua) as
(
Select IDTren,Tip_Tren,Ora_sosire,Ora_plecare,Nume_statie,Ziua
From StatiiPlecare
Where Nume_statie='Galati'
)

Select S.IDTren,S.Tip_Tren,P.Ora_plecare,S.Ora_sosire,S.Ziua
From StatiiSosire as S
inner join Plecare as P
on S.IDTren=P.IDTren
Where S.Nume_statie='Bucuresti Nord'