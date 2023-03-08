USE [MersulTrenurilor]
GO

/****** Object:  View [dbo].[StatiiSosire]    Script Date: 17/11/2021 19:55:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if OBJECT_ID('StatiiSosire','v') is not null
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
GO


