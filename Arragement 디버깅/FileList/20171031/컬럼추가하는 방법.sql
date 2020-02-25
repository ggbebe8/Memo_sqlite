
IF NOT EXISTS( SELECT 'x' FROM SYS.TABLES T JOIN SYS.COLUMNS C ON T.OBJECT_ID = C.OBJECT_ID
     WHERE T.NAME = 'CidSetting'AND C.NAME = 'LGDcsServerIP' )
BEGIN 
     ALTER TABLE CidSetting ADD LGDcsServerIP VARCHAR(50) 
END

---- object테이블은 테이블에 대한 키값을 가지고 있으므로 join해주는 것.
---- 기본적으로 위에 것은 외울 것.
---- 여기에는 없지만 추가한 테이블의 값에 새로운 값을 넣어주고 싶을 때는 반드시!!!!! isnull같은 것을 넣어줘야 함!
---- 처음 스크립트를 실행할 때는 당연 문제가 없지만, downlist 같은 것을 지우고 새로 업데이트를 실행한다면 기존의 값이 다 날아갈 수도 있기 때문이다.
---- 계속 여러번 실행해보기! 꼭!