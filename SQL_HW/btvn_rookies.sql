                                                    --Exercises for SQL query

--Notes:
---	You can write in different ways for example using subquery, join or union. 
---	You should use Training database to practice on it. 
---	The exercise should be submitted with .sql file.

--1. Create a query that displays the last name and hire date of any employee in the same department as the employee with name = Zlotkey and excluding employee Zlotkey from the result returns.
select*from employees where last_name='Zlotkey'
select*from employees where department_id=80 and last_name!='zlotkey'
select*from employees where department_id in 
(select department_id from employees where last_name='zlotkey') and last_name!='zlotkey'
--way2
select *from employees e1
inner join employees e2 on e1.department_id=e2.department_id
where e2.last_name='zlotkey' and e1.last_name!='zlotkey'


--2. Create a report that displays the employee number, last name, and salary of all employees who earn more than the average salary. Sort the results in order of ascending salary.
select employee_id, last_name, salary from employees where salary > (select AVG(salary)from employees) 
order by salary desc


--3. Write a query that displays the employee number and last name of all employees who work in a department with any employee whose last name contains the letter “u”
select employee_id, last_name 
from employees
where department_id in (select department_id from employees where last_name like '%u%');


--4. The HR department needs a report that displays the last name, department number, and job ID of all employees whose department location ID is 1700.
select e1.last_name, e1.department_id, e1.job_id from employees e1 
join departments d1 on e1.department_id= d1.department_id
where d1.location_id=1700


--5. Create a report for HR that displays the last name and salary of every employee who reports to King.
select last_name, salary 
from employees


--6. Create a report for HR that displays the department number, last name, and job ID for every employee in the Executive department.


select department_id, last_name, job_id from employees
where department_id in (select department_id from departments where department_name ='Executive')



--7. Create query to display the employee number, last name, and salary of all the employees who earn more than the average salary and who work in a department with any employee whose last name contains a letter “u”.
select employee_id, last_name, salary
from employees
where salary > (select avg(salary) from employees)
and department_id in (select department_id from employees where last_name like '%u%');


--8. Find the highest, lowest, sum, and average salary of all employees. Label the columns as Maximum, Minimum, Sum, and Average, respectively. Round your results to the nearest whole number
SELECT MIN(salary) AS Minimum,
Max(salary) AS Maximum,
Sum(salary) AS Sum,
Round(avg(salary),0)as Average
FROM employees;

--9. Write a query that displays the last name (with the first letter in uppercase and all the other letters in lowercase) and the length of the last name for all employees whose name starts with the letters “J,” “A,” or “M.” Give each column an appropriate label. Sort the results by the employees’ last names.

Select ((UPPER(substring(last_name, 1, 1))) + (LOWER(substring(last_name, 2, LEN(last_name))))) AS Last_name,
       LEN(last_name)    AS Length_Name
From employees
Where (substring(last_name, 1, 1))
    Like 'J'
   OR (substring(last_name, 1, 1))
    Like 'A'
   OR (substring(last_name, 1, 1))
    Like 'M'
Order by last_name ASC;

--10. The HR department needs a report to display the employee number, last name, salary, and salary increased by 15.5% (expressed as a whole number) for each employee. Label the column New Salary

Select employee_id, last_name, salary, Format(salary + (salary * 15.5 / 100), 'N2') AS New_Salary
From employees;


--11.The HR department needs a report with the following specifications:
--•	Last name and department ID of all employees from the employees table, regardless of whether or not they belong to a department
--•	Department ID and department name of all departments from the departments table, regardless of whether or not they have employees working in them
--Write a compound query to accomplish this.


--Way 1:
Select department_id, last_name AS Name
From employees
Union all
Select department_id, department_name
from departments

--Way 2:
Select emp.employee_id, emp.last_name, emp.department_id, d.department_name
From employees emp left join departments d on emp.department_id = d.department_id
Union
Select emp.employee_id, emp.last_name, emp.department_id, d.department_name
From departments d left join employees emp on emp.department_id = d.department_id



--12. Produce a list of employees who joined the company later than their manager and who work in Toronto. Display the employee_id by using the set operators. 

Select e1.employee_id
From employees e1
         Inner join employees manager on manager.employee_id = e1.manager_id
Where e1.hire_date > manager.hire_date
Union
Select e2.employee_id
From employees e2
         Inner join departments d on e2.department_id = d.department_id
         Inner join locations l on d.location_id = l.location_id
Where city = 'Toronto';




