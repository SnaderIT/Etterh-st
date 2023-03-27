/****** Script for SelectTopNRows command from SSMS  ******/
select bolig.Bid, bolig.Adresse, bolig.postnr, eier.Eid, eier.fornavn, eier.etternavn, Tlfeiere.tlf
from eierskap
inner join bolig on bolig.Bid = eierskap.Bid
inner join eier on eier.Eid = eierskap.Eid
inner join Tlfeiere on Tlfeiere.Eid	= eier.Eid
where Tlfeiere.tlf = '48406088'