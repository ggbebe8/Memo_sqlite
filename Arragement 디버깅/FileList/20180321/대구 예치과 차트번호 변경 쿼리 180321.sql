use dentop

select * from patient

select ID,chartid into Patient_chartid_20180321 from patient 
select Seq,Name into Apptime_chartid_20180321 from apptime
select c34,c20 into tx0124_chartid_20180321 from TX0124
select * from patient_chartid_20180321 where id = '00000003'


begin tran
while (SELECT COUNT(*) FROM patient WHERE SUBSTRING(c20,1,1) = '0') <> 0
begin
	update patient
	set chartid = SUBSTRING(ChartID,2,len(ChartID)-1) 
	where SUBSTRING(ChartID,1,1) = '0'

end
	select * from patient
commit tran



begin tran
while (SELECT COUNT(*) FROM tx0124 WHERE SUBSTRING(c20,1,1) = '0') <> 0
begin
	update tx0124
	set c20 = SUBSTRING(c20,2,len(c20)-1) 
	where SUBSTRING(c20,1,1) = '0'

end
	select * from tx0124
commit tran



begin tran
while (SELECT COUNT(*) FROM apptime WHERE SUBSTRING(Name,CHARINDEX('/',name)+1,1) = '0' AND AppType = '0' ) <> 0 
begin
	update apptime
	set Name =STUFF(Name,CHARINDEX('/',name)+1,1,'') --SUBSTRING(Name,CHARINDEX('/',name)+2,len(Name)-1) 
	where SUBSTRING(Name,CHARINDEX('/',name)+1,1) = '0' AND AppType = '0'

end
	select * from apptime
commit tran