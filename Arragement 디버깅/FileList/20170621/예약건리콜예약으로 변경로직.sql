   --1. 해당 예약건들 조회 로직 (필요한 조건은 그때그때마다 변경됨 이번건은 그외예약 및 미등록환자건이 없었음)
   SELECT *
  FROM AppTime
 WHERE AppTime = '09:00' 
   AND Valid = 'Y'
    AND AppDate > '20170620'
   AND AppType = '0'  -- 일반예약일 경우 apptype  = '0'  다른값에 대한 정보는 액셀 테이블 레이아웃 참고
   
   
   
   
  --2. 조회한 결과에 대하여  리콜테이블과 비교 ( 일반 예약건을 리콜건으로 변경해달라고 요청이 왔기 때문 )
  -- 같은 예약화면에서는 보이지만 실질적으로는 리콜은 리콜테이블 예약은 예약테이블에 저장이됨
  
  --리콜테이블조회
  SELECT *
  FROM Recall
  
  
  -- 1번에서 조회된 예약건을  리콜 테이블 형식에 맞추어 조회 
  
  SELECT '201706' + dbo.fn_CharSeqMake(ROW_NUMBER() OVER(ORDER BY SEQ DESC),4), ID, DoctorId, AppDate, AppTime, Duration, Slot, 'N', '', '', '','', Todo, '1900-01-01 00:00:00.000', '1','','','Y',AddId, AddDate,updid, UpdDate
  FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0'
   
  
  
  
  --3.리콜테이블에 들어가는 데이터 세팅이 다됐으면 리콜테이블에 insert 해주는 로직 (건수 및 제대로 들어가는 지 확인)
  
  begin tran
  
  SELECT *
  FROM Recall
  
  
  
  
  INSERT INTO Recall
(
RecallID
,ID
,DoctorId
,RecallDate
,RecallTime
,Duration
,Slot
,Contact
,Method
,result
,Note
,Type
,Todo
,ChangeDate
,ChangeType
,KeyValue
,ChangePreType
,Valid
,AddId
,AddDate
,UpdId
,UpdDate)
SELECT '201706' + dbo.fn_CharSeqMake(ROW_NUMBER() OVER(ORDER BY SEQ DESC),4), ID, DoctorId, AppDate, AppTime, Duration, Slot, 'N', '', '', '','', Todo, '1900-01-01 00:00:00.000', '1','','','Y',AddId, AddDate,updid, UpdDate
  FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0' 
   
   
   
   select *
   from recall  
   
   
   
   rollback tran 
   
   
   
   
   --4. 해당 예약내용을 리콜테이블에 저장한후 예약건 백업해두기 (혹시 되돌려 달라고 얘기할수 있으니)
   
   
  select *
 into ApptimeRecallChange_20170621   -- 테이블이름은 본인이 보기쉽고 남들도 쉽게 이해할수 있는 이름으로 지을 것 
 FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0' 
   
   
   -- 백업됐는지 확인
   
  select *
  from ApptimeRecallChange_20170621
  
  
  
  
  --5. 백업 후 예약테이블에서 해당 예약건들 삭제 할 것 
  
 begin tran
SELECT * 
   FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0'   
 
 
   
   DELETE
  FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0'   
   
   
   SELECT * 
   FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0'  
   
   
   rollback tran 