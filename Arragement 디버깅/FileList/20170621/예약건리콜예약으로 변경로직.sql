   --1. �ش� ����ǵ� ��ȸ ���� (�ʿ��� ������ �׶��׶����� ����� �̹����� �׿ܿ��� �� �̵��ȯ�ڰ��� ������)
   SELECT *
  FROM AppTime
 WHERE AppTime = '09:00' 
   AND Valid = 'Y'
    AND AppDate > '20170620'
   AND AppType = '0'  -- �Ϲݿ����� ��� apptype  = '0'  �ٸ����� ���� ������ �׼� ���̺� ���̾ƿ� ����
   
   
   
   
  --2. ��ȸ�� ����� ���Ͽ�  �������̺�� �� ( �Ϲ� ������� ���ݰ����� �����ش޶�� ��û�� �Ա� ���� )
  -- ���� ����ȭ�鿡���� �������� ���������δ� ������ �������̺� ������ �������̺� �����̵�
  
  --�������̺���ȸ
  SELECT *
  FROM Recall
  
  
  -- 1������ ��ȸ�� �������  ���� ���̺� ���Ŀ� ���߾� ��ȸ 
  
  SELECT '201706' + dbo.fn_CharSeqMake(ROW_NUMBER() OVER(ORDER BY SEQ DESC),4), ID, DoctorId, AppDate, AppTime, Duration, Slot, 'N', '', '', '','', Todo, '1900-01-01 00:00:00.000', '1','','','Y',AddId, AddDate,updid, UpdDate
  FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0'
   
  
  
  
  --3.�������̺� ���� ������ ������ �ٵ����� �������̺� insert ���ִ� ���� (�Ǽ� �� ����� ���� �� Ȯ��)
  
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
   
   
   
   
   --4. �ش� ���೻���� �������̺� �������� ����� ����صα� (Ȥ�� �ǵ��� �޶�� ����Ҽ� ������)
   
   
  select *
 into ApptimeRecallChange_20170621   -- ���̺��̸��� ������ ���⽱�� ���鵵 ���� �����Ҽ� �ִ� �̸����� ���� �� 
 FROM AppTime
 WHERE AppTime = '09:00'
   AND Valid = 'Y'
   AND AppDate > '20170620'
   AND AppType = '0' 
   
   
   -- ����ƴ��� Ȯ��
   
  select *
  from ApptimeRecallChange_20170621
  
  
  
  
  --5. ��� �� �������̺��� �ش� ����ǵ� ���� �� �� 
  
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