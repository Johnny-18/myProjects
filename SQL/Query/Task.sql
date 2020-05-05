USE DB;

/*1. Получить список всех должностей компании с количеством сотрудников на
каждой из них*/
 
SELECT PositionName, 
COUNT(Employees.FK_Position_Id) AS CountEmployee 
FROM Positions, Employees 
WHERE Position_Id = FK_Position_Id
GROUP BY PositionName;

/*2. Определить список должностей компании, на которых нет сотрудников*/

SELECT PositionName  
FROM Positions
WHERE Position_Id NOT IN(SELECT FK_Position_Id FROM Employees);

/*3. Получить список проектов с указанием, сколько сотрудников каждой
должности работает на проекте*/

SELECT ProjectName,PositionName,COUNT(e.FK_Position_Id) AS CountEmployee
FROM Projects pr, EmployeesProjects  ep,Positions po,Employees e
WHERE e.Employee_Id = ep.Employee_Id AND pr.Project_Id = ep.Project_Id AND Position_Id = FK_Position_Id
GROUP BY ProjectName,PositionName;

/*4. Посчитать на каждом проекте, какое в среднем количество задач
приходится на каждого сотрудника*/

SELECT s.ProjectName, SUM(s.Tasks)/COUNT(s.FK_Employee_Id) AS Average
FROM 
(SELECT p.ProjectName, t.FK_Employee_Id, COUNT(t.Task_Id) AS Tasks
FROM Projects p
JOIN Tasks t
ON t.FK_Project_Id = p.Project_Id
GROUP BY p.ProjectName,t.FK_Employee_Id) AS s
GROUP BY s.ProjectName

/*5. Подсчитать длительность выполнения каждого проекта*/

SELECT Projects.ProjectName, DATEDIFF(DAY, Projects.DateOfCreation, 
CASE WHEN Projects.DateOfClosing IS NULL THEN GETDATE() ELSE Projects.DateOfClosing END) AS Days
FROM Projects;
 
/*6. Определить сотрудников с минимальным количеством незакрытых задач*/

SELECT r.FullName, COUNT(r.CountTask) AS CountTasks
FROM 
(SELECT e.FirstName + ' ' + e.LastName FullName, s.CountTask
FROM
	(SELECT t.FK_Employee_Id,COUNT(t.FK_Employee_Id) AS CountTask
	FROM Tasks t
	JOIN TaskStatus st
	ON t.FK_TaskStatus_Id = st.TaskStatus_Id
	WHERE st.TaskStatusName != 'Closed'
	GROUP BY t.FK_Employee_Id
	) AS s
JOIN Employees e
ON e.Employee_Id = s.FK_Employee_Id) AS r
WHERE r.CountTask = (SELECT MIN(r.CountTask) 
		FROM 
		(SELECT e.FirstName + ' ' + e.LastName FullName, s.CountTask
		FROM
			(SELECT t.FK_Employee_Id,COUNT(t.FK_Employee_Id) AS CountTask
			FROM Tasks t
			JOIN TaskStatus st
			ON t.FK_TaskStatus_Id = st.TaskStatus_Id
			WHERE st.TaskStatusName != 'Closed'
			GROUP BY t.FK_Employee_Id
			) AS s
		JOIN Employees e
		ON e.Employee_Id = s.FK_Employee_Id) AS r)
GROUP BY r.FullName;

/*7. Определить сотрудников с максимальным количеством незакрытых задач,
дедлайн которых уже истек*/

USE DB
INSERT INTO temp.dbo.EmployeeCount
SELECT ep.Employee_Id AS EmployeeId, count(ts.TaskStatus_Id) AS TaskCount 
FROM TaskStatus ts
		JOIN Tasks t
		ON t.FK_TaskStatus_Id = ts.TaskStatus_Id
			JOIN EmployeesProjects ep
			ON ep.Employee_Id = t.FK_Employee_Id
			WHERE ts.TaskStatusName != 'Closed'
			AND t.Deadline < GETDATE()
			GROUP BY ep.Employee_Id;

SELECT DISTINCT e.FirstName + ' ' + e.LastName, c.TaskCount AS Name FROM temp.dbo.EmployeeCount AS c,Employees AS e
WHERE TaskCount = (SELECT max(TaskCount) FROM temp.dbo.EmployeeCount) AND e.Employee_Id = c.EmpoyeeId 

/*8. Продлить дедлайн незакрытых задач на 5 дней*/

UPDATE Tasks
SET Deadline = DATEADD(DAY,5,Deadline)
WHERE Tasks.FK_TaskStatus_Id != (SELECT TaskStatus_Id FROM TaskStatus WHERE TaskStatusName = 'Closed');

/*9. Посчитать на каждом проекте количество задач, к которым еще не
приступили*/

SELECT p.ProjectName AS Project, COUNT(t.Task_Id) AS TaskCount FROM Projects p
	JOIN Tasks t
		ON t.FK_Project_Id = p.Project_Id
	JOIN TaskStatus ts
		ON t.FK_TaskStatus_Id = ts.TaskStatus_Id
		AND ts.TaskStatusName = 'Open'
GROUP BY p.ProjectName;

/*10.Перевести проекты в состояние закрыт, для которых все задачи закрыты и
задать время закрытия временем закрытия задачи проекта, принятой
последней*/

UPDATE Projects
	SET FK_ProjectStatus_Id = 2,
	DateOfClosing= ProjectTime.MaxDateTime
	FROM Projects p
	JOIN (SELECT ep.Project_Id, MAX(t.DateOfChange) AS MaxDateTime FROM TaskStatus ts
			JOIN Tasks t
				ON t.FK_TaskStatus_Id = ts.TaskStatus_Id
			JOIN EmployeesProjects ep
				ON ep.Project_Id = t.FK_Project_Id
			GROUP BY ep.Project_Id) AS ProjectTime
	ON ProjectTime.MaxDateTime = p.Project_Id
WHERE NOT EXISTS (SELECT 'x' FROM EmployeesProjects ep
					JOIN Tasks t
						ON t.FK_Project_Id = ep.Project_Id
					JOIN TaskStatus ts
						ON ts.TaskStatus_Id = t.FK_TaskStatus_Id
						AND ts.TaskStatusName != 'Closed')

/*11.Выяснить по всем проектам, какие сотрудники на проекте не имеют
незакрытых задач*/

SELECT ep.Project_Id, ep.Employee_Id  AS EmployeeId FROM EmployeesProjects ep
WHERE ep.Project_Id IN (SELECT t.FK_Project_Id FROM Tasks t
					JOIN TaskStatus ts
						ON t.FK_TaskStatus_Id = ts.TaskStatus_Id
						AND ts.TaskStatusName != 'Closed');

/*12.Заданную задачу (по названию) проекта перевести на сотрудника с
минимальным количеством выполняемых им задач*/

Declare @taskNumber int

SET @taskNumber = 4;

DECLARE @temp int

SET @temp = (SELECT TOP(1) s.FK_Employee_Id FROM 
				(SELECT t.FK_Employee_Id, COUNT(t.FK_Employee_Id) CountTask FROM Tasks t
				JOIN TaskStatus ts ON t.FK_TaskStatus_Id = ts.TaskStatus_Id 
				GROUP BY t.FK_Employee_Id) s
				ORDER BY s.CountTask);

	UPDATE Tasks
	SET FK_Employee_Id = @temp
	WHERE Task_Id = @taskNumber

