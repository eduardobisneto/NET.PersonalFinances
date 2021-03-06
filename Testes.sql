/****** Script do comando SelectTopNRows de SSMS  ******/
use PersonalFinancesDatabase

SELECT * FROM AccountNature
SELECT * FROM AccountType
SELECT * FROM OperationType
SELECT * FROM Account
SELECT * FROM AccountMovement

SELECT * FROM Account

insert into Account (CreatedDate,statusid,accountid,accounttypeid,accountnatureid, description) values (getdate(),1,4,2,2,'Party')

select
	a.id Id,
	a.AccountId AccountId,
	a.Description,
	isnull(sum(am.Amount), 0) Amount,
	month(convert(date, am.DueDate)) Date
from  account a
left join AccountMovement am
on am.AccountId = a.Id
where 1=1
--and month(am.DueDate) = 7
--and day(am.DueDate) between 13 and 20
group by 
	a.Id,
	a.AccountId,
	a.Description,
	month(convert(date, am.DueDate))

SELECT 
    [Extent1].[Id] AS [Id], 
    [Extent1].[StatusId] AS [StatusId], 
    [Extent1].[AccountId] AS [AccountId], 
    [Extent1].[AccountTypeId] AS [AccountTypeId], 
    [Extent1].[AccountNatureId] AS [AccountNatureId], 
    [Extent1].[CreatedDate] AS [CreatedDate], 
    [Extent1].[ModifiedDate] AS [ModifiedDate], 
    [Extent1].[Description] AS [Description]
    FROM [dbo].[Account] AS [Extent1]