USE DB;

GO

INSERT INTO Positions (PositionName) VALUES ('Junior');
INSERT INTO Positions (PositionName) VALUES ('Middle');
INSERT INTO Positions (PositionName) VALUES ('Senior');
INSERT INTO Positions (PositionName) VALUES ('TeamLead');
INSERT INTO Positions (PositionName) VALUES ('Manager');
INSERT INTO Positions (PositionName) VALUES ('Director');
INSERT INTO Positions (PositionName) VALUES ('MainOwner');

GO

INSERT INTO ProjectStatus (ProjectStatusName) VALUES ('Open');
INSERT INTO ProjectStatus (ProjectStatusName) VALUES ('Close');

GO

INSERT INTO TaskStatus (TaskStatusName) VALUES ('Open');
INSERT INTO TaskStatus (TaskStatusName) VALUES ('Completed');
INSERT INTO TaskStatus (TaskStatusName) VALUES ('Needs improvement');
INSERT INTO TaskStatus (TaskStatusName) VALUES ('Closed');

GO

INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Ivan','Ivanov',1);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Petr','Petrov',1);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Eugene','Bloch',3);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Andrey','Andreev',4);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Eugene','Rise',4);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Alex','Kotov',4);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('John','Smith',2);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Ivan','Zherybor',1);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Oleh','Orlov',2);
INSERT INTO Employees (FirstName,LastName,FK_Position_Id) 
VALUES ('Maria','Ivanova',1);

GO

INSERT INTO Projects (ProjectName,DateOfCreation,FK_ProjectStatus_Id,DateOfClosing) 
VALUES ('Ecvador','01/02/2010',2,'12/10/2018');
INSERT INTO Projects (ProjectName,DateOfCreation,FK_ProjectStatus_Id) 
VALUES ('1XBET','10/08/2018',1);
INSERT INTO Projects (ProjectName,DateOfCreation,FK_ProjectStatus_Id) 
VALUES ('MaestroTicket','01/02/2020',1);
INSERT INTO Projects (ProjectName,DateOfCreation,FK_ProjectStatus_Id) 
VALUES ('RePRO','02/02/2020',1);
INSERT INTO Projects (ProjectName,DateOfCreation,FK_ProjectStatus_Id,DateOfClosing) 
VALUES ('QWERTY','10/23/2000',2,'02/01/2020');
INSERT INTO Projects (ProjectName,DateOfCreation,FK_ProjectStatus_Id) 
VALUES ('TeamViewer','04/23/1998',1);

GO

INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('UpdateValues','07/04/2020','08/05/2020',1,1,1);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('ResetValues','06/04/2020','07/05/2020',4,2,1);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('CreateNewAbstractClass','04/14/2020','05/14/2020',3,3,1);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('CreateInterfaces','12/03/2020','01/03/2021',2,4,2);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('DeleteModels','10/02/2020','11/02/2020',1,5,2);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('GetAllValues','02/01/2020','03/01/2020',3,6,3);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('CreateQueryToCreateNewDatabase','07/03/2020','08/03/2020',1,7,3);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('CreateQueryToCreateTables','12/02/2020','01/02/2021',1,7,4);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('CreateQueryInserts','12/02/2019','01/02/2021',1,8,3);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('DropQueryTables','12/05/2019','01/02/2021',1,8,3);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('DropQueryDatabase','02/08/2018','01/02/2021',1,8,2);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('CreateClass','10/01/2019','01/02/2021',1,2,1);
INSERT INTO Tasks (TaskName,DateOfChange,Deadline,FK_TaskStatus_Id,FK_Employee_Id,FK_Project_Id) 
VALUES ('CreateMethod','09/09/2017','01/02/2021',1,2,1);

GO

INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (1,1);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (1,2);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (1,3);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (2,4);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (2,5);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (3,6);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (3,7);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (4,8);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (6,9);
INSERT INTO EmployeesProjects (Project_Id,Employee_Id) VALUES (5,10);