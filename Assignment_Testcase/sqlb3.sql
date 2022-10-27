SELECT * 
FROM employees;

SELECT * 
FROM departments;

SELECT * 
FROM jobs;

SELECT a.employee_id, a. first_name, a.last_name, b.department_name
FROM employees a
INNER JOIN departments b
ON a.department_id = b.department_id
WHERE b.department_name LIKE 'marketing';


--Lấy danh sách nhân viên làm công việc Programmer

SELECT a.employee_id, a. first_name, a.last_name,b.job_title
FROM employees a
INNER JOIN jobs b 
ON a.job_id = b.job_id
WHERE b.job_title = 'Programmer';