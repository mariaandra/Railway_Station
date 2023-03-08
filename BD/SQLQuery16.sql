USE [MersulTrenurilor]
GO

/****** Object:  View [dbo].[StatiiPlecare]    Script Date: 17/11/2021 19:59:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if OBJECT_ID('StatiiPlecare','v') is not null
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

GO


