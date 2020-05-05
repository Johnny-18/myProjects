USE DB;

GO

CREATE TABLE ProjectStatus(
	ProjectStatus_Id INT PRIMARY KEY IDENTITY(1,1),
	ProjectStatusName VARCHAR(30) UNIQUE NOT NULL);
GO

CREATE TABLE Positions(
	Position_Id INT PRIMARY KEY IDENTITY(1,1),
	PositionName VARCHAR(30) NOT NULL);
GO

CREATE TABLE Employees(
	Employee_Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	FK_Position_Id INT NOT NULL,
	FOREIGN KEY (FK_Position_Id) REFERENCES Positions(Position_Id));
GO

CREATE TABLE TaskStatus(
	TaskStatus_Id INT PRIMARY KEY IDENTITY(1,1),
	TaskStatusName VARCHAR(20) NOT NULL);
GO

CREATE TABLE Projects(
	Project_Id INT PRIMARY KEY IDENTITY(1,1), 
	ProjectName VARCHAR(30) UNIQUE NOT NULL,
	DateOfCreation DATETIME NOT NULL,
	DateOfClosing DATETIME,
	FK_ProjectStatus_Id INT NOT NULL,
	FOREIGN KEY (FK_ProjectStatus_Id) REFERENCES ProjectStatus(ProjectStatus_Id));
GO

CREATE TABLE Tasks(
	Task_Id INT PRIMARY KEY IDENTITY(1,1),
	TaskName VARCHAR(30) UNIQUE NOT NULL,
	DateOfChange DATETIME,
	Deadline DATETIME NOT NULL,
	FK_TaskStatus_Id INT NOT NULL,
	FK_Employee_Id INT NOT NULL,
	FK_Project_Id INT NOT NULL,
	FOREIGN KEY (FK_Project_Id) REFERENCES Projects(Project_Id),
	FOREIGN KEY (FK_Employee_Id) REFERENCES Employees(Employee_Id),
 	FOREIGN KEY (FK_TaskStatus_Id) REFERENCES TaskStatus(TaskStatus_Id));
GO

CREATE TABLE EmployeesProjects(
	Employee_Id INT,
	Project_Id INT,
	PRIMARY KEY(Employee_Id, Project_Id),
	FOREIGN KEY (Employee_Id) REFERENCES Employees(Employee_Id),
	FOREIGN KEY (Project_Id) REFERENCES Projects(Project_Id));
 