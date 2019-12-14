
INSERT INTO [NPDDB].[NPD].[Persons] ([Firstname],[Lastname],[Gender],[PersonalNumber],[BirthDate],[CityId],[ImagePath])
VALUES 
('test1','test1',0,'02345678911','20001001',1,'Images\image.jpg'),
('test2','test2',0,'02345678912','20001001',1,'Images\image.jpg'),
('test3','test3',0,'02345678913','20001001',1,'Images\image.jpg'),
('test4','test4',0,'02345678914','20001001',1,'Images\image.jpg'),
('test5','test5',0,'12345678915','20001001',1,'Images\image.jpg')

INSERT INTO [NPDDB].[NPD].[RelatedPersons] ([Type],[PersonId],[RPersonId])
VALUES 
('1',1,2),
('0',1,3)

INSERT INTO [NPDDB].[NPD].[PhoneNumbers] ([Type],[Value],[PersonId])
VALUES 
(1,'598641245',1),
(1,'598641248',1),
(2,'598641778',2)