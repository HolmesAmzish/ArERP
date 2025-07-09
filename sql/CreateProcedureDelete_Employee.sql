CREATE PROCEDURE Delete_Employee
    @EmployeeId INT
AS
BEGIN
    DELETE FROM Employees WHERE EmployeeId = @EmployeeId
END
