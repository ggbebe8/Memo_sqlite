
IF NOT EXISTS( SELECT 'x' FROM SYS.TABLES T JOIN SYS.COLUMNS C ON T.OBJECT_ID = C.OBJECT_ID
     WHERE T.NAME = 'CidSetting'AND C.NAME = 'LGDcsServerIP' )
BEGIN 
     ALTER TABLE CidSetting ADD LGDcsServerIP VARCHAR(50) 
END

---- object���̺��� ���̺� ���� Ű���� ������ �����Ƿ� join���ִ� ��.
---- �⺻������ ���� ���� �ܿ� ��.
---- ���⿡�� ������ �߰��� ���̺��� ���� ���ο� ���� �־��ְ� ���� ���� �ݵ��!!!!! isnull���� ���� �־���� ��!
---- ó�� ��ũ��Ʈ�� ������ ���� �翬 ������ ������, downlist ���� ���� ����� ���� ������Ʈ�� �����Ѵٸ� ������ ���� �� ���ư� ���� �ֱ� �����̴�.
---- ��� ������ �����غ���! ��!